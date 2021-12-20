#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookLibrary.Models;

namespace BookLibrary.Pages.Books
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
        ViewData["AtributeId"] = new SelectList(_context.BookAttributes, "Id", "Size");
        ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Fullname");
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Category1");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
