using System.Text.Json.Serialization;

namespace Beyond.Contracts
{
    public interface ITodoList
    {
        IList<ITodoItem>? GetItems();

        void AddItem(int id, string title, string description, string category);

        void UpdateItem(int id, string description);

        void RemoveItem(int id);

        void RegisterProgression(int id, DateTime dateTime, decimal percent);

        void PrintItems();
    }
}
