using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public struct InputMap
    {
        public Input[] inputs;

        public string GetInputName(char keyChar)
        {
            foreach(var input in inputs)
            {
                foreach(char key in input.keys)
                {
                    if(keyChar == key)
                    {
                        return input.name;
                    }
                }
            }
            return null;
        }
    }

    public struct Input
    {
        public string name;
        public char[] keys;
    }
}
