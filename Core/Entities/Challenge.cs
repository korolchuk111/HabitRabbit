using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Challenge
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public string Title { get; set; }
        public int CountOfUnits { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int FrequencyId { get; set; }
        public Frequency Frequency { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public bool? IsRegistrationOpened { get; set; }
        public bool IsCompleted { get; set; }
        
        public ICollection<DailyTask> DailyTasks { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
