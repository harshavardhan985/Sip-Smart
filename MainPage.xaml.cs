using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SipSmart
{
    public partial class MainPage : ContentPage
    {
        public class AuthenticationService
        {
            // Assuming a simple property to track completion
            public static bool IsBehaviorPageCompleted { get; set; } = false;

            // Other authentication-related methods...
        }
        public MainPage()
        {
            InitializeComponent();
            if (AuthenticationService.IsBehaviorPageCompleted)
            {
                Application.Current.MainPage = new HomePage();
            }
            else
            {
                Application.Current.MainPage = new BehaviourPage();
            }
        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Add your authentication logic here
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // Check the credentials and navigate accordingly
            if (IsValidUser(username, password))
            {
                // Navigate to the home page
                Application.Current.MainPage = new HomePage();
            }
            else
            {
                DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        private bool IsValidUser(string username, string password)
        {
            // Add your authentication logic here
            // This is a placeholder. Replace it with your actual authentication logic.
            // For simplicity, here we assume any non-empty username/password is valid
            return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
        }

        private void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the sign-up page
            Application.Current.MainPage = new SignUpPage();
        }

        private void OnForgotPasswordButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the forgot password page
            Application.Current.MainPage = new ForgotPasswordPage();
        }
    }
}
