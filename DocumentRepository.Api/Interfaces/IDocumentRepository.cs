using DMSDomainModel.Entities;
using Repository.Interfaces;

namespace DocumentRepository.Api.Interfaces
{
    public interface IDocumentRepository
    {
        void Download();
        void Upload();
        IRepository<Document> DocumentDbContext { get; }
    }
}
