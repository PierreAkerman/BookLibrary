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

        public async Task OnPostSearch(string SearchTerm)
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                IQueryable<Book> books = (IQueryable<Book>)_context.Books.Where(b => b.Title.ToLower().Contains(SearchTerm.ToLower()))
                        .Include(b => b.Atribute)
                        .Include(b => b.Author)
                        .Include(b => b.Category);

                Book = await books.AsNoTracking().ToListAsync();
            }
            else
            {
                IQueryable<Book> books = (IQueryable<Book>)_context.Books.OrderBy(b => b.Title)
                        .Include(b => b.Atribute)
                        .Include(b => b.Author)
                        .Include(b => b.Category);

                Book = await books.AsNoTracking().ToListAsync();
            }

        }
        public async Task OnGetAsync(string sortOrder)
        {
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title" : "";
            AuthorSort = String.IsNullOrEmpty(sortOrder) ? "author" : "";
            CategorySort = String.IsNullOrEmpty(sortOrder) ? "category" : "";

            IQueryable<Book> books = from s in _context.Books//.OrderBy(b => b.Title)
                        .Include(b => b.Atribute)
                        .Include(b => b.Author)
                        .Include(b => b.Category)
                        select s;

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

            //Book = await _context.Books.OrderBy(b => b.Title)
            //    .Include(b => b.Atribute)
            //    .Include(b => b.Author)
            //    .Include(b => b.Category).ToListAsync();
        }
    }
}
