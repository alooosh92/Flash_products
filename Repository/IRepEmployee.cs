namespace Flash_products.Repository
{
    public interface IRepEmployee
    {
        public Task<List<IdentityRole>> GetAllRoles();
        public Task<List<VMEmployee>> GetAllEmployees();
        public Task<bool> CreateEmployee(VMEmployee employee);
        public Task<bool> UpdateEmployee(VMEmployee employee);
        public Task<bool> DeleteEmployee(string id);
    }
}
