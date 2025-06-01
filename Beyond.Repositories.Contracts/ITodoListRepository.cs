using Beyond.Contracts;

namespace Beyond.Repositories.Contracts
{
    public interface ITodoListRepository
    {
        ITodoList todoList { get; set; }
        int GetNextId();
        List<string> GetAllCategories();
        void AddItem(string title, string description, string category);
        void RegisterProgression(int id, DateTime currentDate, decimal percentage);
        void RemoveItemById(int id);
        void UpdateItem(int id, string description);
        ITodoList GetTodoList();
    }
}
