using BooksMVC.DTOs;
using BooksMVC.ViewModel;

namespace BookMVC.DAL.Mappers
{
    internal static class BookMapper
    {
        public static BookVm MapToVm(this Book book)
        {
            return new BookVm
            {
                Id = book.Id,
                Author = book.Author,
                Index = book.Index,
                Price = book.Price,
                Title = book.Title
            };
        }

        public static Book MapToEntity(this NewBookDTO book)
        {
            return new Book
            {
                Author = book.Author,
                Index = book.Index,
                Price = book.Price,
                Title = book.Title
            };
        }
    }
}
