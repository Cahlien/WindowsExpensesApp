using ExpensesApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage
    {
        public CategoriesPage()
        {
            InitializeComponent();
            CategoriesViewModel = Resources["CategoriesViewModel"] as CategoriesViewModel;
        }

        public CategoriesViewModel CategoriesViewModel { get; set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CategoriesViewModel.GetExpensesPerCategory();
        }
    }
}