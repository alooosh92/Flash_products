using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flash_products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IRepEmployee repEmployee;

        public EmployeeController(IRepEmployee repEmployee)
        {
            this.repEmployee = repEmployee;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<VMEmployee>>> Get()
        {
            try
            {
                return await repEmployee.GetAllEmployees();
            }
            catch { throw; }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<bool>> Post([FromBody] VMEmployee employee)
        {
            try
            {
                return await repEmployee.CreateEmployee(employee);
            }catch { throw; }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<bool>> Put([FromBody] VMEmployee employee)
        {
            try
            {
                return await repEmployee.UpdateEmployee(employee);
            }
            catch { throw; }
        }

        [HttpDelete]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<bool>> Delete(string email)
        {
            try
            {
                return await repEmployee.DeleteEmployee(email);
            }
            catch { throw; }
        }
    }
}
