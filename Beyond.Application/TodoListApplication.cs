using Beyond.Application.Contracts;
using Beyond.Contracts;
using Beyond.Repositories.Contracts;

namespace Beyond.Application
{
    public class TodoListApplication : ITodoListApplication
    {
        private readonly ITodoListRepository _todoListRepository;

        public TodoListApplication(ITodoListRepository todoListRepository) 
        {
            _todoListRepository = todoListRepository;
        }

        public List<string> GetAllCategories()
        {
            return _todoListRepository.GetAllCategories();
        }

        public void AddItem(string title, string description, string category)
        {
            _todoListRepository.AddItem(title, description, category);
        }

        public void PrintItems()
        {
            _todoListRepository.todoList.PrintItems();
        }

        public void RegisterProgression(int id, DateTime currentDate, decimal percentage)
        {
            _todoListRepository.RegisterProgression(id, currentDate, percentage);
        }

        public void RemoveItemById(int id)
        {
            _todoListRepository.RemoveItemById(id);
        }

        public void UpdateItem(int id, string description)
        {
            _todoListRepository.UpdateItem(id, description);
        }

        public ITodoList GetTodoList()
        {
            return _todoListRepository.GetTodoList();
        }
    }
}
