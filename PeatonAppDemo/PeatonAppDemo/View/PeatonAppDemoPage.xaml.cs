using Xamarin.Forms;

namespace PeatonAppDemo
{
	public partial class PeatonAppDemoPage : ContentPage
	{
		public PeatonAppDemoPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, true);
			this.BindingContext = new PeatonAppDemoVM();

			Modal.Clicked += Modal_Clicked;
			NextButton.Clicked += NextButton_Clicked;
		}


		void Modal_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushModalAsync(new ModalPage());
		}

		void NextButton_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new SecondPage());
		}
	}
}
