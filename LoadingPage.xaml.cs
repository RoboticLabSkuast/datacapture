using System.Text.Json;

namespace datacapture;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
		InitializeComponent();
		checksaveddata();
	}
	private async void checksaveddata()
	{
        try
        {

            string check = JsonSerializer.Deserialize<string>(File.ReadAllText(App.saveornotpath));
            if (check.Equals("1"))
            {
                await Task.Delay(100);
                Application.Current.MainPage = new AppShell();

            }
            else
            {
             
                await Navigation.PushAsync(new LoginPage());

            }
        }
        catch
        {
         
            await Navigation.PushAsync(new LoginPage());

        }
    }

}