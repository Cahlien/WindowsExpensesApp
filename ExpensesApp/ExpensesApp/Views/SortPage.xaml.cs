using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ExpensesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SortPage : ContentPage
    {
        public SortPage()
        {
            InitializeComponent();
            ExpensesViewModel = Resources["ExpensesViewModel"] as ExpensesViewModel;
            BindingContext = this;
        }

        public ExpensesViewModel ExpensesViewModel { get; set; }
    }
}