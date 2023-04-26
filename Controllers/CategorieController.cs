namespace Flash_products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        readonly IRepCategory repCategory;

        public CategorieController(IRepCategory repCategory)
        {
            this.repCategory = repCategory;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Categories>>> Get()
        {
            try
            {
                return await repCategory.GetAllCategories();
            }
            catch { throw; }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Categories>> Get(int id)
        {
            try
            {
                return await repCategory.GetCategory(id);
            }
            catch { throw; }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                return await repCategory.DeleteCategory(id);
            }
            catch { throw; }
        }
    }
}
