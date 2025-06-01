using Beyond.Contracts;
using Beyond.Utils;

namespace Beyond.Classes
{
    public class TodoList : ITodoList
    {
        #region Properties

        public IList<ITodoItem>? Items { get; set; }

        #endregion

        #region Public methods

        public IList<ITodoItem>? GetItems() { return Items; }

        public void AddItem(int id, string title, string description, string category)
        {
            if (Items == null)
            {
                Items = new List<ITodoItem>();
            }

            Items.Add(new TodoItem
            {
                Id = id,
                Title = title,
                Description = description,
                Category = category
            });
        }

        public void PrintItems()
        {
            if (Items == null || Items.Count == 0)
            {
                Console.WriteLine("No items to display");
            }
            else
            {
                foreach (var item in Items)
                {
                    Console.WriteLine(
                        $"{item.Id}) {item.Title} - {item.Description} " +
                        $"({item.Category}) Completed: {item.IsCompleted}");

                    if (item.HasBeenStarted)
                    {
                        decimal accumulatedProgress = 0;

                        foreach (var progression in item.Progressions.OrderBy(p => p.ActionCompletedDateTime))
                        {
                            accumulatedProgress += progression.CompletedPercentage;

                            Console.WriteLine(
                                $"{ progression.ActionCompletedDateTime.ToString("G") } - " +
                                $"{accumulatedProgress}%" +
                                $"\t" +
                                $"{ ProgressBar.GenerateProgressBarAsString(accumulatedProgress) }");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Item has not been started and has no progressions");
                    }
                }
            }
        }

        public void RegisterProgression(int id, DateTime dateTime, decimal percent)
        {
            ExistsItemById(id);

            var todoItem = Items.First(i => i.Id == id);

            InitializeProgressionsIfNotStarted(todoItem);

            CheckDateTimeProvidedForProgression(todoItem, dateTime);

            CheckProgressionPercentage(percent);

            CheckIfTotalPercentageExceedsMaximum(todoItem, percent);

            todoItem.Progressions.Add(new Progression(dateTime, percent));
        }

        public void RemoveItem(int id)
        {
            ExistsItemById(id);

            var todoItem = Items.First(i => i.Id == id);

            NotAllowEditingAnItemIfTotalPercentageIsMoreThan50(todoItem);

            Items.Remove(todoItem);
        }

        public void UpdateItem(int id, string description)
        {
            ExistsItemById(id);

            var todoItem = Items.First(i => i.Id == id);

            NotAllowEditingAnItemIfTotalPercentageIsMoreThan50(todoItem);

            todoItem.Description = description;
        }

        #endregion

        #region Private methods

        private void ExistsItemById(int id)
        {
            if (Items == null || !Items.Any(i => i.Id == id))
            {
                throw new KeyNotFoundException($"Item with Id {id} not found");
            }
        }

        private void CheckDateTimeProvidedForProgression(ITodoItem todoItem, DateTime dateTime)
        {
            if (todoItem.Progressions.Count != 0 &&
                dateTime <= todoItem.Progressions.Max(p => p.ActionCompletedDateTime))
            {
                throw new Exception(
                    $"Provided DateTime { dateTime.ToString("G") } " +
                    $"is earlier than current completed actions DateTimes");
            }
        }

        private void CheckProgressionPercentage(decimal percent)
        {
            if (percent <= 0 || percent > 100)
            {
                throw new InvalidDataException(
                    $"Invalid percentage ({percent}), it must be greater than zero or " +
                    $"less or equal to 100");
            }
        }

        private void CheckIfTotalPercentageExceedsMaximum(ITodoItem todoItem, decimal percent)
        {
            if (percent + todoItem.TotalCompletedPercentage > 100)
            {
                throw new InvalidDataException(
                    $"The total percentage cannot exceed 100%. Current percentage completed: " +
                    $"{todoItem.TotalCompletedPercentage}");
            }
        }

        private void NotAllowEditingAnItemIfTotalPercentageIsMoreThan50(ITodoItem todoItem)
        {
            if (todoItem.TotalCompletedPercentage > 50)
            {
                throw new InvalidDataException(
                    $"An item with more than 50% progression can't be modified nor deleted. " +
                    $"Current percentage completed: {todoItem.TotalCompletedPercentage}");
            }
        }

        private void InitializeProgressionsIfNotStarted(ITodoItem todoItem)
        {
            if (!todoItem.HasBeenStarted)
            {
                todoItem.Progressions = new List<IProgression>();
            }
        }

        #endregion
    }
}
