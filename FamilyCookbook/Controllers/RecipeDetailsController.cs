using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamilyCookbook.Models.EntityFramework;

namespace FamilyCookbook.Controllers
{
    public class RecipeDetailsController : Controller
    {
        private CookbookEntities db = new CookbookEntities();

        // GET: RecipeDetails
        public ActionResult Index()
        {
            var rECIPEs = db.RECIPEs.Include(r => r.AUTHOR).Include(r => r.CATEGORY);
            return View(rECIPEs.ToList());
        }

        // GET: RecipeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECIPE rECIPE = db.RECIPEs.Find(id);
            if (rECIPE == null)
            {
                return HttpNotFound();
            }
            return View(rECIPE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
