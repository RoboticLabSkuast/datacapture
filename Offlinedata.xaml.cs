using datacapture.services;

namespace datacapture;

public partial class Offlinedata : ContentPage
{
    private readonly DatabaseService _databaseService;
   
    public Offlinedata(DatabaseService databaseService)
	{
		InitializeComponent();
        _databaseService = databaseService;
        LoadItems();
    }
    private async void LoadItems()
    {
      
        try
        {
            List<Datalist> items = await _databaseService.GetAllListsAsync();
            ItemsListView.ItemsSource = items;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load items: {ex.Message}", "OK");
        }
    }
    private async void uploaddatahandler(object sender, EventArgs e)
    {
        await _databaseService.ClearListsAsync();
        await DisplayAlert("Success", "Image uploaded successfully!", "OK");
        LoadItems(); // Refresh the ListView
    }
    protected override  void OnAppearing()
    {
        base.OnAppearing();
      LoadItems();
    }
}