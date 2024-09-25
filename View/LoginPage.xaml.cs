using Microsoft.Maui.Controls;
using System;
using Module0Exercise0.View;
using Module0Exercise0.Services;

namespace Module0Exercise0.View
{
    public partial class LoginPage : ContentPage
    {
        private readonly IMyservice _myService; //Field for the service 

        public LoginPage(IMyservice myService)
        {
            InitializeComponent();
            _myService = myService ?? throw new ArgumentNullException(nameof(myService)); // Defensive programming

            var message = _myService.GetMessage();
            MyLabel.Text = message;
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            // Simple validation (this can be replaced with actual authentication logic)
            if (username == "admin" && password == "password")
            {
                // Navigate using Shell
                await Shell.Current.GoToAsync("//EmployeePage");
            }
            else
            {
                await DisplayAlert("Login Failed", "Incorrect username or password.", "OK");
            }
        }
    }
}

