using System;
using System.Collections.Generic;

#nullable disable

namespace GeorgiaTechLibrary.Model
{
    public partial class Member
    {
        public Member()
        {
            Loans = new HashSet<Loan>();
        }

        public int Id { get; set; }
        public string Ssn { get; set; }
        public int? CampusAddressId { get; set; }
        public int? PrivateAddressId { get; set; }
        public string Fname { get; set; }
        public string Minit { get; set; }
        public string Lname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? CardExpiryDate { get; set; }
        public string Type { get; set; }

        public virtual Address CampusAddress { get; set; }
        public virtual Address PrivateAddress { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
