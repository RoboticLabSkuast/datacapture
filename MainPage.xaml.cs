
using System.Net.Http.Headers;

namespace datacapture
{
    public partial class MainPage : ContentPage
    {
        private FileResult _imageFile;

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
        private async void OnTakePhotoClicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                if (photo != null)
                {
                    _imageFile = photo;
                    imageNameLabel.Text = photo.FileName;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Camera error: {ex.Message}", "OK");
            }
        }
        private async void uploadclicked(object sender, EventArgs e)
        {
            if (_imageFile == null)
            {
                await DisplayAlert("No Image", "Please select or take a photo first.", "OK");
                return;
            }

            using var content = new MultipartFormDataContent();
            using var stream = await _imageFile.OpenReadAsync();
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

            content.Add(fileContent, "file", _imageFile.FileName);

            using var client = new HttpClient();
            var response = await client.PostAsync("https://yourserver.com/api/upload", content);

            if (response.IsSuccessStatusCode)
                await DisplayAlert("Success", "Image uploaded successfully!", "OK");
            else
                await DisplayAlert("Error", "Upload failed.", "OK");
        }
        private void OnPickerSelectedIndexChanged(object sender,EventArgs e)
        {

        }


    }

}
