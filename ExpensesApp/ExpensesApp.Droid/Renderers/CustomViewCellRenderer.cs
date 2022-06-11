using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using ExpensesApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]
namespace ExpensesApp.Droid.Renderers
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        private View _cell;
        private bool _isSelected;
        private Drawable _defaultBackground;
        
        protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
        {
            _cell = base.GetCellCore(item, convertView, parent, context);

            _isSelected = false;
            _defaultBackground = _cell.Background;
            _cell.SetBackgroundColor(Color.Transparent);
            
            return _cell;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);

            if (e.PropertyName == "IsSelected")
            {
                _isSelected = !_isSelected;

                if (_isSelected)
                {
                    _cell.SetBackgroundColor(Color.LightGray);
                }
                else
                {
                    _cell.SetBackgroundColor(Color.Transparent);
                }
            }
        }
    }
}