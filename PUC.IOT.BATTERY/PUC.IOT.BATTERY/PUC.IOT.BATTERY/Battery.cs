using Newtonsoft.Json;
using Plugin.Battery.Abstractions;
using System;

namespace PUC.IOT.BATTERY
{
    [Serializable]
    public  class Battery
    {
       public string dispositivo { get; set; }
        public int percentual { get; set; }
        [JsonIgnore]
        public BatteryStatus BatteryStatus { get; set; }
        public DateTime data { get; set; }


        public string status
        {
            get
            {
                string status = "";
                switch (BatteryStatus)
                {
                    case BatteryStatus.Charging:
                        status = "Carregando";
                        break;
                    case BatteryStatus.Discharging:
                        status = "Descarregando";
                        break;
                    case BatteryStatus.Full:
                        status = "Cheia";
                        break;
                    case BatteryStatus.NotCharging:
                        status = "Não está carregando";
                        break;
                    case BatteryStatus.Unknown:
                        status = "Desconhecido";
                        break;
                }

                return status;
            }
        }
    }
}
