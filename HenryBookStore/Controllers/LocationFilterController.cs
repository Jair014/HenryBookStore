using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HenryBookStore.Models;
using HenryBookStore.Models.EntityFramework;

namespace HenryBookStore.Controllers
{
    public class LocationFilterController : Controller
    {
        private HENRY_ASPNETEntities db = new HENRY_ASPNETEntities();
        // GET: LocationFilter
        public ActionResult Index()
        {
            LocationFilter model = new LocationFilter();
            model.AllLocationOptions = db.BRANCHes.Select(b => new SelectListItem
            {
                Value = b.BRANCH_NUM.ToString(),
                Text = b.BRANCH_NAME
            }).ToList();
            return View(model); 

        }


        [HttpPost]
        public ActionResult Index(LocationFilter model)
        {
            if (string.IsNullOrEmpty(model.LocationSelected))
            {
                // If no location is selected, reload the page with all locations
                model.AllLocationOptions = db.BRANCHes.Select(b => new SelectListItem
                {
                    Value = b.BRANCH_NUM.ToString(),
                    Text = b.BRANCH_NAME
                }).ToList();

                return View(model);
            }

            // Filter the books by the selected location
            int locationId = int.Parse(model.LocationSelected);
            var booksByLocation = db.INVENTORies
                                    .Where(i => i.BRANCH_NUM == locationId)
                                    .Select(i => i.BOOK)
                                    .ToList();

            model.Books = booksByLocation;

            // Re-populate the dropdown list so it doesn't clear out 
            model.AllLocationOptions = db.BRANCHes.Select(b => new SelectListItem
            {
                Value = b.BRANCH_NUM.ToString(),
                Text = b.BRANCH_NAME
            }).ToList();

            return View(model); 
        }



    }
}