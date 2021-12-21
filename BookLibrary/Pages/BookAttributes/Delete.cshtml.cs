#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Models;

namespace BookLibrary.Pages.BookAttributes
{
    public class DeleteModel : PageModel
    {
        private readonly BookLibrary.Models.BookLibraryDBContext _context;

        public DeleteModel(BookLibrary.Models.BookLibraryDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookAttribute BookAttribute { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookAttribute = await _context.BookAttributes.FirstOrDefaultAsync(m => m.Id == id);

            if (BookAttribute == null)
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

            BookAttribute = await _context.BookAttributes.FindAsync(id);

            if (BookAttribute != null)
            {
                _context.BookAttributes.Remove(BookAttribute);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
