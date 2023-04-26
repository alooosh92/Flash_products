namespace Flash_products.Models
{
    public class House_fields
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        public int Room { get; set; }
        [Required]
        public string? Type { get; set; }
        public Products? Product { get; set; }
    }
}