using BooksMVC.DAL.Entities;
using ApplicationModel = BooksMVC.Application.Model;

namespace BooksMVC.DAL.Mappers
{
    internal static class BookMapper
    {
        public static ApplicationModel.Book MapToApplicationModel(this Book book)
        {
            return new ApplicationModel.Book
            {
                Id = book.Id,
                Author = book.Author,
                Index = book.Index,
                Price = book.Price,
                Title = book.Title
            };
        }

        public static Book MapToEntity(this ApplicationModel.Book book)
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
