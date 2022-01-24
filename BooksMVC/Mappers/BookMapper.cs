using BooksMVC.API.DTOs;
using BooksMVC.API.ViewModel;
using BooksMVC.Application.Model;

namespace BooksMVC.API.Mappers
{
    internal static class BookMapper
    {
        public static BookVm ToVm(this Book book)
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

        public static Book ToApplicationModel(this NewBookDTO book)
        {
            return new Book
            {
                Author = book.Author,
                Index = book.Index,
                Price = book.Price,
                Title = book.Title
            };
        }

        public static Book ToApplicationModel(this UpdateBookDTO book)
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
