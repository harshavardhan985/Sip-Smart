using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static SipSmart.App;

namespace SipSmart
{	
	public partial class BehaviourPage : ContentPage
	{	
		public BehaviourPage ()
		{
			InitializeComponent ();
		}

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            // Get selected choices from each picker
            string frequencyChoice = (string)frequencyPicker.SelectedItem;
            string quantityChoice = (string)quantityPicker.SelectedItem;
            string contextChoice = (string)contextPicker.SelectedItem;
            string purposeChoice = (string)purposePicker.SelectedItem;
            string impactChoice = (string)impactPicker.SelectedItem;
            MainPage.AuthenticationService.IsBehaviorPageCompleted = true;
            Application.Current.MainPage = new GoalPage();

        }
    }
}

