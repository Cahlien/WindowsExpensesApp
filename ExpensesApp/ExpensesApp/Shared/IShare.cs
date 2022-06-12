using System.Threading.Tasks;

namespace ExpensesApp.Shared
{
    public interface IShare
    {
        Task Show(string title, string message, string filePath);
    }
}