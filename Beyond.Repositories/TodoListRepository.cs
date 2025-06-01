using Beyond.Contracts;
using Beyond.Repositories.Contracts;

namespace Beyond.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        public ITodoList todoList { get; set; }

        public TodoListRepository(ITodoList todoList)
        {
            this.todoList = todoList;
        }

        public List<string> GetAllCategories()
        {
            // This could come from any type of data storage
            return new List<string>()
            {
                "Bug",
                "Improvement",
                "New feature",
                "Task",
                "Enhancement",
                "Documentation",
                "Refactor",
                "Technical debt",
                "Performance",
                "Security"
            };
        }

        public int GetNextId()
        {
            // This could come from any type of data storage or or delegate it to the ORM’s own management
            if (todoList == null)
            {
                return 1;
            }

            var items = todoList.GetItems();

            if (items == null || items.Count == 0)
            {
                return 1;
            }

            return items.Max(x => x.Id) + 1;
        }

        public void AddItem(string title, string description, string category)
        {
            todoList.AddItem(GetNextId(), title, description, category);
        }

        public void RegisterProgression(int id, DateTime currentDate, decimal percentage)
        {
            todoList.RegisterProgression(id, currentDate, percentage);
        }

        public void RemoveItemById(int id)
        {
            todoList.RemoveItem(id);
        }

        public void UpdateItem(int id, string description)
        {
            todoList.UpdateItem(id, description);
        }

        public ITodoList GetTodoList()
        {
            return todoList;
        }
    }
}
