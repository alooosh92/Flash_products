namespace Flash_products.Models
{
    public class Car_fields
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        public int Engine_size { get; set; }
        [Required]
        public string? Enging_type { get; set; }
        [Required]
        public string? Car_type { get; set; }
        public Products? Product { get; set; }
    }
}
