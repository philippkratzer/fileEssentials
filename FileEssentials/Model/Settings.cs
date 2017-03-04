using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEssentials.Model
{
    class Settings
    {
        public static Settings Default { get; set; }

        private static string _defaultFilename = "settings.json";

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static Settings Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Settings>(json);
        }

        public static void SerializeFile()
        {
            System.IO.File.WriteAllText(_defaultFilename, Serialize(Default));
        }

        public static void DeserializeFile()
        {
            Default = Deserialize(System.IO.File.ReadAllText(_defaultFilename));
        }

        public string PathPictures { get; set; }
        public string PathDestination { get; set; }
        public int LongSideLength { get; set; }
        public List<string> Blacklist { get; set; }

        public Settings()
        {

        }
    }
}
