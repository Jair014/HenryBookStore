using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Web.DynamicData;
using HenryBookStore.Models;
using HenryBookStore.Models.EntityFramework;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using Microsoft.Ajax.Utilities;

namespace HenryBookStore.Controllers
{
    public class HomeController : Controller
    {
        private HENRY_ASPNETEntities db = new HENRY_ASPNETEntities();
        public ActionResult Index()
        {
            ViewBag.Message = "Your applications home page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult BrowseAuthor()
        {

            // Redirect to AuthorFilterController's Index method
            return RedirectToAction("Index", "AuthorFilter");
        }


        public ActionResult BrowsePublisher()
        {
            // Redirect to PublisherFilterController's Index method
            return RedirectToAction("Index", "PublisherFilter");
        }
        public ActionResult BrowseLocation()
        {
            //redirect
            return RedirectToAction("Index", "LocationFilter");
        }
        public ActionResult Details(string id)
        {
            // Retrieve the book by BOOK_CODE
            var book = db.BOOKs.Include("PUBLISHER").FirstOrDefault(b => b.BOOK_CODE == id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View("Details",book); // Pass book object to the bookDetails view


       
        }
        public ActionResult Inventory()
        {
            {
                //loop thorugh books in inventory
                var allBooks = db.BOOKs.ToList();

                List<BOOK> result = new List<BOOK>();

                foreach (var book in allBooks)
                {
                    BOOK model = new BOOK();
                    model.BOOK_CODE = book.BOOK_CODE;
                    model.TITLE = book.TITLE;
                    model.PUBLISHER_CODE = book.PUBLISHER_CODE;
                    model.TYPE = book.TYPE;
                    model.PRICE = book.PRICE;
                    model.PAPERBACK = book.PAPERBACK;

                    model.INVENTORies = db.INVENTORies.Where(b => b.BOOK_CODE.Equals(model.BOOK_CODE)).ToList();
                    result.Add(model);
                }
                return View(result);

            }
        }
    }
}