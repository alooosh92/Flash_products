namespace Flash_products.Repository
{
    public class RepProduct : IRepProduct
    {
        readonly ApplicationDbContext db;

        public RepProduct(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateProduct(VMProduct product)
        {
            try { 
                Products pro = new Products
                {
                    Id = Guid.NewGuid().ToString(),
                    Create_date = DateTime.Now,
                    Categorie = await db.Categories.FindAsync(product.Categorie),
                    Duration = product.Duration,
                    Name_ar = product.Name_ar,
                    Name_en = product.Name_en,
                    Price = product.Price,
                    Start_date = product.Start_date,
                };
                await db.Products.AddAsync(pro);
                await db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> DeleteProduct(string id)
        {
            try
            {
                Products pro = await db.Products.Where(C => C.Id == id).SingleOrDefaultAsync();
                db.Products.Remove(pro);
                await db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<List<Products>> GetAllProducts()
        {
            try
            {
                List<Products> pros = await db.Products.Include(a=>a.Categorie).Where(p=> DateTime.Now>= p.Start_date && DateTime.Now<= p.Start_date.AddDays(p.Duration)).ToListAsync();
                return pros;
            }
            catch { throw; }
        }

        public async Task<Products> GetProduct(string id)
        {
            try
            {
                Products pro = await db.Products.Include(a => a.Categorie).Where(C => C.Id == id).SingleOrDefaultAsync();
                return pro;
            }
            catch { throw; }
        }

        public async Task<bool> UpdateProduct(Products product)
        {
            try
            {
                Products pro = await db.Products.FindAsync(product.Id);
                pro.Categorie = await db.Categories.FindAsync(product.Categorie);
                pro.Duration = product.Duration;
                pro.Name_ar = product.Name_ar;
                pro.Name_en = product.Name_en;
                pro.Price = product.Price;
                pro.Start_date = product.Start_date;                
                db.Products.Update(pro);
                await db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
