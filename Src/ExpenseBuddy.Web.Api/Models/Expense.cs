using System;
using System.Collections.Generic;

#nullable disable

namespace ExpenseBuddy.Models
{
    public partial class Expense
    {
        public int ExpenseId { get; set; }
        public int ExTypeId { get; set; }
        public DateTime ExDate { get; set; }
        public decimal Amount { get; set; }
        public string PayMethod { get; set; }
        public string ExItem { get; set; }
        public string Location { get; set; }
        public bool? IsGift { get; set; }
    }
}
