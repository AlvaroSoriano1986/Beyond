using Beyond.Contracts;

namespace Beyond.Classes
{
    public class Progression : IProgression
    {
        public DateTime ActionCompletedDateTime { get; set; }

        public decimal CompletedPercentage { get; set; }

        public Progression(DateTime actionCompletedDateTime, decimal completedPercentage)
        {
            ActionCompletedDateTime = actionCompletedDateTime;
            CompletedPercentage = completedPercentage;
        }
    }
}
