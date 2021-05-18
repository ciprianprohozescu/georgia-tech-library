using System;
namespace Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public Int16 Year { get; set; }
        public string Language { get; set; }
        public Int16 Edition { get; set; }
        public string Binding { get; set; }
        public bool Can_Lend { get; set; }
        public bool Is_Interesting { get; set; }
    }
}
