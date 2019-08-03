using DMSDomainModel.Entities;
using DocumentRepository.Api.Interfaces;
using Repository.Interfaces;
using System;

namespace DocumentRepository.Api
{
    public class DocumentRepository : IDocumentRepository
    {
        public DocumentRepository(IRepository<Document> documentDbContext)
        {
            DocumentDbContext = documentDbContext;
        }

        public void Download()
        {
            throw new NotImplementedException();
        }

        public void Upload()
        {
            throw new NotImplementedException();
        }

        public IRepository<Document> DocumentDbContext { get; }
    }
}
