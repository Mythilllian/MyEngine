using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Engine;
using YamlDotNet.Serialization;

namespace GameEngine.IO
{
    public static class YamlDeserializer
    {
        static Serializer serializer;
        static Deserializer deserializer;

        public static InputMap Deserializer(string yaml)
        {
            return deserializer.Deserialize<InputMap>(yaml);
        }
    }
}
