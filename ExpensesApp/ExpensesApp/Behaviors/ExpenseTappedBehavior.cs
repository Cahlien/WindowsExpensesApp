using ExpensesApp.Models;
using ExpensesApp.Views;
using Xamarin.Forms;

namespace ExpensesApp.Behaviors
{
    public class ExpenseTappedBehavior : Behavior<ListView>
    {
        private ListView _listView;

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            _listView = bindable;
            _listView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedExpense = _listView.SelectedItem as Expense;
            Application.Current.MainPage.Navigation.PushAsync(new ExpenseDetailsPage(selectedExpense));
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            _listView.ItemSelected -= ListView_ItemSelected;
        }
    }
}