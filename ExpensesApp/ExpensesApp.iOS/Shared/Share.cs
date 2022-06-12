using System.Threading.Tasks;
using ExpensesApp.iOS.Shared;
using ExpensesApp.Shared;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]

namespace ExpensesApp.iOS.Shared
{
    public class Share : IShare
    {
        public async Task Show(string title, string message, string filePath)
        {
            var viewController = GetVisibleViewController();
            var items = new NSObject[] {NSUrl.FromFilename(filePath)};
            var activityController = new UIActivityViewController(items, null);

            if (activityController.PopoverPresentationController != null)
                activityController.PopoverPresentationController.SourceView = viewController.View;

            await viewController.PresentViewControllerAsync(activityController, true);
        }

        private UIViewController GetVisibleViewController()
        {
            var rootViewController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            if (rootViewController.PresentedViewController == null)
                return rootViewController;

            if (rootViewController.PresentedViewController is UINavigationController)
                return rootViewController.PresentedViewController;

            if (rootViewController.PresentedViewController is UITabBarController)
                return (UITabBarController) rootViewController.PresentedViewController;

            return rootViewController.PresentedViewController;
        }
    }
}