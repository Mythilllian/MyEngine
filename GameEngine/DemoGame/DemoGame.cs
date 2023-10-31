using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Drawing;
using System.Windows.Forms;
using GameEngine.Engine;
using System.IO;
using System.Reflection;

namespace GameEngine.DemoGame
{
    class DemoGame : ExpressedEngine
    {
        TransformComp obj;

        public DemoGame() : base(
            "DemoGame", 
            new Vector2(1500,1000), 
            Path.Combine(Directory.GetCurrentDirectory() + "InputMap.json")) { }

        public override void OnStart() 
        {
        }
        public override void OnUpdate(float dT) 
        {
            if (Inputs.IsActive("left")) { Log.LogInfo("Left pressed"); obj.position -= new Vector2(1,0); }
            if (Inputs.IsActive("right")) { Log.LogInfo("Right pressed"); obj.position += new Vector2(1, 0); }
        }
        public override void OnLoad() { }
        public override void CreateComps() 
        {
            camera = new TransformComp("Camera",null,Vector2.Zero, Vector2.One);
            camera.AddComp(new CameraComp());

            obj = new TransformComp("Player", new Vector2(0,1000), new Vector2(10, 2000));
            ShapeComp shapeComp = obj.AddComp<ShapeComp>(new ShapeComp());

            shapeComp.shape = new Shape(ShapeType.Circle, new Vector2(200, 200), Color.ForestGreen);
            
        }
    }
}
