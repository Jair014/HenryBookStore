using HenryBookStore.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HenryBookStore.Models
{
    public class AuthorFilter


    {
        public string AuthorSelected { get; set; }

        public IEnumerable<SelectListItem> AllAuthorOptions { get; set; }
        public IEnumerable<BOOK> Books { get; set; }
    }
}