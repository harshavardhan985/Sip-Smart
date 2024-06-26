using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SipSmart
{	
	public partial class GoalPage : ContentPage
	{	
		public GoalPage ()
		{
			InitializeComponent ();
		}

        private void OnGoal1SwitchToggled(object sender, ToggledEventArgs e)
        {
            bool isGoal1Enabled = e.Value;
            // Perform actions based on the state of Goal 1 switch
        }

        private void OnGoal2SwitchToggled(object sender, ToggledEventArgs e)
        {
            bool isGoal2Enabled = e.Value;
            // Perform actions based on the state of Goal 2 switch
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new HomePage();
        }
    }
}

