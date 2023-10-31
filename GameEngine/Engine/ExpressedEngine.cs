using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GameEngine.IO;

namespace GameEngine.Engine
{
    public abstract class ExpressedEngine
    {
        private string title = "Default Name";
        private Vector2 size = new Vector2(500, 500);

        //Event handlers
        public event EventHandler Start;
        public event EventHandler<UpdateEventArgs> Update;

        public static Canvas Window { get; private set; }
        private Thread gameLoopThread;

        internal InputMap Inputs;

        public TransformComp camera;
        public static List<Comp> components { get; private set; }

        private KeysConverter kc = new KeysConverter();

        public ExpressedEngine(string title, Vector2 size, string json)
        {
            Inputs = new InputMap(JsonDeserializer.DeserializeJson<Input[]>(json));
            if(Inputs.inputs == new Input[0])
            {
                Log.LogInfo("InputMap not found", ConsoleColor.Red);
            }

            this.title = title;
            this.size = size;

            components = new List<Comp>();

            Window = new Canvas();
            Window.Size = new Size((int)size.x,(int)size.y);
            Window.Text = title;

            //Event listeners
            Window.Paint += new PaintEventHandler(Renderer);
            Window.KeyDown += new KeyEventHandler(OnKeyDown);
            Window.KeyUp += new KeyEventHandler(OnKeyUp);
            //Window.KeyPress += new KeyPressEventHandler(OnKeyPress);

            CreateComps();

            Start?.Invoke(this,new EventArgs());

            Application.Run(Window);

            //Creates loop thread
            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();
        }

        void GameLoop()
        {
            while (gameLoopThread.IsAlive)
            {
                DateTime startLoop = DateTime.Now;
                Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                Thread.Sleep(1);
                Update?.Invoke(this, new UpdateEventArgs((float)(DateTime.Now - startLoop).TotalSeconds));
            }
        }

        void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if(camera != null)
            {
                g.Clear(camera.GetCompByType<CameraComp>().backgroundColor);

                g.RotateTransform(camera.rotation);
                g.TranslateTransform(camera.position.x, camera.position.y);
                try
                {
                    g.ScaleTransform(Window.Size.Width, Window.Size.Height);
                }
                catch
                {
                    g.ScaleTransform(Window.Size.Width * camera.size.x, Window.Size.Height * camera.size.y);
                }
            }

            foreach (Comp component in components)
            {
                if (component.GetType() == typeof(ImageComp) && ((ImageComp)component).img != null) 
                {
                    g.DrawImage(((ImageComp)component).img, component.parent.position.x, component.parent.position.y, component.parent.size.x, component.parent.size.y);
                }
            }

            Window.BackgroundImage = new Bitmap(Window.Width,Window.Height,g);
        }

        public static void RegisterComp(Comp component)
        {
            components.Add(component);
            Log.LogInfo("Registered #" + components.Count + " Type: " + component.GetType().ToString(), ConsoleColor.Green);
        }

        public static void RemoveComp(Comp component)
        {
            components.Remove(component);
            Log.LogInfo("Removed Type: " + component.GetType().ToString(), ConsoleColor.Red);
        }

        public void OnKeyDown(object sender, KeyEventArgs e) { Inputs.SetActive(kc.ConvertToString(e.KeyValue).ToLower()[0]); }
        public void OnKeyUp(object sender, KeyEventArgs e) { Inputs.SetInactive(kc.ConvertToString(e.KeyValue)[0]); }

        public abstract void OnStart();
        public abstract void OnUpdate(float dT);
        public abstract void OnLoad();
        public abstract void CreateComps();

    }

    public class UpdateEventArgs : EventArgs
    {
        public float delta { get; set; }

        public UpdateEventArgs(float delta) { this.delta = delta; }
    }
}
