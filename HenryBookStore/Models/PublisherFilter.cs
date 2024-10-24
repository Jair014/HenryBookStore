using HenryBookStore.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HenryBookStore.Models
{
    public class PublisherFilter
    {
        public string PublisherSelected { get; set; }

        public IEnumerable<SelectListItem> AllPublisherOptions { get; set; }

        public List<BOOK> Books { get; set; } 
    }
}