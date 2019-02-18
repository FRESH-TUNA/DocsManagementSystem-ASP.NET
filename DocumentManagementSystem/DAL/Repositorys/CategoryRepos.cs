using DocumentManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.DAL.Repositorys
{
    public class CategoryRepos
    {
        private DocumentsContext db;

        public CategoryRepos(DocumentsContext db)
        {
            this.db = db;
        }

        public List<Category> selectAllCategory()
        {
            return db.Category.ToList();
        }

        public int selectCategoryId(string categoryName)
        {
            var executedquery = from category in db.Category
                                where category.categoryName == categoryName
                                select category.categoryId;
            return executedquery.First();
        }
    }
}