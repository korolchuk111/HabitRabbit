using System;

namespace Shared.DailyTaskDTO
{
    public class DailyTaskDTO
    {
        public int Id { get; set; }
        public string ChallengeTitle { get; set; }
        public int CountOfUnits { get; set; }
        public string UnitShortName { get; set; }
        public DateTime Date { get; set; }
        public int CountOfUnitsDone { get; set; }
        public int PercentOfDone { get; set; }
        public bool IsDone { get; set; }
    }
}