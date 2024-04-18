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

        public async Task AddBook(BookVM book)
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
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllBooks() => await _context.Books.ToListAsync();

        public async Task<Book?> GetBookById(int bookId)
        {
            return await _context.Books.FirstOrDefaultAsync(n => n.Id == bookId);
        }

        public async Task<Book> UpdateBookById(int bookId, BookVM book)
        {
            var _book = await _context.Books.FirstOrDefaultAsync(n => n.Id == bookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;

                await _context.SaveChangesAsync();
            }

            return _book;
        }

        public async Task DeleteBookById(int bookId)
        {
            var _book = await _context.Books.FirstOrDefaultAsync(n => n.Id == bookId);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
