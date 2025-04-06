using System.Text.Json;

namespace datacapture
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
        public void OnLogoutClicked(object sender, EventArgs e)
        {
            File.WriteAllText(App.saveornotpath, JsonSerializer.Serialize("2"));
            Application.Current.MainPage = new LoginPage();

        }
    }
}
