namespace BookMVC.DAL
{
    internal class BooksContext
    {
        public BooksContext()
        {
            Books = new List<Book>();

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


        public List<Book> Books { get; set; }
    }
}
