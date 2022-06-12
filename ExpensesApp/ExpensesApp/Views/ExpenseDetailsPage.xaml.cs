using ExpensesApp.Models;
using ExpensesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseDetailsPage : ContentPage
    {
        public ExpenseDetailsPage(Expense selectedExpense)
        {
            InitializeComponent();
            TapGestureRecognizer = new TapGestureRecognizer();
            ViewModel = Resources["ExpenseDetailsViewModel"] as ExpenseDetailsViewModel;

                BindingContext = this;
        }

        public ExpenseDetailsViewModel ViewModel { get; set; }
        public TapGestureRecognizer TapGestureRecognizer { get; set; }

        public void OnTapped(object obj)
        {
            DisplayAlert("Tapped", "Ok", "Cancel");
        }
    }
}