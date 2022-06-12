using System.IO;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Environment = System.Environment;

namespace ExpensesApp.Droid;

[Activity(Label = "ExpensesApp", Theme = "@style/MainTheme", MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
public class MainActivity : FormsAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        TabLayoutResource = Resource.Layout.Tabbar;
        ToolbarResource = Resource.Layout.Toolbar;

        base.OnCreate(savedInstanceState);
        Forms.Init(this, savedInstanceState);

        var dbName = "expenses_db.db3";
        var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        var fullPath = Path.Combine(folderPath, dbName);

        LoadApplication(new App(fullPath));
    }
}