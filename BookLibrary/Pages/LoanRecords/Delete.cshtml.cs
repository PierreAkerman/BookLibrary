#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Models;

namespace BookLibrary.Pages.LoanRecords
{
    public class DeleteModel : PageModel
    {
        private readonly BookLibrary.Models.BookLibraryDBContext _context;

        public DeleteModel(BookLibrary.Models.BookLibraryDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LoanRecord = await _context.LoanRecords.FindAsync(id);

            if (LoanRecord != null)
            {
                _context.LoanRecords.Remove(LoanRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
