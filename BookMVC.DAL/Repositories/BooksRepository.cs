using BookMVC.DAL.Mappers;
using BooksMVC.DTOs;
using BooksMVC.Repositories;
using BooksMVC.ViewModel;

namespace BookMVC.DAL
{
    internal class BooksRepository : IBooksRepository
    {
        private readonly BooksContext _dbContext;

        public BooksRepository(BooksContext booksContext)
        {
            _dbContext = booksContext;
        }

        public Task<int> AddBookAsync(NewBookDTO newBookDTO, CancellationToken cancellationToken = default)
        {
            var newEntity = newBookDTO.MapToEntity();
            newEntity.Id = _dbContext.Books.Select(x => x.Id).Max() + 1;
            _dbContext.Books.Add(newEntity);
            return Task.FromResult(newEntity.Id);
        }

        public Task<IEnumerable<BookVm>> GetAllBooksAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_dbContext.Books.Select(x => x.MapToVm()));
        }

        public Task<BookVm> GetBookAsync(int id, CancellationToken cancellationToken = default)
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);
            return Task.FromResult(book?.MapToVm());
        }
    }
}
