using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HenryBookStore.Models;
using HenryBookStore.Models.EntityFramework;

namespace HenryBookStore.Controllers
{
    public class AuthorFilterController : Controller
    {
        private HENRY_ASPNETEntities db = new HENRY_ASPNETEntities();
        // GET: AuthorFilter
        public ActionResult Index()
        {
            AuthorFilter model = new AuthorFilter();
            model.AllAuthorOptions = db.AUTHORs.Select(a => new SelectListItem
            {
                Value = a.AUTHOR_NUM.ToString(),
                Text = a.AUTHOR_FIRST + ", " + a.AUTHOR_LAST
            }).ToList();

            model.Books = new List<BOOK>();
   
            return View(model);
        }





        [HttpPost]
        public ActionResult Index(AuthorFilter model)
        {
            if (string.IsNullOrEmpty(model.AuthorSelected))
            {
                // If no author is selected, reload the page with all authors
                model.AllAuthorOptions = db.AUTHORs.Select(a => new SelectListItem
                {
                    Value = a.AUTHOR_NUM.ToString(),
                    Text = a.AUTHOR_FIRST + " " + a.AUTHOR_LAST
                }).ToList();

                model.Books = new List<BOOK>(); // No books to display if no author is selected

                
                return View(model);
            }
            else
            {
                // Filter the books by the selected author
                int authorId = int.Parse(model.AuthorSelected);
                var booksByAuthor = db.WROTEs
                                      .Where(w => w.AUTHOR_NUM == authorId)
                                      .Select(w => w.BOOK)
                                      .ToList();

                model.Books = booksByAuthor; // Pass the filtered books to the view

                // Re-populate the dropdown list so it doesn't clear out 
                model.AllAuthorOptions = db.AUTHORs.Select(a => new SelectListItem
                {
                    Value = a.AUTHOR_NUM.ToString(),
                    Text = a.AUTHOR_FIRST + " " + a.AUTHOR_LAST
                }).ToList();

                return View("~/Views/Home/BrowseAuthor.cshtml",model);

            }


        }



    }
}