using System;
using System.Collections.Generic;

namespace DMSDomainModel.Models
{
    public partial class Document
    {
        public Document()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? DateTimeStamp { get; set; }
        public long? Size { get; set; }
        public int? UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
