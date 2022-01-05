#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Models;

namespace BookLibrary.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookLibrary.Models.BookLibraryDBContext _context;

        public IndexModel(BookLibrary.Models.BookLibraryDBContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }
        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string CategorySort { get; set; }
        public string SearchTerm { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder, string SearchTerm)
        {
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title" : "";
            AuthorSort = String.IsNullOrEmpty(sortOrder) ? "author" : "";
            CategorySort = String.IsNullOrEmpty(sortOrder) ? "category" : "";
            CurrentFilter = SearchTerm;

            IQueryable<Book> books = from s in _context.Books
                        .Include(b => b.Atribute)
                        .Include(b => b.Author)
                        .Include(b => b.Category)
                        select s;

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                books = books.Where(b => b.Title.ToLower().Contains(SearchTerm.ToLower())
                                                || b.Author.Firstname.ToLower().Contains(SearchTerm.ToLower())
                                                || b.Author.Lastname.ToLower().Contains(SearchTerm.ToLower())
                                                || b.Category.Category1.ToLower().Contains(SearchTerm.ToLower())
                                                || b.Description.ToLower().Contains(SearchTerm.ToLower()));
            }
                
            switch (sortOrder)
            {
                case "author":
                    books = books.OrderBy(s => s.Author.Firstname);
                    break;
                case "category":
                    books = books.OrderBy(s => s.Category.Category1);
                    break;
                case "title":
                    books = books.OrderBy(s => s.Title);
                    break;
                default:
                    books = books.OrderBy(b => b.Title);
                    break;
            }

            Book = await books.AsNoTracking().ToListAsync();
        }
    }
}
