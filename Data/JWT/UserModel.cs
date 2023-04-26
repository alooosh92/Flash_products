namespace Flash_products.Data.JWT
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        public string? UserName { get; set; }
        [Required]
        [MinLength(6)]
        public string? Password { get; set; }
    }
}
