using System;
using System.Collections.Generic;

namespace BookLibrary.Models
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string? Category1 { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
