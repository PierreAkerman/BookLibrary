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
    public class DetailsModel : PageModel
    {
        private readonly BookLibrary.Models.BookLibraryDBContext _context;

        public DetailsModel(BookLibrary.Models.BookLibraryDBContext context)
        {
            _context = context;
        }

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
    }
}
