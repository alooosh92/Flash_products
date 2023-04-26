namespace Flash_products.Repository
{
    public class RepEmployee : IRepEmployee
    {
        readonly ApplicationDbContext db;
        readonly RoleManager<IdentityRole> roleManager;
        readonly UserManager<IdentityUser> userManager;

        public RepEmployee(ApplicationDbContext db, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<bool> CreateEmployee(VMEmployee employee)
        {
            try
            {
                IdentityUser newUser = new IdentityUser { Email = employee.email, UserName = employee.email};
                var res = await userManager.CreateAsync(newUser, employee.password);
                IdentityUser user = await userManager.FindByEmailAsync(employee.email);
                IdentityRole role =await roleManager.FindByNameAsync(employee.role);
                await userManager.AddToRoleAsync(user, role.Name);
                return true;
            }
            catch { throw; }
        }

        public async Task<bool> DeleteEmployee(string email)
        {
            try
            {
                IdentityUser user = await userManager.FindByEmailAsync(email);
                await  userManager.DeleteAsync(user);
                return true;
            }
            catch { throw; }
        }

        public async Task<List<VMEmployee>> GetAllEmployees()
        {
            try {
                var usersAdmin = await userManager.GetUsersInRoleAsync("ADMIN");
                var usersEmployee = await userManager.GetUsersInRoleAsync("EMPLOYEE");
                List<VMEmployee> employees = new List<VMEmployee>();
                foreach (var user in usersAdmin)
                {
                    var employee = new VMEmployee
                    {
                        email = user.Email,
                        role = "Admin",
                    };
                    employees.Add(employee);
                }
                foreach (var user in usersEmployee)
                {
                    var employee = new VMEmployee
                    {
                        email = user.Email,
                        role = "Employee",
                    };
                    employees.Add(employee);
                }
                return employees;
            }
            catch { throw; }
        }

        public async Task<List<IdentityRole>> GetAllRoles()
        {
            try {
                var roles = roleManager.Roles;
                return await roles.ToListAsync();
            }
            catch { throw; }
        }      

        public async Task<bool> UpdateEmployee(VMEmployee employee)
        {
            try
            {
               
                IdentityUser user = await userManager.FindByEmailAsync(employee.email);
                IdentityRole role = await roleManager.FindByNameAsync(employee.role);
                var roles = await userManager.GetRolesAsync(user);
                await userManager.RemoveFromRolesAsync(user,roles.ToArray());
                await userManager.AddToRoleAsync(user, role.Name);
                return true;
            }
            catch { throw; }
        }
    }
}
