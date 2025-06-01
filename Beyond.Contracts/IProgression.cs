
namespace Beyond.Contracts
{
    public interface IProgression
    {
        DateTime ActionCompletedDateTime { get; set; }
        decimal CompletedPercentage { get; set; }
    }
}