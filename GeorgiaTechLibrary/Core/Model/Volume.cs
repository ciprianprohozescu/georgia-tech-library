using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Model
{
    public partial class Volume
    {
        public Volume()
        {
            Loans = new HashSet<Loan>();
        }

        public int Id { get; set; }
        public int BookId { get; set; }
        public int? SourceLibraryId { get; set; }
        public DateTime? AcquiryDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Library SourceLibrary { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
