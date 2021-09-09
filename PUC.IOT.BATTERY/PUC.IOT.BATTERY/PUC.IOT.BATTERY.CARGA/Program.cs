using System;
using System.Collections.Generic;
using System.Threading;

namespace PUC.IOT.BATTERY.CARGA
{
    class Program
    {
        static void Main(string[] args)
        {

            int bateria1 = 90;
            int bateria2 = 70;
            int bateria3 = 60;
            int bateria4 = 20;

            Plugin.Battery.Abstractions.BatteryStatus stbateria = Plugin.Battery.Abstractions.BatteryStatus.NotCharging;
            Plugin.Battery.Abstractions.BatteryStatus stbateria2 = Plugin.Battery.Abstractions.BatteryStatus.NotCharging;
            Plugin.Battery.Abstractions.BatteryStatus stbateria3 = Plugin.Battery.Abstractions.BatteryStatus.NotCharging;
            Plugin.Battery.Abstractions.BatteryStatus stbateria4 = Plugin.Battery.Abstractions.BatteryStatus.Charging;

            BatteryService service = new BatteryService();

            List<Battery> statusBatery = new List<Battery>();

            for (int i = 0; i < 20; i++)
            {
                bateria1 -= 5;
                bateria2 -= 5;
                bateria3 -= 5;
                bateria4 += 5;

                statusBatery.Add(new Battery()
                {
                    BatteryStatus = stbateria,
                    data = DateTime.Now,
                    dispositivo = "001",
                    percentual = bateria1,
                    versao = i
                });

                statusBatery.Add(new Battery()
                {
                    BatteryStatus = stbateria2,
                    data = DateTime.Now,
                    dispositivo = "002",
                    percentual = bateria2,
                    versao = i
                });

                statusBatery.Add(new Battery()
                {
                    BatteryStatus = stbateria3,
                    data = DateTime.Now,
                    dispositivo = "003",
                    percentual = bateria3,
                    versao = i
                });

                statusBatery.Add(new Battery()
                {
                    BatteryStatus = stbateria4,
                    data = DateTime.Now,
                    dispositivo = "004",
                    percentual = bateria4,
                    versao = i
                });

                service.PostStatus(statusBatery);

                Thread.Sleep(90000);
            }

            Console.WriteLine("Concluido");
        }
    }
}