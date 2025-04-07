
using datacapture.services;
using System.Net.Http.Headers;

namespace datacapture
{
    public partial class MainPage : ContentPage
    {
        private Datalist datalist;
        private readonly DatabaseService _databaseService;
        private FileResult _imageFile;
        private byte[] _imageData;
        

        public MainPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService=databaseService;
            datalist = new Datalist();

        }
        private async void OnScanQrCodeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Qrcode());
            

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Refresh your UI or data here
            TreeId.Text = App.treeidqr;
        }
        private async void OnTakePhotoClicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                if (photo != null)
                {
                    _imageFile = photo;
                    imageNameLabel.Text = photo.FileName;
                    _imageData = await ConvertPhotoToByteArray(photo);

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Camera error: {ex.Message}", "OK");
            }
        }


        private async Task<byte[]> ConvertPhotoToByteArray(FileResult photo)
        {
            if (photo == null)
                return null;

            using var stream = await photo.OpenReadAsync(); // Open the file stream
            using var memoryStream = new MemoryStream(); // Create a memory stream
            await stream.CopyToAsync(memoryStream); // Copy the file stream to the memory stream
            return memoryStream.ToArray(); // Convert the memory stream to a byte array
        }


        private async void saveofflineclicked(object sender, EventArgs e)
        {
            if (_imageFile == null)
            {
                await DisplayAlert("No Image", "Please select or take a photo first.", "OK");
                return;
            }
            if (string.IsNullOrEmpty(TreeId.Text))
            {
                await DisplayAlert("No Tree ID", "Please scan the id first.", "OK");
                return;
            }
            datalist.Name = App.treeidqr;
            datalist.ImageData = _imageData;
            datalist.ImageName = imageNameLabel.Text;
            await _databaseService.SaveDatalistAsync(datalist);
            await DisplayAlert("Success", "Image stored on device successfully!", "OK");
        }
        private async void uploadclicked(object sender, EventArgs e)
        {
            if (_imageFile == null)
            {
                await DisplayAlert("No Image", "Please select or take a photo first.", "OK");
                return;
            }
            if (string.IsNullOrEmpty(TreeId.Text))
            {
                await DisplayAlert("No Tree ID", "Please scan the id first.", "OK");
                return;
            }
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
              var result= await DisplayAlert("No Internet", "Do you want to save it on the device", "Yes","No");
                if (result)
                {
                    saveofflineclicked(sender,  e);
                }
                return;
            }


        }
        private void OnPickerSelectedIndexChanged(object sender,EventArgs e)
        {

        }
        private void phenologyTapped(object sender, EventArgs e)
        {
            phenologylist.IsVisible = !phenologylist.IsVisible;
        }
        private void ManagementTapped(object sender, EventArgs e)
        {
            managementlist.IsVisible = !managementlist.IsVisible;
        }
        private void HealthTapped(object sender, EventArgs e)
        {
            healthlist.IsVisible = !healthlist.IsVisible;   
        }
        private void yieldTapped(object sender, EventArgs e)
        {
            yeildlist.IsVisible = !yeildlist.IsVisible;
        }
        


    }

}
