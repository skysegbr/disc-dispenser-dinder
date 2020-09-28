using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinderDisc.Data;
using FinderDisc.Models;

namespace FinderDisc.Pages.Dispensers
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
            return Page();
        }

        [BindProperty]
        public Dispenser Dispenser { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dispenser.Add(Dispenser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
