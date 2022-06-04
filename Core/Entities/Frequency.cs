using System.Collections.Generic;

namespace Core.Entities
{
    public class Frequency
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Challenge> Challenges { get; set; }
    }
}
