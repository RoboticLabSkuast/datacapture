using datacapture.services;

namespace datacapture;

public partial class Offlinedata : ContentPage
{
    private readonly DatabaseService _databaseService;
   
    public Offlinedata(DatabaseService databaseService)
	{
		InitializeComponent();
        _databaseService = databaseService;
       
    }
    private async void LoadItems()
    {
      
        try
        {
            List<Datalist> items = await _databaseService.GetAllListsAsync();
            ItemsListView.ItemsSource = items;
            if (items.Count == 0)
            {
                await DisplayAlert("No Data", "No items found in the database.", "OK");
                nodata.IsVisible = true;
            }
            else
            {
                nodata.IsVisible = false;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load items: {ex.Message}", "OK");
        }
    }
    private async void uploaddatahandler(object sender, EventArgs e)
    {
        if (!nodata.IsVisible)
        {
            await _databaseService.ClearListsAsync();
            await DisplayAlert("Success", "Image uploaded successfully!", "OK");
        }
        LoadItems(); // Refresh the ListView
    }
    protected override  void OnAppearing()
    {
        base.OnAppearing();
      LoadItems();
    }
}