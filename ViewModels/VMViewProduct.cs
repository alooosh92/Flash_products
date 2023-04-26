namespace Flash_products.ViewModels
{
    public class VMViewProduct
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        public DateTime Start_date { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string? Categorie { get; set; }
    }
}
