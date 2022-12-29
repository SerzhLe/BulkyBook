using System.ComponentModel.DataAnnotations;

namespace BulkyBookModels.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }

        [Required]
        [Range(1, 10000)]
        public double PriceIf50 { get; set; }

        [Required]
        [Range(1, 10000)]
        public double PriceIf100 { get; set; }

        public string? ImageUrl { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }

        public int? CoverTypeId { get; set; }

        public CoverType CoverType { get; set; }
    }
}
