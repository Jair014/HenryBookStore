using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HenryBookStore.Models;
using HenryBookStore.Models.EntityFramework;

namespace HenryBookStore.Controllers
{
    public class PublisherFilterController : Controller
    {
        private HENRY_ASPNETEntities db = new HENRY_ASPNETEntities();
        // GET: PublisherFilter
        public ActionResult Index()
        {
            PublisherFilter model = new PublisherFilter();
            model.AllPublisherOptions = db.PUBLISHERs.Select(p => new SelectListItem
            {
                Value = p.PUBLISHER_CODE.ToString(),
                Text = p.PUBLISHER_NAME
            }).ToList();
            return View(model);
        }

        // POST: PublisherFilter
        [HttpPost]
        public ActionResult Index(PublisherFilter model)
        {
            if (string.IsNullOrEmpty(model.PublisherSelected))
            {
                // If no publisher is selected, reload the page with all publishers
                model.AllPublisherOptions = db.PUBLISHERs.Select(p => new SelectListItem
                {
                    Value = p.PUBLISHER_CODE.ToString(),
                    Text = p.PUBLISHER_NAME
                }).ToList();

                return View(model);
            }

            // Filter the books by the selected publisher
            var booksByPublisher = db.BOOKs
                                     .Where(b => b.PUBLISHER_CODE == model.PublisherSelected)
                                     .ToList();

            model.Books = booksByPublisher; // Pass the filtered books to the view

            // Re-populate the dropdown list so it doesn't clear
            model.AllPublisherOptions = db.PUBLISHERs.Select(p => new SelectListItem
            {
                Value = p.PUBLISHER_CODE.ToString(),
                Text = p.PUBLISHER_NAME
            }).ToList();

            return View(model);
        }


    }
}