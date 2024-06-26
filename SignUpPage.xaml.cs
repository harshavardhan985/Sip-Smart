using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;
namespace SipSmart
{	
	public partial class SignUpPage : ContentPage
	{	
		public SignUpPage ()
		{
			InitializeComponent ();
		}
        private void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            // Add your signup logic here
            string fullName = FullNameEntry.Text;
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            // Check if signup is successful (add your logic here)
            if (IsSignUpSuccessful(fullName, email, password))
            {
                // Navigate to the login page upon successful signup
                Navigation.PushAsync(new HomePage());
            }
            else
            {
                DisplayAlert("Error", "Failed to sign up. Please check your entries.", "OK");
            }
        }

        private bool IsSignUpSuccessful(string fullName, string email, string password)
        {
            // Add your signup logic here
            // This is a placeholder. Replace it with your actual signup logic.
            // For simplicity, here we assume any non-empty fields result in successful signup
            return !string.IsNullOrWhiteSpace(fullName)
                && IsEmailValid(email)
                && IsPasswordValid(password);
        }

        private bool IsEmailValid(string email)
        {
            // Email validation logic
            // Using a simple regex pattern for demonstration
            const string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsPasswordValid(string password)
        {
            // Password validation logic
            // Minimum length of 8 characters
            // At least one number and one special character
            return password.Length >= 8
                && password.Any(char.IsDigit)
                && password.Any(ch => !char.IsLetterOrDigit(ch));
        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the login page
            Application.Current.MainPage = new MainPage();
        }
    }
}

