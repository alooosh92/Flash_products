namespace Flash_products.Repository
{
    public class RepCategory : IRepCategory
    {
        readonly ApplicationDbContext db;

        public RepCategory(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                Categories  cat = await db.Categories.Where(C=>C.Id == id).SingleOrDefaultAsync();
                db.Categories.Remove(cat);
                await db.SaveChangesAsync();
                return true;
            }catch { return false; }
        }

        public async Task<List<Categories>> GetAllCategories()
        {
            try {
                List<Categories> cats =await db.Categories.ToListAsync();
                return cats;
            }catch { throw; }
        }

        public async Task<Categories> GetCategory(int id)
        {
            try
            {
                Categories cat = await db.Categories.Where(C => C.Id == id).SingleOrDefaultAsync();                
                return cat;
            }
            catch { throw; }
        }
    }
}
