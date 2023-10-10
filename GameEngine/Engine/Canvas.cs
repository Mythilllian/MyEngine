using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEngine
{
    public class Canvas : Form
    {
        public Canvas() : base()
        {
            DoubleBuffered = true;
        }
        public Canvas(int width, int height, string name = "Default Name") : base()
        {
            DoubleBuffered = true;
            InitializeComponent(width, height, name);
        }

        public void InitializeComponent(int width, int height, string name = "Default Name")
        {
            SuspendLayout();
            // 
            // Canvas
            // 
            ClientSize = new System.Drawing.Size(width, height);
            Name = name;
            
            ResumeLayout(false);

        }
    }
}
