using BarcodeScanner.Mobile;

namespace barcodee
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BarcodeScanner.Mobile.Methods.AskForRequiredPermission();
        }

        private void Camera_OnDetected(object sender, BarcodeScanner.Mobile.OnDetectedEventArg e)
        {
            List<BarcodeResult> obj = e.BarcodeResults;

            string result = string.Empty;
            for (int i = 0; i < obj.Count; i++)
            {
                result += $"Type : {obj[i].BarcodeType},Value : {obj[i].DisplayValue}{Environment.NewLine}";
            }
            Dispatcher.Dispatch(async () =>
            {
                await DisplayAlert("Result", result, "OK");
                Camera.IsScanning = true;

            });






        }
    }

}
