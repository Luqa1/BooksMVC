using BooksMVC.DAL.Entities;

namespace BooksMVC.DAL
{
    internal class BooksContext
    {
        public BooksContext()
            : this(false)
        {
        }

        public BooksContext(bool initByTestData)
        {
            Books = new List<Book>();

            if (initByTestData)
            {
                Books.Add(new Book
                {
                    Id = 1,
                    Index = "1112233",
                    Title = "Tajniki C#",
                    Author = "Nieznany",
                    Price = 99
                });

                Books.Add(new Book
                {
                    Id = 2,
                    Index = "678546757894",
                    Title = "Tajniki Javascript",
                    Author = "Również nieznany",
                    Price = 89
                });
            }
        }


        public List<Book> Books { get; set; }
    }
}
