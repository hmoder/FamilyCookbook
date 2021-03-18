using System.Linq;
using System.Web.Mvc;
using FamilyCookbook.Models;
using FamilyCookbook.Models.EntityFramework;

namespace FamilyCookbook.Controllers
{
    public class BrowseByCategoryController : Controller
    {
        // Connect to database
        CookbookEntities db = new CookbookEntities();

        // GET: BrowseByCategory
        public ActionResult BrowseByCategory()
        {
            BrowseByCategory model = new BrowseByCategory();

            var categories = db.CATEGORies.ToList().Select(s => new SelectListItem
            {
                Text = s.DESCRIPTION,
                Value = s.CATEGORY_ID.ToString()
            });

            return PartialView("~/Views/Shared/_BrowseByCategory.cshtml", new BrowseByCategory { AllCategoryOptions = categories });
        }
    }
}