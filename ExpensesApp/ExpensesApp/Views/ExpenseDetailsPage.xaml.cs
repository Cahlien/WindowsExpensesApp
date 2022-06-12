using ExpensesApp.Models;
using ExpensesApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseDetailsPage
    {
        public ExpenseDetailsPage()
        {
            InitializeComponent();
        }

        public ExpenseDetailsPage(Expense selectedExpense)
        {
            InitializeComponent();
            ViewModel = Resources["ExpenseDetailsViewModel"] as ExpenseDetailsViewModel;
            if (ViewModel != null) ViewModel.Expense = selectedExpense;
        }


        public ExpenseDetailsViewModel ViewModel { get; set; }
    }
}