using datacapture.services;

namespace datacapture;

public partial class RegistrationPage : ContentPage
{
    private Datalist datalist;
    private readonly DatabaseService _databaseService;
    private FileResult _imageFile;
    private byte[] _imageData;
    public RegistrationPage(DatabaseService databaseService)
	{
		InitializeComponent();
        _databaseService = databaseService;
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
    private async Task<byte[]> ConvertPhotoToByteArray(FileResult photo)
    {
        if (photo == null)
            return null;

        using var stream = await photo.OpenReadAsync(); // Open the file stream
        using var memoryStream = new MemoryStream(); // Create a memory stream
        await stream.CopyToAsync(memoryStream); // Copy the file stream to the memory stream
        return memoryStream.ToArray(); // Convert the memory stream to a byte array
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

        datalist.Name = App.treeidqr;
        datalist.ImageData = _imageData;
        datalist.ImageName = imageNameLabel.Text;
        await _databaseService.SaveDatalistAsync(datalist);


        await DisplayAlert("Success", "Image stored on device successfully!", "OK");
        /*
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
         */
    }
    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {

    }
}