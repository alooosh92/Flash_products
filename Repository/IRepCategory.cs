namespace Flash_products.Repository
{
    public interface IRepCategory
    {
        public Task<List<Categories>> GetAllCategories();
        public Task<Categories> GetCategory(int id);
        public Task<bool> DeleteCategory(int id);

    }
}
