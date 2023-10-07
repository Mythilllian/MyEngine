using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEngine.Engine;

namespace GameEngine
{
    class DemoGame : ExpressedEngine
    {
        public DemoGame(string title, Vector2 size) : base(title, size) { }

        public override void OnKeyDown(object sender, KeyEventArgs e) { }
        public override void OnKeyUp(object sender, KeyEventArgs e) { }
        public override void OnKeyPress(object sender, KeyPressEventArgs e) { }

        public override void Strt() { }
        public override void Upd(float dT) { }
        public override void OnLoad() { }
        public override void CreateComps() { }
    }
}
