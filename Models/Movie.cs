namespace MyMoviesApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        public required string Genre { get; set; }

        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
