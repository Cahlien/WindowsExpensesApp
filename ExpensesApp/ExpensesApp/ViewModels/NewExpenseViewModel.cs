using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ExpensesApp.Models;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class NewExpenseViewModel : INotifyPropertyChanged
    {
        private float _expenseAmount;
        private string _expenseCategory;
        private DateTime _expenseDate;
        private string _expenseDescription;
        private string _expenseName;

        public NewExpenseViewModel()
        {
            ExpenseDate = DateTime.Today;
            Categories = new ObservableCollection<string>();
            GetCategories();
            SaveExpenseCommand = new Command(InsertExpense);
        }

        public string ExpenseName
        {
            get => _expenseName;

            set
            {
                _expenseName = value;
                OnPropertyChanged("ExpenseName");
            }
        }

        public string ExpenseDescription
        {
            get => _expenseDescription;

            set
            {
                _expenseDescription = value;
                OnPropertyChanged("ExpenseDescription");
            }
        }

        public float ExpenseAmount
        {
            get => _expenseAmount;

            set
            {
                _expenseAmount = value;
                OnPropertyChanged("ExpenseAmount");
            }
        }

        public DateTime ExpenseDate
        {
            get => _expenseDate;

            set
            {
                _expenseDate = value;
                OnPropertyChanged("ExpenseDate");
            }
        }

        public string ExpenseCategory
        {
            get => _expenseCategory;

            set
            {
                _expenseCategory = value;
                OnPropertyChanged("ExpenseCategory");
            }
        }

        public Command SaveExpenseCommand { get; set; }

        public ObservableCollection<string> Categories { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertExpense()
        {
            var expense = new Expense
            {
                Name = ExpenseName,
                Amount = ExpenseAmount,
                Category = _expenseCategory,
                Date = ExpenseDate,
                Description = ExpenseDescription
            };

            var response = Expense.InsertExpense(expense);

            if (response > 0)
                Application.Current.MainPage.Navigation.PopAsync();
            else
                Application.Current.MainPage.DisplayAlert("Error", "No items were inserted", "OK");
        }

        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");
        }
    }
}