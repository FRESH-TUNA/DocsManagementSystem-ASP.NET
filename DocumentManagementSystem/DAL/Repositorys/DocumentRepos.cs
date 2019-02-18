using DocumentManagementSystem.DAL.Models;
using DocumentManagementSystem.DAL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.DAL.Repositorys
{
    public class DocumentRepos
    {
        private DocumentsContext db;

        public DocumentRepos(DocumentsContext db)
        {
            this.db = db;
        }

        public void createDocument(DocumentViewModel model)
        {
            string query = @"createDocument {0},{1},{2}";
            db.Database.ExecuteSqlCommand(query, model.categoryName, model.content, model.url);
        }

        public void deleteDocument(int documentId)
        {
            string query = @"deleteDocument {0}";
            db.Database.ExecuteSqlCommand(query, documentId);
        }

        public void updateDocument(Document model)
        {
            var executedquery = from document in db.Document
                                where document.documentId == model.documentId
                                select document;

            executedquery.First().categoryId = model.categoryId;
            executedquery.First().content = model.content;
            executedquery.First().url = model.url;
            db.SaveChanges();
        }
    }
}