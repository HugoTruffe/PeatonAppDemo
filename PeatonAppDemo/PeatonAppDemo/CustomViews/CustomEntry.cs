using System;
using Xamarin.Forms;

namespace PeatonAppDemo
{
	public class CustomEntry : Entry
	{
		public CustomEntry()
		{
		}


		public static BindableProperty BorderWidthProperty = BindableProperty.Create(
			  "BorderWidth",
			  typeof(Thickness),
			  typeof(CustomEntry),
			  default(Thickness));

		public Thickness BorderWidth
		{
			get { return (Thickness)GetValue(BorderWidthProperty); }
			set { SetValue(BorderWidthProperty, value); }
		}



		public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
			"BorderColor",
			typeof(Color),
			typeof(CustomEntry),
			Color.White);

		/// <summary>
		/// Gets or sets the color of the border.
		/// </summary>
		/// <value>The color of the border.</value>
		public Color BorderColor
		{
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}
	}
}
