namespace Flash_products.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name_ar { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name_en { get; set; }

    }
}
