namespace Flash_products.Data.JWT
{
    public class RefreshToken
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        public string? UserId { get; set; }
        [Required]
        public string? Token { get; set; }
        [Required]
        public DateTime? Expirson { get; set; }      
        [Required]
        public DateTime? CreatedOn { get; set; }
        [AllowNull]
        public DateTime? RevokedON { get; set; }
    }
}
