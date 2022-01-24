using BooksMVC.Application.Model;

namespace BooksMVC.Application.Repositories
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(CancellationToken cancellationToken = default);
        Task<Book> GetBookAsync(int id, CancellationToken cancellationToken = default);
        Task<int> AddBookAsync(Book book, CancellationToken cancellationToken = default);

        Task UpdateBookAsync(Book book, CancellationToken cancellationToken = default);
        Task DeleteBookAsync(int id, CancellationToken cancellationToken = default);
    }
}
