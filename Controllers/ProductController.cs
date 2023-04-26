using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flash_products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IRepProduct repProduct;

        public ProductController(IRepProduct repProduct)
        {
            this.repProduct = repProduct;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<List<VMViewProduct>>> Get()
        {
            try
            {

                var lang = Request.GetTypedHeaders().AcceptLanguage[0].ToString();
                var prod = await repProduct.GetAllProducts();
                List<VMViewProduct> VMproducts = new List<VMViewProduct>();
                foreach (var product in prod)
                {
                    VMViewProduct mProduct = new VMViewProduct
                    {
                        Categorie = lang == "ar" ? product.Categorie!.Name_ar : product.Categorie!.Name_en,
                        Duration = product.Duration,
                        Name = lang == "ar" ? product.Name_ar : product.Name_en,
                        Price = product.Price,
                        Start_date = product.Start_date,
                    };
                    VMproducts.Add(mProduct);
                }
                return VMproducts;
            }
            catch { throw; }
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<VMViewProduct>> Get(string id)
        {
            try
            {
                var lang = Request.GetTypedHeaders().AcceptLanguage[0].ToString();
                Products product = await repProduct.GetProduct(id);
                VMViewProduct viewProduct = new VMViewProduct
                {
                    Categorie = lang == "ar" ? product.Categorie!.Name_ar : product.Categorie!.Name_en,
                    Duration = product.Duration,
                    Name = lang == "ar" ? product.Name_ar : product.Name_en,
                    Price = product.Price,
                    Start_date = product.Start_date,
                };
                return viewProduct;
            }
            catch { throw; }
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Employee")]
        public async Task<ActionResult<bool>> Post([FromBody] VMProduct product)
        {
            try
            {
                await repProduct.CreateProduct(product);
                return true;
            }
            catch { throw; }
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles ="Admin,Employee")]
        public async Task<ActionResult<bool>> Put([FromBody] Products product)
        {
            try
            {
                await repProduct.UpdateProduct(product);
                return true;
            }
            catch { throw; }
        }
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles ="Admin,Employee")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            try
            {
                return await repProduct.DeleteProduct(id);
            }
            catch { throw; }
        }
    }
}
