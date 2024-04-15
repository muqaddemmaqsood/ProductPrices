using Microsoft.AspNetCore.Mvc;
using Product_Prices.Services;
using Product_Prices.ViewModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Product_Prices.Controllers
{
    [ApiController]
    [Route("api/chat")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost("addUpdatePrice")]
        [SwaggerOperation(Summary = "AddUpdatePrice")]
        public async Task<IActionResult> SubmitPrices(List<RequestAddProductPrices> model)
        {

            bool status = await productService.UpdatePrices(model);
            if (status)
                return Ok(new { Message = "Added Successfully", Status = true });
            else
                return BadRequest(new { Message = "Failed to update data", Status = false });
        }
    }
}
