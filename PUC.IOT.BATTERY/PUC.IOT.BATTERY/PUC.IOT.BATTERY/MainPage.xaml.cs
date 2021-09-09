using System.Threading.Tasks;
using Xamarin.Forms;

namespace PUC.IOT.BATTERY
{
    public partial class MainPage : ContentPage
    {

        private const int DelayDefault = 1000;
        private int Delay = 0;
        private BatteryService batteryService;
        private Battery battery;

        public MainPage()
        {
            InitializeComponent();
            LoadParameters();
            CheckStatus();
        }

        private void LoadParameters()
        {
            batteryService = new BatteryService();
            battery = new Battery();

            if (!int.TryParse(AppSettingsManager.Settings["Delay"], out Delay))
                Delay = DelayDefault;
        }

        private void CheckStatus()
        {

            battery = batteryService.UpdateStatus();

            UpdateInfo();

            CheckStatusTaskDelay();
        }


        private void UpdateInfo()
        {
            lblDeviceName.Text = $"Dispositivo : {battery.dispositivo}";
            lblChargeLevel.Text = $"Bateria : {battery.percentual.ToString()}";
            lblStatus.Text = $"Status : {battery.status}";
            lblLastUpdate.Text = $"Última Atualização : {battery.data.ToString("dd/MM/yyyy HH:mm:ss")}";
        }

        async Task CheckStatusTaskDelay()
        {
            await Task.Delay(Delay);
            CheckStatus();
        }

    }
}

