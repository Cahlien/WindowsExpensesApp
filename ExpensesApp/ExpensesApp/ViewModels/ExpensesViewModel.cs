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
            Orderby = "date";
            OrderDirection = "desc";
            GetExpenses();
            FilterAndSortExpenses();
        }


        public ObservableCollection<Expense> Expenses { get; set; }
        public ICommand AddExpenseCommand { get; set; }
        public string FilterString { get; set; }
        public string Orderby { get; set; }
        public string OrderDirection { get; set; }


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
            if (FilterString != null)
            {

                var filterTerms = FilterString.ToLowerInvariant().Split(' ');
                if (filterTerms.Any())
                {
                    IEnumerable<Expense> filteredExpenses = null;

                    foreach (var term in filterTerms)
                    {
                        if (IsSortProperty(term)) continue;

                        filteredExpenses = SetFilters(term);
                    }

                    filteredExpenses = SortExpenses(filteredExpenses);
                    
                    Expenses.Clear();
                    
                    foreach (var expense in filteredExpenses) Expenses.Add(expense);
                }
            }
        }

        private IEnumerable<Expense> SortExpenses(IEnumerable<Expense> filteredExpenses)
        {
            if (filteredExpenses == null) filteredExpenses = Expense.GetExpenses();

            switch (Orderby)
            {
                case "name" when OrderDirection.Equals("asc"):
                    filteredExpenses = filteredExpenses.OrderBy(expense => expense.Name);
                    break;
                case "name" when OrderDirection.Equals("desc"):
                    filteredExpenses = filteredExpenses.OrderByDescending(expense => expense.Name);
                    break;
                case "date" when OrderDirection.Equals("asc"):
                    filteredExpenses = filteredExpenses.OrderBy(expense => expense.Date);
                    break;
                case "date" when OrderDirection.Equals("desc"):
                    filteredExpenses = filteredExpenses.OrderByDescending(expense => expense.Date);
                    break;
                case "amount" when OrderDirection.Equals("asc"):
                    filteredExpenses = filteredExpenses.OrderBy(expense => expense.Amount);
                    break;
                case "amount" when OrderDirection.Equals("desc"):
                    filteredExpenses = filteredExpenses.OrderByDescending(expense => expense.Amount);
                    break;
                case "category" when OrderDirection.Equals("asc"):
                    filteredExpenses = filteredExpenses.OrderBy(expense => expense.Category);
                    break;
                case "category" when OrderDirection.Equals("desc"):
                    filteredExpenses = filteredExpenses.OrderByDescending(expense => expense.Category);
                    break;
            }

            return filteredExpenses;
        }

        private IEnumerable<Expense> SetFilters(string term)
        {
            IEnumerable<Expense> filteredExpenses = Expense.GetExpenses();
            var floatString = float.TryParse(term, NumberStyles.Any, CultureInfo.CurrentCulture,
                out var outFloat);

            var dateString = DateTime.TryParse(term, CultureInfo.CurrentCulture,
                DateTimeStyles.None, out var outDate);

            if (floatString || dateString)
                filteredExpenses = filteredExpenses.Where(expense =>
                    expense.Name.ToLowerInvariant().Contains(term.ToLowerInvariant()) ||
                    expense.Description.ToLowerInvariant().Contains(term.ToLowerInvariant()) ||
                    expense.Category.ToLowerInvariant().Contains(term.ToLowerInvariant()) ||
                    floatString
                        ? Math.Abs(expense.Amount - outFloat) < 0.001
                        : expense.Date.Date.Equals(outDate.Date));
            else
                filteredExpenses = filteredExpenses.Where(expense =>
                    expense.Name.ToLowerInvariant().Contains(term.ToLowerInvariant()) ||
                    expense.Description.ToLowerInvariant().Contains(term.ToLowerInvariant()) ||
                    expense.Category.ToLowerInvariant().Contains(term.ToLowerInvariant()));
            return filteredExpenses;
        }

        private bool IsSortProperty(string term)
        {
            if (term.ToLowerInvariant().Equals("date") ||
                term.ToLowerInvariant().Equals("amount") ||
                term.ToLowerInvariant().Equals("category") ||
                term.ToLowerInvariant().Equals("name"))
            {
                Orderby = term;
                return true;
            }

            if (term.ToLowerInvariant().Equals("asc") ||
                term.ToLowerInvariant().Equals("desc"))
            {
                OrderDirection = term;
                return true;
            }

            return false;
        }
    }
}