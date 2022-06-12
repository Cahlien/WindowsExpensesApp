using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using ExpensesApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]

namespace ExpensesApp.Droid.Renderers;

public class CustomTextCellRenderer : TextCellRenderer
{
    private View _cell;
    private Drawable _defaultBackground;
    private bool _isSelected;

    protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
    {
        _cell = base.GetCellCore(item, convertView, parent, context);
        _defaultBackground = _cell.Background;
        _isSelected = false;

        _cell.SetBackgroundColor(Color.Transparent);
        switch (item.StyleId)
        {
            case "none":
                break;
            case "checkmark":
                break;
            case "detail-button":
                break;
            case "detail-disclosure-button":
                break;
            case "disclosure":
            default:
                break;
        }

        return _cell;
    }

    protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs args)
    {
        base.OnCellPropertyChanged(sender, args);

        if (args.PropertyName == "IsSelected")
        {
            _isSelected = !_isSelected;
            if (_isSelected)
                _cell.SetBackgroundColor(Color.LightGray);
            else
                _cell.SetBackgroundColor(Color.Transparent);
        }
    }
}