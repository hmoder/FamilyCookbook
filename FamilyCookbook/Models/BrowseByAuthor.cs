using System.Collections.Generic;
using System.Web.Mvc;

namespace FamilyCookbook.Models
{
    public class BrowseByAuthor
    {
        public string AuthorSelected { get; set; }
        public IEnumerable<SelectListItem> AllAuthorOptions { get; set; }
    }
}