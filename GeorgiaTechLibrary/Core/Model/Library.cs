using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Model
{
    public partial class Library
    {
        public Library()
        {
            Volumes = new HashSet<Volume>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Agreement { get; set; }

        public virtual ICollection<Volume> Volumes { get; set; }
    }
}
