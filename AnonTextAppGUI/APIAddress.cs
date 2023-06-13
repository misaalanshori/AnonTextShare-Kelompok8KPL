using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnonTextAppConsoleUI
{
    internal class APIAddress
    {
        public class setAPI {
            public string Address { get; set; }

            public setAPI(string address) {
                this.Address = address;
            }
        }

        public class readWrite {
            public setAPI config;
            public const string txt = @"./APIAddress.json";
            private void setDefault() {
                config = new setAPI("http://localhost:5152");
            }
            private void NewConfigFile() {
                JsonSerializerOptions baru = new JsonSerializerOptions() {
                    WriteIndented = true,
                };
                string jsonString = JsonSerializer.Serialize(config, baru);
                File.WriteAllText(txt, jsonString);
            }
            private setAPI ReadConfigFile() {
                string readJson = File.ReadAllText(txt);
                config = JsonSerializer.Deserialize<setAPI>(readJson);
                return config;
            }
            public readWrite(){
                try {
                    ReadConfigFile();
                }catch(Exception) {
                    setDefault();
                    NewConfigFile();
                }
            }
        }
    }
}
