using System;
using System.Collections.Generic;

#nullable disable

namespace GeorgiaTechLibrary.Model
{
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
            Volumes = new HashSet<Volume>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public short? Year { get; set; }
        public string Language { get; set; }
        public short? Edition { get; set; }
        public string Binding { get; set; }
        public bool CanLend { get; set; }
        public bool IsInteresting { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<Volume> Volumes { get; set; }
    }
}
