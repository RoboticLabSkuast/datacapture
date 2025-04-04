
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
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Refresh your UI or data here
            TreeIdEntry.Text = App.treeidqr;
        }


    }

}
