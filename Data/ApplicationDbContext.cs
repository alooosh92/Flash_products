namespace Flash_products.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Car_fields> Car_Fields { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<House_fields> House_fields { get; set; }
        public DbSet<Products> Products { get; set; }

    }
}
