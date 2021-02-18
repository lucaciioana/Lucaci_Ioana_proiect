using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lucaci_Ioana_ProiectFinal.Data;
using Lucaci_Ioana_ProiectFinal.Models;

namespace Lucaci_Ioana_ProiectFinal.Pages.Articles
{
    public class EditModel : ArticlesPageModel
    {
        private readonly Lucaci_Ioana_ProiectFinal.Data.Lucaci_Ioana_ProiectFinalContext _context;

        public EditModel(Lucaci_Ioana_ProiectFinal.Data.Lucaci_Ioana_ProiectFinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PopulateAuthorsDropDownList(_context);
            PopulateCategoriesDropDownList(_context);

            Article = await _context.Article
               .Include(a => a.Author)
               .Include(a => a.Category)
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.ID == id);

            if (Article == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(Article.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.ID == id);
        }
    }
}
