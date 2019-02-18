using DocumentManagementSystem.DAL;
using DocumentManagementSystem.DAL.Models;
using DocumentManagementSystem.DAL.Repositorys;
using DocumentManagementSystem.DAL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.BL
{
    public class BusinessLayer
    {
        private DocumentRepos documentRepos;
        private CategoryRepos categoryRepos;
        private DocumentViewRepos documentViewRepos;

        public BusinessLayer(DocumentsContext db)
        {
            documentRepos = new DocumentRepos(db);
            categoryRepos = new CategoryRepos(db);
            documentViewRepos = new DocumentViewRepos(db);
        }

        public List<DocumentView> selectAllDocuments()
        {
            return documentViewRepos.selectAllDocument();
        }

        public List<DocumentView> selectCategorizedDocument(string subjectName)
        {
            return documentViewRepos.selectCategorizedDocument(subjectName);
        }

        public List<Category> selectAllCategory()
        {
            return categoryRepos.selectAllCategory();
        }

        public void createDocument(DocumentViewModel model)
        {
            documentRepos.createDocument(model);
        }

        public void deleteDocument(int documentId)
        {
            documentRepos.deleteDocument(documentId);
        }

        public void updateDocument(DocumentView model)
        {
            int categoryId = categoryRepos.selectCategoryId(model.categoryName);
            Document updatedDocument = new Document();

            updatedDocument.documentId = model.documentId;
            updatedDocument.categoryId = categoryId;
            updatedDocument.content = model.content;
            updatedDocument.url = model.url;

            documentRepos.updateDocument(updatedDocument);
        }
    }
}