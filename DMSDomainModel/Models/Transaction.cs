using System;
using System.Collections.Generic;

namespace DMSDomainModel.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int? DocumentId { get; set; }
        public int? UserId { get; set; }
        public DateTime? TransDate { get; set; }
        public DateTime? DateTimeStamp { get; set; }

        public virtual Document Document { get; set; }
        public virtual User User { get; set; }
    }
}
