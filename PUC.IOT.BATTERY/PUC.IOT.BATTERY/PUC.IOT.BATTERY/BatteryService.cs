using Newtonsoft.Json;
using Plugin.Battery;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PUC.IOT.BATTERY
{
    public class BatteryService
    {
        private Battery battery = new Battery();

        private string serviceURL = "";
        private string deviceName = "";

        public BatteryService()
        {
            serviceURL = AppSettingsManager.Settings["Service"];
            deviceName = AppSettingsManager.Settings["DeviceName"];
        }

        public Battery UpdateStatus()
        {
            if (CrossBattery.IsSupported)
            {
                battery.dispositivo = deviceName;
                battery.percentual = CrossBattery.Current.RemainingChargePercent;
                battery.BatteryStatus = CrossBattery.Current.Status;
                battery.data = DateTime.Now;

                List<Battery> statusBatery = new List<Battery>();
                statusBatery.Add(battery);
                PostStatus(statusBatery);
            }

            return battery;
        }

        private void PostStatus(List<Battery> statusBatery)
        {
            try
            {

                var client = new RestClient(serviceURL);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "text/plain");

                string jsonString = JsonConvert.SerializeObject(statusBatery);
                request.AddParameter("text/plain", jsonString, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Message: {0} StackTrace: {1}", ex.Message, ex.StackTrace));
            }

        }
    }
}
