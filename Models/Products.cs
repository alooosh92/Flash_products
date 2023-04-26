namespace Flash_products.Models
{
    public class Products
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name_ar { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name_en { get; set; }
        [Required]
        public DateTime Create_date { get; set; } 
        [Required]
        public DateTime Start_date { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public double Price { get; set; }
        public Categories? Categorie { get; set; }

    }
}
