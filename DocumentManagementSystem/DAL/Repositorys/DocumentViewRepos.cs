using DocumentManagementSystem.DAL.Models;
using DocumentManagementSystem.DAL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.DAL.Repositorys
{
    public class DocumentViewRepos
    {
        private DocumentsContext db;

        public DocumentViewRepos(DocumentsContext db)
        {
            this.db = db;
        }
        
        public List<DocumentView> selectAllDocument()
        {
            return db.DocumentView.ToList();
        }

        public List<DocumentView> selectCategorizedDocument(string categoryName)
        {
            string query = @"selectCategorizedDocument {0}";
            List<DocumentView> selectedDocuments = db.Database.SqlQuery<DocumentView>(query, categoryName).ToList<DocumentView>();
            return selectedDocuments;
        }
    }
}