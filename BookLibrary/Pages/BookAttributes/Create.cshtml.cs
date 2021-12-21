#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookLibrary.Models;

namespace BookLibrary.Pages.BookAttributes
{
    public class CreateModel : PageModel
    {
        private readonly BookLibrary.Models.BookLibraryDBContext _context;

        public CreateModel(BookLibrary.Models.BookLibraryDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookAttribute BookAttribute { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookAttributes.Add(BookAttribute);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
