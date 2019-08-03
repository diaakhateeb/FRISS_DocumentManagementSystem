using System.Collections.Generic;

namespace DMSDomainModel.Entities
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            Transaction = new HashSet<Transaction>();
        }

        public short Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
