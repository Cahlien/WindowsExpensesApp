using ExpensesApp.iOS.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("DevelopersCrowell")]
[assembly: ExportEffect(typeof(SelectedEffect), "SelectedEffect")]

namespace ExpensesApp.iOS.Effects
{
    public class SelectedEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
        }

        protected override void OnDetached()
        {
        }
    }
}