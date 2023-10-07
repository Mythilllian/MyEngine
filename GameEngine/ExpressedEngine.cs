using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GameEngine
{
    public abstract class ExpressedEngine
    {
        private string title = "Default Name";
        private Vector2 size = new Vector2(500, 500);
        public static Canvas Window { get; private set; }
        private Thread gameLoopThread;

        public TransformComp camera;
        public static List<Comp> components = new List<Comp>();

        public ExpressedEngine(string title, Vector2 size)
        {
            this.title = title;
            this.size = size;

            Window = new Canvas();
            Window.Size = new Size(size.x,size.y);
            Window.Text = title;
            Window.Paint += Renderer;

            Awk();

            OnLoad();

            Strt();

            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();

            Application.Run(Window);
;       }

        void Awk()
        {
            foreach(Comp comp in components)
            {
                comp.Awk();
            }
        }

        void Strt()
        {
            foreach (Comp comp in components)
            {
                comp.Strt();
            }
        }

        void Upd(float dT)
        {
            foreach (Comp comp in components)
            {
                comp.Upd(dT);
            }
        }


        void GameLoop()
        {
            while (gameLoopThread.IsAlive)
            {
                DateTime startLoop = DateTime.Now;
                Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                Thread.Sleep(1);
                Upd((float)(DateTime.Now - startLoop).TotalSeconds);
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(((CameraComp)camera.GetComp<CameraComp>()).backgroundColor);

            g.TranslateTransform(camera.position.x, camera.position.y);
            g.RotateTransform(camera.rotation);
            g.ScaleTransform(camera.size.x, camera.size.y);

            try
            {
                foreach (Comp component in components)
                {
                    if (component.GetType() == typeof(ImageComp)) 
                    { 
                        g.DrawImage(((ImageComp)component).img, component.parent.position.x, component.parent.position.y, component.parent.size.x, component.parent.size.y); 
                    }
                }
            }
            catch { }
        }

        public static void RegisterComp(Comp component)
        {
            components.Add(component);
        }

        public static void RemoveComp(Comp component)
        {
            components.Remove(component);
        }

        public abstract void OnLoad();
    }
}
