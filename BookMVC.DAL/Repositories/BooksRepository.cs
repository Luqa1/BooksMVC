using BooksMVC.Application.Repositories;
using BooksMVC.DAL.Exceptions;
using BooksMVC.DAL.Mappers;
using ApplicationModel = BooksMVC.Application.Model;

namespace BooksMVC.DAL.Repositories
{
    internal class BooksRepository : IBooksRepository
    {
        private readonly BooksContext _dbContext;

        public BooksRepository(BooksContext booksContext)
        {
            _dbContext = booksContext;
        }

        public Task<int> AddBookAsync(ApplicationModel.Book book, CancellationToken cancellationToken = default)
        {
            var newEntity = book.MapToEntity();
            newEntity.Id = _dbContext.Books.Select(x => x.Id).Max() + 1;
            _dbContext.Books.Add(newEntity);
            return Task.FromResult(newEntity.Id);
        }

        public Task DeleteBookAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = _dbContext.Books.SingleOrDefault(x => x.Id == id);
            if (entity != null)
                _dbContext.Books.Remove(entity);

            return Task.FromResult(() => { });
        }

        public Task<IEnumerable<ApplicationModel.Book>> GetAllBooksAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_dbContext.Books.Select(x => x.MapToApplicationModel()));
        }

        public Task<ApplicationModel.Book> GetBookAsync(int id, CancellationToken cancellationToken = default)
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);
            return Task.FromResult(book?.MapToApplicationModel());
        }

        public Task UpdateBookAsync(ApplicationModel.Book book, CancellationToken cancellationToken = default)
        {
            var entity = _dbContext.Books.SingleOrDefault(x => x.Id == book.Id);
            if (entity == null)
                throw new EntityNotExistsException($"Entity id = {book.Id}");

            entity.Index = book.Index;
            entity.Title = book.Title;
            entity.Author = book.Author;
            entity.Price = book.Price;

            return Task.FromResult(() => { });
        }
    }
}
