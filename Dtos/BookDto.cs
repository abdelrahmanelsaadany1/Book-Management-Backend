using System.ComponentModel.DataAnnotations;

namespace Book_Management_Backend.Dtos
{
    public class BookDto
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        public string? Genre { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
