using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using ExpensesApp.Models;
using ExpensesApp.Shared;
using PCLStorage;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class CategoriesViewModel
    {
        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<CategoryExpenses> CategoryExpensesCollection { get; set; }
        public Command ExportCommand { get; set; }
        
        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<string>();
            CategoryExpensesCollection = new ObservableCollection<CategoryExpenses>();
            GetCategories();
            GetExpensesPerCategory();
            ExportCommand = new Command(ShareReport);
        }

        private async void ShareReport()
        {
            var fileSystem = FileSystem.Current;
            var rootFolder = fileSystem.LocalStorage;
            var reportsFolder = await rootFolder.CreateFolderAsync("reports", CreationCollisionOption.OpenIfExists);

            var txtFile = await reportsFolder.CreateFileAsync("report.txt", CreationCollisionOption.ReplaceExisting);

            using (StreamWriter sw = new StreamWriter(txtFile.Path))
            {
                foreach (var ce in CategoryExpensesCollection)
                {
                    sw.WriteLine($"{ce.Category} - {ce.ExpensesPercentage}");
                }
            }
            
            IShare shareDependency = DependencyService.Get<IShare>();
            await shareDependency.Show("Expense Report", "Here is your expense report", txtFile.Path);
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

        public void GetExpensesPerCategory()
        {
            CategoryExpensesCollection.Clear();
            float totalExpensesAmount = Expense.TotalExpensesAmount();
            
            foreach (var category in Categories)
            {
                var expenses = Expense.GetExpenses(category);
                float expensesAmountInCategory = expenses.Sum(e => e.Amount);

                if (totalExpensesAmount == 0)
                {
                    totalExpensesAmount = 1;
                }
                var categoryExpense = new CategoryExpenses()
                {
                    Category = category,
                    ExpensesPercentage = expensesAmountInCategory / totalExpensesAmount
                };
                
                CategoryExpensesCollection.Add(categoryExpense);
            }
        }
        public class CategoryExpenses
        {
            public string Category { get; set; }
            public float ExpensesPercentage { get; set; }
            
            
        }
    }
}