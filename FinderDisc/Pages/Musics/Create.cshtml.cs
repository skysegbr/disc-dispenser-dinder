using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinderDisc.Data;
using FinderDisc.Models;

namespace FinderDisc.Pages.Musics
{
    public class CreateModel : PageModel
    {
        private readonly FinderDisc.Data.SchoolContext _context;

        public CreateModel(FinderDisc.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BandId"] = new SelectList(_context.Band, "BandId", "BandId");
            return Page();
        }

        [BindProperty]
        public Music Music { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Music.Add(Music);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
