using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ExpensesApp.Models;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class NewExpenseViewModel : INotifyPropertyChanged
    {
        private float expenseAmount;

        private string expenseCategory;

        private DateTime expenseDate;

        private string expenseDescription;
        private string expenseName;

        public NewExpenseViewModel()
        {
            ExpenseDate = DateTime.Today;
            Categories = new ObservableCollection<string>();
            GetCategories();
            SaveExpenseCommand = new Command(InsertExpense);
            ExpenseStatuses = new ObservableCollection<ExpenseStatus>();
        }

        public ObservableCollection<ExpenseStatus> ExpenseStatuses { get; set; }

        public string ExpenseName
        {
            get => expenseName;

            set
            {
                expenseName = value;
                OnPropertyChanged("ExpenseName");
            }
        }

        public string ExpenseDescription
        {
            get => expenseDescription;

            set
            {
                expenseDescription = value;
                OnPropertyChanged("ExpenseDescription");
            }
        }

        public float ExpenseAmount
        {
            get => expenseAmount;

            set
            {
                expenseAmount = value;
                OnPropertyChanged("ExpenseAmount");
            }
        }

        public DateTime ExpenseDate
        {
            get => expenseDate;

            set
            {
                expenseDate = value;
                OnPropertyChanged("ExpenseDate");
            }
        }

        public string ExpenseCategory
        {
            get => expenseCategory;

            set
            {
                expenseCategory = value;
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
                Category = expenseCategory,
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

        public void GetExpenseStatus()
        {
            ExpenseStatuses.Clear();
            ExpenseStatuses.Add(new ExpenseStatus
            {
                Name = "Random 1",
                Status = false
            });
            
            ExpenseStatuses.Add(new ExpenseStatus
            {
                Name = "Random 2",
                Status = true
            });
            
            ExpenseStatuses.Add(new ExpenseStatus
            {
                Name = "Random 3",
                Status = false
            });
        }

        public class ExpenseStatus
        {
            public string Name { get; set; }

            public bool Status { get; set; }
        }
    }
}