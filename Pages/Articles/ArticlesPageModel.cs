using Lucaci_Ioana_ProiectFinal.Data;
using Lucaci_Ioana_ProiectFinal.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lucaci_Ioana_ProiectFinal.Pages.Articles
{
    public class ArticlesPageModel : PageModel
    {
        public SelectList AuthorNames { get; set; }
        public SelectList CategoryNames { get; set; }

        public void PopulateAuthorsDropDownList(Lucaci_Ioana_ProiectFinalContext _context, object selectedAuthor = null)
        {
            var authorsQuery = _context.Author
                            .OrderBy(a => a.LastName)
                             .Select(a => new
                               {
                                   Text = a.FirstName + " '" + a.Nickname + "' " + a.LastName,
                                   Value = a.ID
                               });

            AuthorNames = new SelectList(authorsQuery.AsNoTracking(), "Value", "Text", selectedAuthor);
        }

        public void PopulateCategoriesDropDownList(Lucaci_Ioana_ProiectFinalContext _context, object selectedCategories = null)
        {
            var categoriesQuery = _context.Category
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    Text = c.Name,
                    Value = c.ID
                });
            CategoryNames = new SelectList(categoriesQuery.AsNoTracking(), "Value", "Text", selectedCategories);
        }
    }
}
