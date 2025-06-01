
namespace Beyond.Contracts
{
    public interface ITodoItem
    {
        string? Category { get; set; }
        string? Description { get; set; }
        bool HasBeenStarted { get; }
        int Id { get; set; }
        bool IsCompleted { get; }
        IList<IProgression>? Progressions { get; set; }
        string? Title { get; set; }
        decimal TotalCompletedPercentage { get; }
    }
}