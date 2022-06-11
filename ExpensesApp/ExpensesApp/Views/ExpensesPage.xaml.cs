using System.Windows.Input;
using ExpensesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesPage : ContentPage
    {
        public ExpensesPage()
        {
            InitializeComponent();
            ExpensesViewModel = Resources["ExpensesViewModel"] as ExpensesViewModel;
            BindingContext = this;
        }

        public ExpensesViewModel ExpensesViewModel { get; set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ExpensesViewModel.GetExpenses();
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ExpensesViewModel.FilterAndSortExpenses();
        }
    }
}