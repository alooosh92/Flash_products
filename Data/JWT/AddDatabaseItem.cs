namespace Flash_products.Data.JWT
{
    public class AddDatabaseItem
    {
        public static async Task AddRoll(IServiceProvider provider, List<string> roles)
        {
            var scopFactory = provider.GetRequiredService<IServiceScopeFactory>();
            var role = scopFactory.CreateScope();
            var ro = role.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            foreach (string roleName in roles)
            {
                if (!await ro.RoleExistsAsync(roleName))
                {
                    IdentityRole rol = new IdentityRole { Name = roleName, NormalizedName = roleName };
                    await ro.CreateAsync(rol);
                }
            }
        }
        public static async Task AddCategories(IServiceProvider provider)
        {
            var scopFactory = provider.GetRequiredService<IServiceScopeFactory>();
            var categorie = scopFactory.CreateScope();
            var cat = categorie.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            List<Categories> cates = new List<Categories>
            {
                new Categories{
                Name_ar = "شقة",
                Name_en = "Home"
                },
                new Categories{
                Name_ar = "سيارة",
                Name_en = "Car"
                },
            };
            foreach (Categories CategoriesName in cates)
            {
                if (!await cat.Categories.AnyAsync(i => i.Name_en == CategoriesName.Name_en))
                {
                    await cat.Categories.AddAsync(CategoriesName);
                    await cat.SaveChangesAsync();
                }
            }
        }
        public static async Task AddAdmin(IServiceProvider provider, string email)
        {
            var scopFactory = provider.GetRequiredService<IServiceScopeFactory>();
            var user = scopFactory.CreateScope();
            var us = user.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            if (await us.FindByEmailAsync(email) == null)
            {
                IdentityUser use = new IdentityUser
                {
                    Email = email,
                    UserName = email,
                    EmailConfirmed = true,
                };
                var res = await us.CreateAsync(use, "Qweasd12#");
                if (res.Succeeded)
                {
                    await us.AddToRoleAsync(use, "admin");
                }
            }

        }
    }
}
