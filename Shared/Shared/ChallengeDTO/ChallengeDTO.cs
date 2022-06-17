using System;

namespace Shared.ChallengeDTO
{
    public class ChallengeDTO
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public int CountOfUnits { get; set; }
        public string UnitShortTitle { get; set; }
        public string FrequencyTitle { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public bool? IsRegistrationOpened { get; set; }
        public bool IsCompleted { get; set; }
    }
}