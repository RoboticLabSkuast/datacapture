
namespace datacapture
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
           
        }
        private async void OnScanQrCodeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Qrcode());

        }

    }

}
