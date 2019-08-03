using System;
using System.Collections.Generic;

namespace DMSDomainModel.Models
{
    public partial class User
    {
        public User()
        {
            Document = new HashSet<Document>();
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public short? Role { get; set; }
        public string Token { get; set; }
        public DateTime? DateTimeStamp { get; set; }

        public virtual Role RoleNavigation { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
