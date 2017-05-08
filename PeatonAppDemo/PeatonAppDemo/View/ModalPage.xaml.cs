using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PeatonAppDemo
{
	public partial class ModalPage : ContentPage
	{
		public ModalPage()
		{
			Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
			{
				{ "Aqua", Color.Aqua }, { "Black", Color.Black },
				{ "Blue", Color.Blue }, { "Fucshia", Color.Fuchsia },
				{ "Gray", Color.Gray }, { "Green", Color.Green },
				{ "Lime", Color.Lime }, { "Maroon", Color.Maroon },
				{ "Navy", Color.Navy }, { "Olive", Color.Olive },
				{ "Purple", Color.Purple }, { "Red", Color.Red },
				{ "Silver", Color.Silver }, { "Teal", Color.Teal },
				{ "White", Color.White }, { "Yellow", Color.Yellow  }
			};
			InitializeComponent();

			foreach (string colorName in nameToColor.Keys)
            {
				ProviciasPicker.Items.Add(colorName);
            }

			BackButton.Clicked += BackButton_Clicked;
		}

		void BackButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync(true);
		}
	}
}
