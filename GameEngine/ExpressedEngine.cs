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
        private Canvas window;
        private Thread gameLoopThread;

        public TransformComp camera;
        public static List<Comp> components = new List<Comp>();

        public ExpressedEngine(string title, Vector2 size)
        {
            this.title = title;
            this.size = size;

            window = new Canvas();
            window.Size = new Size(size.x,size.y);
            window.Text = title;
            window.Paint += Renderer;

            Awk();

            OnLoad();

            Strt();

            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();

            Application.Run(window);
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
                window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });
                Thread.Sleep(1);
                Upd((float)(DateTime.Now - startLoop).TotalSeconds);
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;


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

        public void RegisterObj(Comp component)
        {
            components.Add(component);
        }

        public void RemoveObj(Comp component)
        {
            components.Remove(component);
        }

        public abstract void OnLoad();
    }
}
