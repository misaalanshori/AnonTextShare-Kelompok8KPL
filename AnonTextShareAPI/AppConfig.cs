using System;
using System.Text;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AnonTextShareAPI
{
    public class AppConfig
    {
        public RuntimeConfig config;
        public const string txt = @"./content.json";
        public AppConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                setDefault();
                WriteConfigFile();
            }
        }

        public RuntimeConfig ReadConfigFile()
        {
            string jsonText = File.ReadAllText(txt);
            config = JsonSerializer.Deserialize<RuntimeConfig>(jsonText);
            return config;
        }

        public void setDefault()
        {
            config = new RuntimeConfig(32, 128);
        }

        public void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonText = JsonSerializer.Serialize(config, options);
            File.WriteAllText(txt, jsonText);
        }
    }
}
