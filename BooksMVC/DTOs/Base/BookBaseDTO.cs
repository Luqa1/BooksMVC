namespace BooksMVC.API.DTOs.Base
{
    public abstract class BookBaseDTO
    {
        public string? Index { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public float Price { get; set; }
    }
}
