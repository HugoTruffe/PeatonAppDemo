using System;
using System.ComponentModel;
using System.Drawing;
using CoreAnimation;
using PeatonAppDemo;
using PeatonAppDemo.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace PeatonAppDemo.iOS
{
	public class CustomEntryRenderer : EntryRenderer
	{
		CustomEntry _customEntry;
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement == null)
			{
				return;
			}

			_customEntry = (CustomEntry)e.NewElement;

			Control.BorderStyle = UITextBorderStyle.None;

			Control.Layer.BorderColor = UIColor.Clear.CGColor;
            Control.ClipsToBounds = true;

			SetBorder();
			SetBorderColor();


		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == CustomEntry.BorderColorProperty.PropertyName)
			{
				SetBorderColor();
			}
		}

		private void SetBorderColor()
		{
			Control.Layer.BorderColor = _customEntry.BorderColor.ToCGColor();
			Control.ClipsToBounds = true;
		}

		private void SetBorder()
		{
			var borderColor = _customEntry.BorderColor.ToCGColor();

			UIView paddingLeftView = new UIView(new RectangleF(0, 0, (float)5, (float)_customEntry.HeightRequest));
			Control.LeftView = (UIView)paddingLeftView;
            Control.LeftViewMode = UITextFieldViewMode.Always;

			if (_customEntry.BorderWidth.Top > 0)
			{
				CALayer TopBorder = new CALayer();
				TopBorder.MasksToBounds = true;
				TopBorder.Frame = new CoreGraphics.CGRect(0, 0, Frame.Width, (float)_customEntry.BorderWidth.Top);
				TopBorder.BackgroundColor = borderColor;
				Control.Layer.AddSublayer(TopBorder);
			}

			if (_customEntry.BorderWidth.Bottom > 0)
			{
				CALayer bottomBorder = new CALayer();
				bottomBorder.MasksToBounds = true;
				bottomBorder.Frame = new CoreGraphics.CGRect(0, (nfloat)_customEntry.HeightRequest - (nfloat)_customEntry.BorderWidth.Bottom, Frame.Width, (nfloat)_customEntry.BorderWidth.Bottom);
				bottomBorder.BackgroundColor = borderColor;
				Control.Layer.AddSublayer(bottomBorder);
			}

			if (_customEntry.BorderWidth.Left > 0)
			{
				CALayer leftBorder = new CALayer();
				leftBorder.MasksToBounds = true;
				leftBorder.Frame = new CoreGraphics.CGRect(0, 0, (float)_customEntry.BorderWidth.Left, (nfloat)_customEntry.HeightRequest);
				leftBorder.BackgroundColor = borderColor;
				Control.Layer.AddSublayer(leftBorder);
			}

			if (_customEntry.BorderWidth.Right > 0) {
                CALayer rightBorder = new CALayer();
				rightBorder.MasksToBounds = true;
				rightBorder.Frame = new CoreGraphics.CGRect (_customEntry.WidthRequest - (float)_customEntry.BorderWidth.Right , 0, (float)_customEntry.BorderWidth.Right, (nfloat)_customEntry.HeightRequest);
                rightBorder.BackgroundColor = borderColor;
                Control.Layer.AddSublayer (rightBorder);
            }
		}
	}
}
