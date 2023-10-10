using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GameEngine.Engine
{
    public abstract class ExpressedEngine
    {
        private string title = "Default Name";
        private Vector2 size = new Vector2(500, 500);
        public static Canvas Window { get; private set; }
        private Thread gameLoopThread;
        private InputMap inputMap;

        public TransformComp camera;
        public static List<Comp> components = new List<Comp>();

        public ExpressedEngine(string title, Vector2 size)
        {
            this.title = title;
            this.size = size;

            Window = new Canvas();
            Window.Size = new Size((int)size.x,(int)size.y);
            Window.Text = title;

            //Event listeners
            Window.Paint += new PaintEventHandler(Renderer);
            Window.KeyDown += new KeyEventHandler(OnKeyDown);
            Window.KeyUp += new KeyEventHandler(OnKeyUp);
            Window.KeyPress += new KeyPressEventHandler(OnKeyPress);

            CreateComps();

            CallStart();

            Application.Run(Window);

            //Creates loop thread
            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();
        }

        void CallStart()
        {
            OnStart();
            foreach (Comp comp in components)
            {
                comp.OnStart();
            }
        }

        void CallUpdate(float dT)
        {
            OnUpdate(dT);
            foreach (Comp comp in components)
            {
                comp.OnUpdate(dT);
            }
        }


        void GameLoop()
        {
            while (gameLoopThread.IsAlive)
            {
                DateTime startLoop = DateTime.Now;
                Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                Thread.Sleep(1);
                CallUpdate((float)(DateTime.Now - startLoop).TotalSeconds);
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
                if (component.GetType() == typeof(ImageComp)) 
                {
                    g.DrawImage(((ImageComp)component).img, component.parent.position.x, component.parent.position.y, component.parent.size.x, component.parent.size.y);
                }
            }

            Window.BackgroundImage = new Bitmap(Window.Width,Window.Height,g);
        }

        public static void RegisterComp(Comp component)
        {
            components.Add(component);
        }

        public static void RemoveComp(Comp component)
        {
            components.Remove(component);
        }

        public abstract void OnKeyDown(object sender, KeyEventArgs e);
        public abstract void OnKeyUp(object sender, KeyEventArgs e);
        public abstract void OnKeyPress(object sender, KeyPressEventArgs e);

        public abstract void OnStart();
        public abstract void OnUpdate(float dT);
        public abstract void OnLoad();
        public abstract void CreateComps();

    }
}
