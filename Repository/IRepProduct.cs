namespace Flash_products.Repository
{
    public interface IRepProduct
    {
        public Task<List<Products>> GetAllProducts();
        public Task<Products> GetProduct(string id);
        public Task<bool> CreateProduct(VMProduct product);
        public Task<bool> UpdateProduct(VMUpdateProduct product);
        public Task<bool> DeleteProduct(string id);
    }
}
