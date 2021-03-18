using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyCookbook.Models;
using FamilyCookbook.Models.EntityFramework;

namespace FamilyCookbook.Controllers
{
    public class BrowseByAuthorController : Controller
    {
        // Connect to database
        CookbookEntities db = new CookbookEntities();

        // GET: BrowseByAuthor
        public ActionResult BrowseByAuthor()
        {
            BrowseByAuthor model = new BrowseByAuthor();

            var authors = db.AUTHORs.ToList().Select(s => new SelectListItem
            {
                Text = s.FIRST_NAME + " " + s.LAST_NAME,
                Value = s.AUTHOR_ID.ToString()
            });

            return PartialView("~/Views/Shared/_BrowseByAuthor.cshtml", new BrowseByAuthor { AllAuthorOptions = authors });
        }
    }
}