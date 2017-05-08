using System;
using Xamarin.Forms;

namespace PeatonAppDemo
{
	public class PeatonAppDemoVM : ObservableBaseObject
	{

		public Command MoveNext
		{ 
			set; 
			get; 
		}

		public PeatonAppDemoVM()
		{
			MoveNext = new Command((obj) => GoToSecondPage());
		}

		private void GoToSecondPage()
		{
			throw new NotImplementedException();
		}
}
}
