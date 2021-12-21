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
    public class DetailsModel : PageModel
    {
        private readonly BookLibrary.Models.BookLibraryDBContext _context;

        public DetailsModel(BookLibrary.Models.BookLibraryDBContext context)
        {
            _context = context;
        }

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
    }
}
