

using datacapture.services;
using System.Text.Json;

namespace datacapture;

public partial class LoginPage : ContentPage
{
    public Serverservice service;

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

        if (password.Text.Length < 2)
        {
            ShowError("Password must be at least 8 characters long");
            return;
        }

        try
        {
            service = new Serverservice();
             string temp= await service.LoginAsync(username.Text, password.Text);
            if(temp == "fail")
            {
                ShowError("Invalid username or password");
                return;
            }
            else if (temp == "success")
            {
                App.username = username.Text;
               
            }
            else
            {
                ShowError("Login failed: " + temp);
                return;
            }
            if (rememberMe.IsChecked)
            {
                File.WriteAllText(App.saveornotpath, JsonSerializer.Serialize("1"));
            }
            else { File.WriteAllText(App.saveornotpath, JsonSerializer.Serialize("2")); }



            Application.Current.MainPage = new AppShell();
           
           
        }
        catch (Exception ex)
        {
            ShowError($"Login failed: {ex.Message}");
            File.WriteAllText(App.saveornotpath, JsonSerializer.Serialize("2"));
        }
        finally
        {
            loginButton.Text = "Sign In";
            loginButton.IsEnabled = true;
           
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

   
}