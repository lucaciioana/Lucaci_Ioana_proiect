using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lucaci_Ioana_ProiectFinal.Data;
using Lucaci_Ioana_ProiectFinal.Models;

namespace Lucaci_Ioana_ProiectFinal.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly Lucaci_Ioana_ProiectFinal.Data.Lucaci_Ioana_ProiectFinalContext _context;

        public IndexModel(Lucaci_Ioana_ProiectFinal.Data.Lucaci_Ioana_ProiectFinalContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync()
        {
            Article = await _context.Article
                .Include(a =>  a.Author)
                .Include(a => a.Category)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
