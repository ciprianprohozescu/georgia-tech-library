using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Model
{
    public partial class Author
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }
        public string Fname { get; set; }
        public string Minit { get; set; }
        public string Lname { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
