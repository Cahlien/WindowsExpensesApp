using ExpensesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        public CategoriesViewModel CategoriesViewModel { get; set; }
        
        public CategoriesPage()
        {
            InitializeComponent();
            CategoriesViewModel = Resources["CategoriesViewModel"] as CategoriesViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.CategoriesViewModel.GetExpensesPerCategory();
        }
    }
}