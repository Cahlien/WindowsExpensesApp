using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpensesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExpensePage : ContentPage
    {
        public NewExpenseViewModel ViewModel { get; set; }
        public NewExpensePage()
        {
            InitializeComponent();

            ViewModel = Resources["NewExpenseViewModel"] as NewExpenseViewModel;
        }
    }
}