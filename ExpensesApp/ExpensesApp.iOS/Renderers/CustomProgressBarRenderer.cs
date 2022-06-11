using CoreGraphics;
using ExpensesApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBarRenderer))]
namespace ExpensesApp.iOS.Renderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            float x = 1.0f;
            float y = 4.0f;
            
            CGAffineTransform transform = CGAffineTransform.MakeScale(x, y);
            Transform = transform;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement.Progress < .3)
            {
                Control.ProgressTintColor = Color.Lime.ToUIColor();
            }
            else if (e.NewElement.Progress < .6)
            {
                Control.ProgressTintColor = Color.Yellow.ToUIColor();
            }
            else if (e.NewElement.Progress < .9)
            {
                Control.ProgressTintColor = Color.Orange.ToUIColor();
            }
            else
            {
                Control.ProgressTintColor = Color.Red.ToUIColor();
            }

            LayoutSubviews();
        }
    }
}