using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinderDisc.Data;
using FinderDisc.Models;

namespace FinderDisc.Pages.Discs
{
    public class IndexModel : PageModel
    {
        private readonly FinderDisc.Data.SchoolContext _context;

        public IndexModel(FinderDisc.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Disc> Disc { get;set; }

        public async Task OnGetAsync()
        {
            Disc = await _context.Disc
                .Include(d => d.Dispenser)
                .Include(d => d.Music).ToListAsync();
        }
    }
}
