using System.Threading.Tasks;
using Android.Content;
using AndroidX.Core.Content;
using ExpensesApp.Droid.Shared;
using ExpensesApp.Shared;
using Java.IO;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(Share))]

namespace ExpensesApp.Droid.Shared;

public class Share : IShare
{
    public Task Show(string title, string message, string filePath)
    {
        var intent = new Intent(Intent.ActionSend);
        intent.SetType("text/plain");
        var documentUri = FileProvider.GetUriForFile(Forms.Context.ApplicationContext,
            "dev.crowell.ExpensesApp.provider", new File(filePath));

        intent.PutExtra(Intent.ExtraStream, documentUri);
        intent.PutExtra(Intent.ExtraText, title);
        intent.PutExtra(Intent.ExtraText, message);
        var chooserIntent = Intent.CreateChooser(intent, title);
        chooserIntent.SetFlags(ActivityFlags.GrantReadUriPermission | ActivityFlags.NewTask);
        Application.Context.StartActivity(chooserIntent);

        return Task.FromResult(true);
    }
}