using DMSDomainModel.Entities;
using DocumentManagement.DocumentRepository.Interfaces;
using Repository.Interfaces;
using System;

namespace DocumentManagement.DocumentRepository
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
