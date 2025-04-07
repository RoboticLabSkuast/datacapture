using datacapture.model;
using datacapture.services;

namespace datacapture;

public partial class RegistrationPage : ContentPage
{
    
   
 
    public RegistrationPage()
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
        TreeId.Text = App.treeidqr;
    }
    



    private async void uploadclicked(object sender, EventArgs e)
    {
       
        if (string.IsNullOrEmpty(TreeId.Text))
        {
            await DisplayAlert("No Tree ID", "Please scan the id first.", "OK");
            return;
        }
        if  (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {

            
            await DisplayAlert("No Internet", "Please connect to the Internet", "OK");
        }
        else
        {
           
            Tree tree = new Tree
            {
                TreeId = TreeId.Text,
                Variety = VarietyEntry.Text,
                RootstockType = RootstockTypeEntry.Text,
                PlantAge = PlantAgeEntry.Text,
                Location = LocationEntry.Text,
                GPSCoordinates = GPSCoordinatesEntry.Text,
                Region = RegionEntry.Text,
                OrchardName = OrchardNameEntry.Text,
                RowColumnPosition = RowColumnPositionEntry.Text,
                Ownership = OwnershipEntry.Text,
                PlantSource = PlantSourceEntry.Text,
                PlantStatus = PlantStatusEntry.Text,
                CanopySize = CanopySizeEntry.Text,
                TreeHeight = TreeHeightEntry.Text,
                TrunkDiameter = TrunkDiameterEntry.Text,
                SpacingBetweenPlants = SpacingBetweenPlantsEntry.Text,
                GraftingDate = GraftingDatePicker.Date,
                PlantingDate = PlantingDatePicker.Date
            };

         
        }

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
    public async void GetCurrentLocationAsync(object sender, EventArgs e)
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();

            if (location == null)
            {
                // Force a fresh location if none cached
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.High,
                    Timeout = TimeSpan.FromSeconds(10)
                });
            }

            if (location != null)
            {
                GPSCoordinatesEntry.Text=$"Latitude: {location.Latitude}, Longitude: {location.Longitude}";
               
            }
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlert("Error","GPS not supported on this device.","OK");
        }
        catch (FeatureNotEnabledException)
        {
            await DisplayAlert("Error", "Location is disabled.", "OK");
        }
        catch (PermissionException)
        {
            await DisplayAlert("Error", "Location permission not granted.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Unexpected error: {ex.Message}", "OK");
        }

       
    }


}