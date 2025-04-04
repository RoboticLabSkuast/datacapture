

using System.Text.Json;

namespace datacapture;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        
        BindingContext = this;
    }

    private async void Login_Handler(object sender, EventArgs e)
    {
        File.Delete(App.saveornotpath);
        errorMessage.IsVisible = false;

        if (string.IsNullOrWhiteSpace(username.Text))
        {
            ShowError("Please enter a username or email");
            return;
        }

        if (string.IsNullOrWhiteSpace(password.Text))
        {
            ShowError("Please enter a password");
            return;
        }

        if (password.Text.Length < 8)
        {
            ShowError("Password must be at least 8 characters long");
            return;
        }

        try
        {
           
           
                File.WriteAllText(App.saveornotpath, JsonSerializer.Serialize("1"));
                Application.Current.MainPage = new AppShell();
           
           
        }
        catch (Exception ex)
        {
            ShowError($"Login failed: {ex.Message}");
        }
        finally
        {
            loginButton.Text = "Sign In";
            loginButton.IsEnabled = true;
            File.WriteAllText(App.saveornotpath, JsonSerializer.Serialize("2"));
        }
    }

    private void ShowError(string message)
    {
        errorMessage.Text = message;
        errorMessage.IsVisible = true;
    }

    private void OnUsernameTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateLoginButtonState();
    }

    private void OnPasswordTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateLoginButtonState();
    }

    private void UpdateLoginButtonState()
    {
        loginButton.IsEnabled = !string.IsNullOrWhiteSpace(username.Text) &&
                              !string.IsNullOrWhiteSpace(password.Text);
    }

    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        // Add your forgot password logic here
        await DisplayAlert("Forgot Password", "Forgot password functionality to be implemented", "OK");
        // Example: await Navigation.PushAsync(new ForgotPasswordPage());
    }

    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        // Add your registration logic here
        await DisplayAlert("Register", "Registration functionality to be implemented", "OK");
        // Example: await Navigation.PushAsync(new RegistrationPage());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        username.TextChanged += OnUsernameTextChanged;
        password.TextChanged += OnPasswordTextChanged;
    }

    protected override void OnDisappearing()
    {
        username.TextChanged -= OnUsernameTextChanged;
        password.TextChanged -= OnPasswordTextChanged;
        base.OnDisappearing();
    }

    /* async private void login_handler(object sender, EventArgs e)
     {
         File.Delete(App.saveornotpath);
         if ((username.Text ==null) & (password.Text == null))
         {
             await DisplayAlert("Error", "No username or password", "ok");
         }
         else
         {
             File.WriteAllText(App.saveornotpath, JsonSerializer.Serialize("1"));
             Application.Current.MainPage = new AppShell();
         }
         File.WriteAllText(App.saveornotpath, JsonSerializer.Serialize("2"));
     }*/
}