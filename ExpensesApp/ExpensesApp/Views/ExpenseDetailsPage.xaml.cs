using ExpensesApp.Models;
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
        }
    }
}