using System.Threading.Tasks;

namespace ExpensesApp.Shared
{
    public partial interface IShare
    {
        Task Show(string title, string message, string filePath);
    }
}