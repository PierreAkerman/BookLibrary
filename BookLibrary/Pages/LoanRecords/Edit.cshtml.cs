#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Models;

namespace BookLibrary.Pages.LoanRecords
{
    public class EditModel : PageModel
    {
        private readonly BookLibrary.Models.BookLibraryDBContext _context;

        public EditModel(BookLibrary.Models.BookLibraryDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoanRecord LoanRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LoanRecord = await _context.LoanRecords
                .Include(l => l.Book)
                .Include(l => l.Customer).FirstOrDefaultAsync(m => m.Id == id);

            if (LoanRecord == null)
            {
                return NotFound();
            }
           ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title");
           ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Fullname");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LoanRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanRecordExists(LoanRecord.Id))
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

        private bool LoanRecordExists(int id)
        {
            return _context.LoanRecords.Any(e => e.Id == id);
        }
    }
}
