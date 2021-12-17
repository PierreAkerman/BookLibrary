using System;
using System.Collections.Generic;

namespace BookLibrary.Models
{
    public partial class Book
    {
        public Book()
        {
            LoanRecords = new HashSet<LoanRecord>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? ReleaseYear { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int? AtributeId { get; set; }

        public virtual BookAttribute? Atribute { get; set; }
        public virtual Author? Author { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<LoanRecord> LoanRecords { get; set; }
    }
}
