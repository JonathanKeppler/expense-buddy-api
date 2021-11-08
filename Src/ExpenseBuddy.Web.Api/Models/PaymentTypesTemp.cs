using System;
using System.Collections.Generic;

#nullable disable

namespace ExpenseBuddy.Models
{
    public partial class PaymentTypesTemp
    {
        public Guid Id { get; set; }
        public string PaymentTypeName { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
