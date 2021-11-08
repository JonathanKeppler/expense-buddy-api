using System;
using System.Collections.Generic;

#nullable disable

namespace ExpenseBuddy.Models
{
    public partial class ExpensesTemp
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public Guid ExpenseTypeId { get; set; }
        public DateTimeOffset IncurredOn { get; set; }
        public bool IsGift { get; set; }
        public string Location { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
    }
}
