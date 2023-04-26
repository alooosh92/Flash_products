namespace Flash_products.ViewModels
{
    public class VMEmployee
    {
        [Required]
        public string? email { get; set; }
        [Required]
        public string? password { get; set; }
        [Required]
        public string? role { get; set; }
    }
}
