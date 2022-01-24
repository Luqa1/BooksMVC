namespace BooksMVC.DAL.Entities
{
    class Book
    {
        public int Id { get; set; }
        public string? Index { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public float Price { get; set; }
    }
}