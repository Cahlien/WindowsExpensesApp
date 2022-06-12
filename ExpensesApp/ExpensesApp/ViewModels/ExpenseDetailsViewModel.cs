using System.ComponentModel;
using ExpensesApp.Models;

namespace ExpensesApp.ViewModels
{
    public class ExpenseDetailsViewModel : INotifyPropertyChanged
    {
        private Expense _expense;

        public Expense Expense
        {
            get => _expense;
            set
            {
                _expense = value;
                OnPropertyChanged("Expense");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}