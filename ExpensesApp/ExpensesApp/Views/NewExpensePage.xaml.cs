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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            ViewModel.GetExpenseStatus();
            
            var section = new TableSection("Statuses");
            
            for(var i = 0; i < ViewModel.ExpenseStatuses.Count; i++)
            {
                var cell = new SwitchCell {Text = ViewModel.ExpenseStatuses[i].Name};

                Binding binding = new Binding();
                binding.Source = ViewModel.ExpenseStatuses[i];
                binding.Path = "Status";
                binding.Mode = BindingMode.TwoWay;
                
                cell.SetBinding(SwitchCell.OnProperty, binding);

                section.Add(cell);        

                
            }
            
            TableView.Root.Add(section);
        }
    }
}