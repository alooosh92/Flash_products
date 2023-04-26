namespace Flash_products.Data.JWT
{
    public class AuthModel
    {
        public string? Message { get; set; }
        public bool IsAuthanticated { get; set; }
        public string? Email { get; set; }
        public IList<string>? Roles { get; set; }
        public string? Token { get; set; }      
        public string? RefreshToken { get; set;}
        public DateTime? RefreshTokenExpireson { get; set; }
    }
}
