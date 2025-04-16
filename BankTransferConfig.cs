using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300116
{
    public class Config
    {
        class Transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
        }

        class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }

        }

        class BankTransferConfig
        {
            public string lang { get; set; }
            public Transfer transfer { get; set; }
            public string[] methods { get; set; }
            public Confirmation confirmation { get; set; }

            public BankTransferConfig(string lang, Transfer transfer, string[] methods, Confirmation confirmation)
            {
                this.lang = lang;
                this.transfer = transfer;
                this.methods = methods;
                this.confirmation = confirmation;


            }
        }

        public Config config;
        private const string filePath = "bank_transfer_config.json";

        private Config ReadConfig()
        {
            string jsonString = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Config>(jsonString);
            return config;
        }



        private void WriteConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void SetDefault()
        {
            config = new Config();
            
        }

        public void UIConfig()
        {
            try
            {
                ReadConfig();
            }
            catch (Exception)
            {
                SetDefault();
                WriteConfig();
            }
        }


    }

      
}


 
