using System;
using System.Collections.Generic;

namespace BookLibrary.Models
{
    public partial class BookAttribute
    {
        public BookAttribute()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string? Size { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
