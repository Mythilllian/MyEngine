using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using GameEngine.Engine;

namespace GameEngine.DemoGame
{
    class DemoGame : ExpressedEngine
    {
        public DemoGame() : base("DemoGame", new Vector2(1500,1000)) { }

        public override void OnKeyDown(object sender, KeyEventArgs e) { }
        public override void OnKeyUp(object sender, KeyEventArgs e) { }
        public override void OnKeyPress(object sender, KeyPressEventArgs e) { }

        public override void OnStart() { }
        public override void OnUpdate(float dT) { }
        public override void OnLoad() { }
        public override void CreateComps() 
        {
            camera = new TransformComp("Camera",null,Vector2.Zero,Vector2.One);
            camera.AddComp(new CameraComp());
        }
    }
}
