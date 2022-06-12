using System;
using System.ComponentModel;
using Android.Graphics.Drawables;
using ExpensesApp.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ResolutionGroupName("DevelopersCrowell")]
[assembly: ExportEffect(typeof(SelectedEffect), "SelectedEffect")]

namespace ExpensesApp.Droid.Effects;

public class SelectedEffect : PlatformEffect
{
    private Color _selectedColor;

    protected override void OnAttached()
    {
        _selectedColor = new Color(176, 152, 164);
    }

    protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
    {
        base.OnElementPropertyChanged(args);

        try
        {
            if (args.PropertyName == "IsFocused")
            {
                if (Control.Background != null && ((ColorDrawable) Control.Background).Color != _selectedColor)
                    Control.SetBackgroundColor(_selectedColor);
                else
                    Control.SetBackgroundColor(Color.White);
            }
        }
        catch (InvalidCastException)
        {
            Control.SetBackgroundColor(_selectedColor);
        }
    }

    protected override void OnDetached()
    {
    }
}