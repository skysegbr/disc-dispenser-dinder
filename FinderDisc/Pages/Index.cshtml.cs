using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinderDisc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinderDisc.Pages
{
    public class IndexModel : PageModel
    {
        private readonly FinderDisc.Data.SchoolContext _context;

        public IndexModel(FinderDisc.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Music> Music { get;set; }

        public async Task OnGetAsync()
        {
            Music = await _context.Music
                .Include(m => m.Band).ToListAsync();
        }

 
    }
}
