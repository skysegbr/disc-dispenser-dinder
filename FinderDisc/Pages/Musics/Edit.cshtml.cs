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

namespace FinderDisc.Pages.Musics
{
    public class EditModel : PageModel
    {
        private readonly FinderDisc.Data.SchoolContext _context;

        public EditModel(FinderDisc.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Music Music { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Music = await _context.Music
                .Include(m => m.Band).FirstOrDefaultAsync(m => m.MusicId == id);

            if (Music == null)
            {
                return NotFound();
            }
           ViewData["BandId"] = new SelectList(_context.Band, "BandId", "BandId");
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

            _context.Attach(Music).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicExists(Music.MusicId))
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

        private bool MusicExists(int id)
        {
            return _context.Music.Any(e => e.MusicId == id);
        }
    }
}
