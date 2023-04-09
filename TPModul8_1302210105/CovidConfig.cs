using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TPModul8_1302210105
{
    public class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public CovidConfig() { }
        public CovidConfig(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
        {
            this.satuan_suhu = satuan_suhu;
            this.batas_hari_demam = batas_hari_demam;
            this.pesan_ditolak = pesan_ditolak;
            this.pesan_diterima = pesan_diterima;
        }   
    }
    public class covid
    {
        public CovidConfig CovidConfig { get; set; }
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string configname = "covid_config.json";
        public covid()
        {
            try
            {
                ReadCovidConfig();
            }
            catch
            {
                SetDefault();
                WriteCovidConfig();
            }
        }
        private CovidConfig ReadCovidConfig()
        {
            string jsonFromFile = File.ReadAllText(path + '/' + configname);
            CovidConfig = JsonSerializer.Deserialize<CovidConfig>(jsonFromFile);
            return CovidConfig;
        }
        private void WriteCovidConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            String jsonString = JsonSerializer.Serialize(CovidConfig, options);
            string fullPath = path + "/" + configname;
            File.WriteAllText(fullPath, jsonString);
        }
        public void SetDefault()
        {
            CovidConfig = new CovidConfig("celcius", 14, "Anda tidak diperbolehkan masuk ke dalam gedung ini", "Anda dipersilahkan untuk masuk ke dalam gedung ini");
        }
        public void ubahsuhu()
        {
            CovidConfig.satuan_suhu = CovidConfig.satuan_suhu == "celcius" ? "fahrenheit" : "celcius";
        }
        public bool inputan(double suhu, int hariDeman)
        {
            if(CovidConfig.satuan_suhu == "celcius")
            {
                if(suhu < 36.5 || suhu > 37.5)
                {
                    return false;
                }
            }
            else if (CovidConfig.satuan_suhu == "fahrenheit")
            {
                if(suhu < 97.7 || suhu > 99.5)
                {
                    return false;
                }
            }
            if(hariDeman >= CovidConfig.batas_hari_demam)
            {
                return false;
            }
            return true;
        }
    }
}
