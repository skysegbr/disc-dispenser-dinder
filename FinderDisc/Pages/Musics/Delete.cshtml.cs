using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinderDisc.Data;
using FinderDisc.Models;

namespace FinderDisc.Pages.Musics
{
    public class DeleteModel : PageModel
    {
        private readonly FinderDisc.Data.SchoolContext _context;

        public DeleteModel(FinderDisc.Data.SchoolContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Music = await _context.Music.FindAsync(id);

            if (Music != null)
            {
                _context.Music.Remove(Music);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
