using System;
using System.Collections.Generic;

namespace ExpenseBuddy.Features.Expenses
{
    public class Expenses
    {
        public decimal Amount { get; set; }
        public string ExpenseTypeId { get; set; }
        public DateTimeOffset IncurredOn { get; set; }
        public string Location { get; set; }
        public IEnumerable<string> ScopedUsers { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
    }
}
