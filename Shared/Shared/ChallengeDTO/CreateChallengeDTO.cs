using System;

namespace Shared.ChallengeDTO
{
    public class CreateChallengeDTO
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public int CountOfUnits { get; set; }
        public int UnitId { get; set; }
        public int FrequencyId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }    
}
