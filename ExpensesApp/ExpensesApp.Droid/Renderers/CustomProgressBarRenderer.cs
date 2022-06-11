using Android.Content;
using ExpensesApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBarRenderer))]
namespace ExpensesApp.Droid.Renderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        public CustomProgressBarRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);
            // Control.ProgressDrawable.Set
            if (double.IsNaN(e.NewElement.Progress) || e.NewElement.Progress < 0.1)
            {
               Control.ProgressDrawable.SetTint(Color.DarkGray.ToAndroid());
            }
            else if (e.NewElement.Progress < .3)
            { 
                Control.ProgressDrawable.SetTint(Color.Lime.ToAndroid());
            }
            else if (e.NewElement.Progress < .6)
            {
                Control.ProgressDrawable.SetTint(Color.Yellow.ToAndroid());
            }
            else if (e.NewElement.Progress < .9)
            {
                Control.ProgressDrawable.SetTint(Color.Orange.ToAndroid());
            }
            else
            {
                Control.ProgressDrawable.SetTint(Color.Red.ToAndroid());
            }

            Control.ScaleY = 4.0f;
        }
    }
}