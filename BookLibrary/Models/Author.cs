using System;
using System.Collections.Generic;

namespace BookLibrary.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Fullname => Firstname +" "+Lastname;

        public virtual ICollection<Book> Books { get; set; }
    }
}
