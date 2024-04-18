using Item_Books.Data.Models;
using Item_Books.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Item_Books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public async Task<List<Book>> GetAllBooks() => await _context.Books.ToListAsync();

        public async Task<Book?> GetBookById(int bookId)
        {
            return await _context.Books.FirstOrDefaultAsync(n => n.Id == bookId);
        }
    }
}
