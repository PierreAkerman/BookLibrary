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
    public class IndexModel : PageModel
    {
        private readonly BookLibrary.Models.BookLibraryDBContext _context;

        public IndexModel(BookLibrary.Models.BookLibraryDBContext context)
        {
            _context = context;
        }

        public IList<LoanRecord> LoanRecord { get;set; }

        public async Task OnGetAsync()
        {
            LoanRecord = await _context.LoanRecords
                .Include(l => l.Book)
                .Include(l => l.Customer).ToListAsync();
        }
    }
}
