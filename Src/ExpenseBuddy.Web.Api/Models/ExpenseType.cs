using System;
using System.Collections.Generic;

#nullable disable

namespace ExpenseBuddy.Models
{
    public partial class ExpenseType
    {
        public int ExTypeId { get; set; }
        public string ExType { get; set; }
        public string SubType { get; set; }
    }
}
