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

        public InputMap(Input[] inputs)
        {
            this.inputs = inputs != default(Input[]) ? inputs : new Input[0];
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
        public Input[] GetInputs(char keyChar)
        {
            Log.LogInfo(
                (from input in inputs
                from char key in input.keys
                select key).ToString()
                ,ConsoleColor.Yellow);
            return (from input in inputs
                    from char key in input.keys
                    where keyChar == key
                    select input) as Input[];
        }

        /// <summary>
        /// Sets all inputs active with a certain key
        /// </summary>
        /// <param name="keyChar">The character pressed</param>
        public void SetActive(char keyChar)
        {
            foreach (Input input in GetInputs(keyChar))

            {
                input.pressed.Item2.Add(keyChar);
                input.pressed.Item1 = true;
            }
        }

        /// <summary>
        /// Sets all inputs inactive with a certain key
        /// </summary>
        /// <param name="keyChar">The character pressed</param>
        public void SetInactive(char keyChar)
        {
            foreach (Input input in GetInputs(keyChar))
            {
                input.pressed.Item2.Remove(keyChar);
                input.pressed.Item1 = input.pressed.Item2.Count == 0 ? false : true;
            }
        }

        /// <summary>
        /// Finds the first input name
        /// </summary>
        /// <param name="keyChar">The character pressed</param>
        public string GetFirstInputName(char keyChar)
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

    [JsonObject]
    public class Input
    {
        public string name;
        public char[] keys;
        
        [JsonIgnore]
        public (bool,List<char>) pressed;
        [JsonIgnore]
        public bool isPressed { get { return pressed.Item1; } set { } }
    }
}
