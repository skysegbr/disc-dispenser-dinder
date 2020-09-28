using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinderDisc.Data;
using FinderDisc.Models;

namespace FinderDisc.Pages.Dispensers
{
    public class DeleteModel : PageModel
    {
        private readonly FinderDisc.Data.SchoolContext _context;

        public DeleteModel(FinderDisc.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dispenser Dispenser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dispenser = await _context.Dispenser.FirstOrDefaultAsync(m => m.DispenserId == id);

            if (Dispenser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dispenser = await _context.Dispenser.FindAsync(id);

            if (Dispenser != null)
            {
                _context.Dispenser.Remove(Dispenser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
