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
    public class IndexModel : PageModel
    {
        private readonly BookLibrary.Models.BookLibraryDBContext _context;

        public IndexModel(BookLibrary.Models.BookLibraryDBContext context)
        {
            _context = context;
        }

        public IList<BookAttribute> BookAttribute { get;set; }

        public async Task OnGetAsync()
        {
            BookAttribute = await _context.BookAttributes.ToListAsync();
        }
    }
}
