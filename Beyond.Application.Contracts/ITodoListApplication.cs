using Beyond.Classes;
using Beyond.Contracts;

namespace Beyond.Application.Contracts
{
    public interface ITodoListApplication
    {
        List<string> GetAllCategories();
        void AddItem(string title, string description, string category);
        void PrintItems();
        void RegisterProgression(int id, DateTime currentDate, decimal percentage);
        void RemoveItemById(int id);
        void UpdateItem(int id, string description);
        ITodoList GetTodoList();
    }
}
