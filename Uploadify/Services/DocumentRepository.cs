using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uploadify.Data;
using Uploadify.Models;

namespace Uploadify.Services
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AppDbContext _context;

        public DocumentRepository(AppDbContext context)
        {
            _context = context;
        }
        public void CreateDoc(Document doc)
        {
            _context.Documents.Add(doc);
            _context.SaveChanges();
        }
    }
}
