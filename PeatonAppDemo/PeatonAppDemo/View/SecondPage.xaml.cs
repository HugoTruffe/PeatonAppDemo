using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PeatonAppDemo
{
	public partial class SecondPage : ContentPage
	{
		public SecondPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);

			BackButtonOne.Clicked += BackButton_Clicked;
			BackButtonTwo.Clicked += BackButton_Clicked;
			BackButtonThree.Clicked += BackButton_Clicked;
		}

		void BackButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopAsync(true);
		}
	}
}
