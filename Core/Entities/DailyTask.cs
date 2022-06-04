using System;

namespace Core.Entities
{
    public class DailyTask
    {
        public int Id { get; set; }
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }
        public DateTime Date { get; set; }
        public int CountOfUnitsDone { get; set; }
        public int PercentOfDone { get; set; }
        public bool IsDone { get; set; }
    }
}
