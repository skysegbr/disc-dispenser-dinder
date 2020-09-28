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
    public class DetailsModel : PageModel
    {
        private readonly FinderDisc.Data.SchoolContext _context;

        public DetailsModel(FinderDisc.Data.SchoolContext context)
        {
            _context = context;
        }

        public Disc Disc { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Disc = await _context.Disc
                .Include(d => d.Dispenser)
                .Include(d => d.Music).FirstOrDefaultAsync(m => m.DiscId == id);

            if (Disc == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
