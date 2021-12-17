using System;
using System.Collections.Generic;

namespace BookLibrary.Models
{
    public partial class LoanRecord
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? BookId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Book? Book { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
