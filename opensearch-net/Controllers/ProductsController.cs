

namespace opensearch_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product request)
       => Ok(await _productService.InsertAsync(request));

        [HttpGet]
        public async Task<IActionResult> Filter(string text)
           => Ok(await _productService.FilterAsync(text));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
          => Ok(await _productService.GetByIdAsync(id));
    }
}
