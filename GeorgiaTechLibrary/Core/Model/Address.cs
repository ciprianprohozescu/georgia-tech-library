using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Model
{
    public partial class Address
    {
        public Address()
        {
            MemberCampusAddresses = new HashSet<Member>();
            MemberPrivateAddresses = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Type { get; set; }
        public short? Floor { get; set; }
        public short? Apartment { get; set; }

        public virtual ICollection<Member> MemberCampusAddresses { get; set; }
        public virtual ICollection<Member> MemberPrivateAddresses { get; set; }
    }
}
