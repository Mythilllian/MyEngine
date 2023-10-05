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

        public ExpressedEngine(string title, Vector2 size)
        {
            this.title = title;
            this.size = size;

            window = new Canvas();
            window.Size = new Size(size.x,size.y);
            window.Text = title;
            window.Paint += Renderer;

            OnLoad();

            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();

            Application.Run(window);
;        }

        void GameLoop()
        {
            while (gameLoopThread.IsAlive)
            {
                window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });
                Thread.Sleep(1);
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
        }

        public abstract void OnLoad();
    }
}
