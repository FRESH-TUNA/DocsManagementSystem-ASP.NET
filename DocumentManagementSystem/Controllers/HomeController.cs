using DocumentManagementSystem.DAL;
using DocumentManagementSystem.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentManagementSystem.DAL.Views;
using DocumentManagementSystem.DAL.Models;

namespace DocumentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private BusinessLayer db = new BusinessLayer(new DocumentsContext());
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult getSubjectsPartialView()
        {
            return PartialView(db.selectAllCategory());
        }

        [HttpGet]
        public PartialViewResult documentsPartialView(string categoryName)
        {
            List<DocumentView> Model;
            if (categoryName.Equals("All"))
                Model = db.selectAllDocuments();
            else
                Model = db.selectCategorizedDocument(categoryName);

            return PartialView("documentsPartialView", Model);
        }

        [HttpGet]
        public PartialViewResult popupForUpdateView(int documentId, string categoryName, string content, string url)
        {
            DocumentView model = new DocumentView();
            model.documentId = documentId;
            model.categoryName = categoryName;
            model.content = content;
            model.url = url;
            return PartialView("popupForUpdateView", model);
        }

        [HttpPost]
        public ActionResult createDocument(DocumentViewModel model)
        {
            List<DocumentView> Model =  db.selectCategorizedDocument(model.categoryName);
            db.createDocument(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult deleteDocument(int documentId)
        {
            db.deleteDocument(documentId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult updateDocument(DocumentView model)
        {
            db.updateDocument(model);
            return RedirectToAction("Index");
        }

      
    }
}