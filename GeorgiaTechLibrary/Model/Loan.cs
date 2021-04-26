using System;
using System.Collections.Generic;

#nullable disable

namespace GeorgiaTechLibrary.Model
{
    public partial class Loan
    {
        public int MemberId { get; set; }
        public int VolumeId { get; set; }
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? DueDate { get; set; }

        public virtual Member Member { get; set; }
        public virtual Volume Volume { get; set; }
    }
}
