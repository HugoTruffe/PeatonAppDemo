using System;
using System.Collections.Generic;
using System.Linq;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using PeatonAppDemo;
using PeatonAppDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace PeatonAppDemo.Droid
{
	public class CustomEntryRenderer : EntryRenderer
	{
		CustomEntry _customEntry;

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				_customEntry = (CustomEntry)e.NewElement;

				SetBorder(_customEntry);

			}


		}


		private void SetBorder(CustomEntry customEntry)
		{
			double maxValueBorder = GetMaxValue(customEntry.BorderWidth);

			if (maxValueBorder > 0)
			{
				RectShape rectShape = new RectShape();

				ShapeDrawable drawable = new ShapeDrawable(rectShape);

				drawable.Paint.Color = customEntry.BorderColor.ToAndroid();
				drawable.Paint.StrokeWidth = (float)maxValueBorder;
				drawable.Paint.SetStyle(Paint.Style.Stroke);

				Drawable[] layers = { drawable };
				var layerDrawable = new LayerDrawable(layers);

				layerDrawable.SetLayerInset(0, (int)(customEntry.BorderWidth.Left - maxValueBorder),
				   (int)(customEntry.BorderWidth.Top - maxValueBorder),
				   (int)(customEntry.BorderWidth.Right - maxValueBorder),
				   (int)(customEntry.BorderWidth.Bottom - maxValueBorder));

				#pragma warning disable 612, 618
				Control.SetBackgroundDrawable(layerDrawable);
				#pragma warning restore 612, 618
			}
			else
			{
				RectShape rectShape = new RectShape();

				ShapeDrawable drawable = new ShapeDrawable(rectShape);

				drawable.Paint.Color = customEntry.BackgroundColor.ToAndroid();
				drawable.Paint.SetStyle(Paint.Style.Fill);

				#pragma warning disable 612, 618
						Control.SetBackgroundDrawable(drawable);
				#pragma warning restore 612, 618
			}
		}

		private double GetMaxValue(Thickness thicnkess)
		{
			var valuesList = new List<double>() { thicnkess.Bottom, thicnkess.Left, thicnkess.Right, thicnkess.Top };

			return valuesList.Max();
		}

	}
}
