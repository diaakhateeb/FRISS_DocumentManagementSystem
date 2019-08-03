using System;
using System.Collections.Generic;

namespace DMSDomainModel.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateTimeStamp { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
