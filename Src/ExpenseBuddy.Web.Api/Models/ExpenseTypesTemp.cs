using System;
using System.Collections.Generic;

#nullable disable

namespace ExpenseBuddy.Models
{
    public partial class ExpenseTypesTemp
    {
        public Guid Id { get; set; }
        public string ExpenseTypeName { get; set; }
        public string ExpenseSubTypeName { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
