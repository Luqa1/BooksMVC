using BooksMVC.DTOs;
using BooksMVC.ViewModel;

namespace BooksMVC.Repositories
{
    public interface IBooksRepository
    {
        Task<IEnumerable<BookVm>> GetAllBooksAsync(CancellationToken cancellationToken = default);
        Task<BookVm> GetBookAsync(int id, CancellationToken cancellationToken = default);
        Task<int> AddBookAsync(NewBookDTO newBookDTO, CancellationToken cancellationToken = default);
    }
}
