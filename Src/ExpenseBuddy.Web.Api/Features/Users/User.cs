using System.Collections.Generic;

namespace ExpenseBuddy.Features.Users
{
    public class User
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> LinkedUsers { get; set; }
    }
}
