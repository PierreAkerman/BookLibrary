#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookLibrary.Models;

namespace BookLibrary.Pages.LoanRecords
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
        ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title");
        ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Fullname");
            return Page();
        }

        [BindProperty]
        public LoanRecord LoanRecord { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LoanRecords.Add(LoanRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
