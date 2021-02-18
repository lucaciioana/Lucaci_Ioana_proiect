using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lucaci_Ioana_ProiectFinal.Data;
using Lucaci_Ioana_ProiectFinal.Models;

namespace Lucaci_Ioana_ProiectFinal.Pages.Articles
{
    public class CreateModel : ArticlesPageModel
    {
        private readonly Lucaci_Ioana_ProiectFinal.Data.Lucaci_Ioana_ProiectFinalContext _context;

        public CreateModel(Lucaci_Ioana_ProiectFinal.Data.Lucaci_Ioana_ProiectFinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int AuthorID { get; set; }

        public IActionResult OnGet()
        {
            PopulateAuthorsDropDownList(_context);
            PopulateCategoriesDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyArticle = new Article();

            if(await TryUpdateModelAsync(
                emptyArticle,
                "article", // prefix for form value
                article => article.Title, article => article.Description, article => article.Body, article => article.AuthorID, 
                article => article.CategoryID
                )){

                _context.Article.Add(emptyArticle);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            //Select AuthorID if TryModelAsync fails.
            PopulateAuthorsDropDownList(_context, emptyArticle.AuthorID);
            PopulateCategoriesDropDownList(_context, emptyArticle.CategoryID);
            return Page();
            //return RedirectToPage("./Index");
        }
    }
}
