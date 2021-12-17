using System;
using System.Collections.Generic;

namespace BookLibrary.Models
{
    public partial class Customer
    {
        public Customer()
        {
            LoanRecords = new HashSet<LoanRecord>();
        }

        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<LoanRecord> LoanRecords { get; set; }
    }
}
