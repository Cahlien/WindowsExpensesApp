using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using ExpensesApp.Models;
using ExpensesApp.Views;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class ExpensesViewModel 
    {
        public ExpensesViewModel()
        {
            Expenses = new ObservableCollection<Expense>();
            AddExpenseCommand = new Command(AddExpense);
            OpenSortPageCommand = new Command(OpenSortPage);
            CloseSortPageCommand = new Command(CloseSortPage);
            GetExpenses();
            FilteredAndSortedExpenses = new ObservableCollection<Expense>(Expenses);
            FilterAndSortExpenses();
        }
        

        public ObservableCollection<Expense> Expenses { get; set; }
        public ICommand AddExpenseCommand { get; set; }
        public ICommand OpenSortPageCommand { get; set; }
        public ICommand CloseSortPageCommand { get; set; }
        public ObservableCollection<Expense> FilteredAndSortedExpenses { get; set; }
        public string FilterString { get; set; }
        public string Orderby { get; set; }
        public string OrderDirection { get; set; }

        private async void OpenSortPage()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SortPage());
        }

        private async void CloseSortPage()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
        
        public void GetExpenses()
        {
            var expenses = Expense.GetExpenses();

            Expenses.Clear();

            foreach (var expense in expenses) Expenses.Add(expense);
        }

        public void AddExpense()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewExpensePage());
        }

        public void FilterAndSortExpenses()
        {
            if (FilterString == null) return;
            var filterTerms = FilterString.ToLowerInvariant().Split(' ');
            if (filterTerms.Any())
            {
                FilteredAndSortedExpenses.Clear();
                IEnumerable<Expense> filteredExpenses = null;

                foreach (var term in filterTerms)
                {
                    var floatString = float.TryParse(term, NumberStyles.Any, CultureInfo.CurrentCulture,
                        out var outFloat);

                    var dateString = DateTime.TryParse(term, CultureInfo.CurrentCulture,
                        DateTimeStyles.None, out var outDate);

                    if (floatString || dateString)
                        filteredExpenses = Expenses.Where(expense =>
                            expense.Name.ToLowerInvariant().Contains(term.ToLowerInvariant()) ||
                            expense.Description.ToLowerInvariant().Contains(term.ToLowerInvariant()) ||
                            expense.Category.ToLowerInvariant().Contains(term.ToLowerInvariant()) ||
                            floatString
                                ? Math.Abs(expense.Amount - outFloat) < 0.001
                                : expense.Date.Date.Equals(outDate.Date));
                    else
                        filteredExpenses = Expenses.Where(expense =>
                            expense.Name.ToLowerInvariant().Contains(term.ToLowerInvariant()) ||
                            expense.Description.ToLowerInvariant().Contains(term.ToLowerInvariant()) ||
                            expense.Category.ToLowerInvariant().Contains(term.ToLowerInvariant()));
                }

                foreach (var expense in filteredExpenses) FilteredAndSortedExpenses.Add(expense);
            }
        }
    }
}