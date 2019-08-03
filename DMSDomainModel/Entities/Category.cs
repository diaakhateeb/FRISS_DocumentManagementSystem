using System;
using System.Collections.Generic;

namespace DMSDomainModel.Entities
{
    public partial class Category
    {
        public Category()
        {
            Document = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateTimeStamp { get; set; }

        public virtual ICollection<Document> Document { get; set; }
    }
}
