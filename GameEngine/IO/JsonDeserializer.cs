using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using GameEngine.Engine;
using Newtonsoft.Json;

namespace GameEngine.IO
{
    public static class JsonDeserializer
    {
        public static T DeserializeJson<T>(string json)
        {
            T deserialized = default(T);
            try
            {
                deserialized = JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                Log.LogInfo("Attempted to read empty JSON file", ConsoleColor.Red);
            }
            return deserialized;
        }

        public static T DeseralizePath<T>(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                return DeserializeJson<T>(json);
            }
            else
            {
                throw new FileNotFoundException("File not found at path.", path);
            }
        }
    }
}
