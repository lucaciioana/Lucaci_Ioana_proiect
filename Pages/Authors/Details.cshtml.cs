using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lucaci_Ioana_ProiectFinal.Data;
using Lucaci_Ioana_ProiectFinal.Models;

namespace Lucaci_Ioana_ProiectFinal.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Lucaci_Ioana_ProiectFinal.Data.Lucaci_Ioana_ProiectFinalContext _context;

        public DetailsModel(Lucaci_Ioana_ProiectFinal.Data.Lucaci_Ioana_ProiectFinalContext context)
        {
            _context = context;
        }

        public Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = await _context.Author
                .Include(a => a.Articles)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
