using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser
    {
        public int Points { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        
        public ICollection<Challenge> AuthoredChallenges { get; set; }
        public ICollection<Challenge> Challenges { get; set; }
    }
}
