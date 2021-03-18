using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyCookbook.Models;
using FamilyCookbook.Models.EntityFramework;

namespace FamilyCookbook.Controllers
{
    public class HomeController : Controller
    {
        private CookbookEntities db = new CookbookEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SuggestEdit()
        {
            ViewBag.Message = "Your edit suggestion page.";

            return View();
        }

        [HttpPost]
        public JsonResult SuggestEdit(SuggestEdit model)
        {
            return Json(model);
        }

        public ActionResult BrowseByCategory()
        {
            ViewBag.Message = "Your category page.";

            return View();
        }

        public ActionResult BrowseByIngredient()
        {
            ViewBag.Message = "Your ingredients page.";

            return View();
        }

        public ActionResult BrowseByAuthor()
        {
            ViewBag.Message = "Your authors page.";

            return View();
        }

        public ActionResult BrowseAllRecipes()
        {
            ViewBag.Message = "Your all recipes page.";

            // Get list of Recipes from database
            var allRecipes = db.RECIPEs.ToList();
            List<RECIPE> result = new List<RECIPE>();

            foreach (var recipe in allRecipes)
            {
                RECIPE model = new RECIPE();
                model = recipe;
                result.Add(model);
            }

            return View(result);
        }

        [HttpPost]
        public ActionResult BrowseAllRecipes(string searchCriteria)
        {
            var allRecipes = db.RECIPEs.ToList();
            List<RECIPE> result = new List<RECIPE>();
            result = allRecipes;

            // Validate searchCriteria
            if (String.IsNullOrEmpty(searchCriteria))
            {
                // Add error
                ModelState.AddModelError("", "*Please Enter a Search Term");
            }
            else
            {
                // Clear model
                result.Clear();

                // Populate the list
                var searchRecipes = from r in db.RECIPEs
                                    where r.NAME.Contains(searchCriteria)
                                    orderby r.NAME
                                    select r;
                foreach (RECIPE r in searchRecipes)
                {
                    result.Add(r);
                }
            }

            return View(result);
        }

        [HttpPost]
        public ActionResult BrowseByAuthor(BrowseByAuthor fromAuthorSearch)
        {
            int uAuthor = Int32.Parse(fromAuthorSearch.AuthorSelected);
            List<RECIPE> result = new List<RECIPE>();

            var authorRecipes = from c in db.RECIPEs
                                where c.AUTHOR_ID == uAuthor
                                select c;

            foreach (RECIPE r in authorRecipes)
            {
                result.Add(r);
            }

            return View(result);
        }

        [HttpPost]
        public ActionResult BrowseByCategory(BrowseByCategory fromCategorySearch)
        {
            int uCat = Int32.Parse(fromCategorySearch.CategorySelected);
            List<RECIPE> result = new List<RECIPE>();

            var catRecipes = from c in db.RECIPEs
                             where c.CATEGORY_ID == uCat
                             select c;

            foreach (RECIPE r in catRecipes)
            {
                result.Add(r);
            }

            return View(result);
        }
    }
}