using DMSDomainModel.Entities;
using Repository.Interfaces;

namespace DocumentManagement.DocumentRepository.Interfaces
{
    public interface IDocumentRepository
    {
        void Download();
        void Upload();
        IRepository<Document> DocumentDbContext { get; }
    }
}
