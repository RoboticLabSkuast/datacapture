namespace datacapture
{
    public partial class App : Application
    {
        public static string treeidqr = "";
        public static string saveornotpath = FileSystem.Current.CacheDirectory + "saveornot";
        public static string username = "";
       
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoadingPage()); ;
        }
    }
}
