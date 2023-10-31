using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public struct InputMap
    {
        public Input[] inputs;
        readonly KeysConverter kc;

        public InputMap(Input[] inputs)
        {
            this.inputs = inputs != default(Input[]) ? inputs : new Input[0];
            kc = new KeysConverter();
        }

        public bool IsActive(string name)
        {
            foreach(var input in inputs)
            {
                if(input.name == name) { return input.isPressed; }
            }
            return false;
        }

        /// <summary>
        /// Gets inputs from a character presesd
        /// </summary>
        /// <param name="keyChar">The character pressed</param>\
        public Input[] GetInputs(string key)
        {
            Log.LogInfo(
                (from input in inputs
                from string _key in input.keys
                select key).ToString()
                ,ConsoleColor.Yellow);
            return (from input in inputs
                    from string _key in input.keys
                    where key == _key
                    select input) as Input[];
        }

        /// <summary>
        /// Sets all inputs active with a certain key
        /// </summary>
        /// <param name="keyChar">The character pressed</param>
        public void SetActive(int keyVal)
        {
            string key = kc.ConvertToString(keyVal);
            ((from input in inputs
              from string _key in input.keys
              from List<string> pressed in input.pressed
              where key == _key
              where !pressed.Contains(key)
              select input.pressed) as List<int>)?.Add(keyVal);
        }

        /// <summary>
        /// Sets all inputs inactive with a certain key
        /// </summary>
        /// <param name="keyChar">The character pressed</param>
        public void SetInactive(int keyVal)
        {
            string key = kc.ConvertToString(keyVal);
            ((from input in inputs
              from string _key in input.keys
              from List<string> pressed in input.pressed
              where key == _key
              where !pressed.Contains(key)
              select input.pressed) as List<int>)?.Remove(keyVal);
        }

        /// <summary>
        /// Finds the first input name
        /// </summary>
        /// <param name="keyChar">The character pressed</param>
        public string GetFirstInputName(string key)
        {
            foreach(var input in inputs)
            {
                foreach(string _key in input.keys)
                {
                    if(key == _key)
                    {
                        return input.name;
                    }
                }
            }
            return null;
        }
    }

    [JsonObject]
    public class Input
    {
        public string name;
        public string[] keys;
        
        [JsonIgnore]
        public List<int> pressed;
        [JsonIgnore]
        public bool isPressed { get { return pressed.Count > 0; } set { } }
    }
}
