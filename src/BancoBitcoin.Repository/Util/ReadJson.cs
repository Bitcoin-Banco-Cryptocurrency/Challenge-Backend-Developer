using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace BancoBitcoin.Repository.Util
{
    public static class ReadJson
    {
        public static T GetDeserializedObjectsFromJsonFile<T>(string file)
        {
            var json = ReadFile(file);
            return DeserializeObject<T>(json);
        }

        public static string ReadFile(string file)
        {
            var jsonPath = AppDomain.CurrentDomain.BaseDirectory + file;
            return File.ReadAllText(jsonPath, Encoding.UTF8);
        }

        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
