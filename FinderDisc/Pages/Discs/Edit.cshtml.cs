using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinderDisc.Data;
using FinderDisc.Models;

namespace FinderDisc.Pages.Discs
{
    public class EditModel : PageModel
    {
        private readonly FinderDisc.Data.SchoolContext _context;

        public EditModel(FinderDisc.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["DispenserId"] = new SelectList(_context.Dispenser, "DispenserId", "DispenserId");
           ViewData["MusicId"] = new SelectList(_context.Music, "MusicId", "MusicId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Disc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscExists(Disc.DiscId))
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

        private bool DiscExists(int id)
        {
            return _context.Disc.Any(e => e.DiscId == id);
        }
    }
}
