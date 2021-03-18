using System.Collections.Generic;
using System.Web.Mvc;

namespace FamilyCookbook.Models
{
    public class BrowseByCategory
    {
        public string CategorySelected { get; set; }
        public IEnumerable<SelectListItem> AllCategoryOptions { get; set; }
    }
}