using Beyond.Contracts;

namespace Beyond.Classes
{
    public class TodoItem : ITodoItem
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }

        public IList<IProgression>? Progressions { get; set; }

        public bool IsCompleted => TotalCompletedPercentage == 100;

        public decimal TotalCompletedPercentage =>
            HasBeenStarted ?
            Progressions.Sum(p => p.CompletedPercentage)
            : 0;

        public bool HasBeenStarted => Progressions != null;
    }
}
