using HenryBookStore.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HenryBookStore.Models
{
    public class LocationFilter
    {
        public string LocationSelected { get; set; }

        public IEnumerable<SelectListItem> AllLocationOptions { get; set; }
        public IEnumerable<BOOK> Books { get; set; } 
    }
}