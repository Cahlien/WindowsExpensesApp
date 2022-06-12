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
            ViewModel = Resources["ExpenseDetailsViewModel"] as ExpenseDetailsViewModel;
            ViewModel.Expense = selectedExpense;
        }

        public ExpenseDetailsPage()
        {
            InitializeComponent();
        }

        public ExpenseDetailsViewModel ViewModel { get; set; }
    }
}