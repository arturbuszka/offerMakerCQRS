using Microsoft.AspNetCore.Mvc;
using OfferMakerForCggCQRS.Application.Products.Commands.CreateProduct;
using OfferMakerForCggCQRS.Application.Products.Queries.GetProductsList;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Web.Controllers
{
    [Route("product/menu")]
    public class ProductMenuController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProductMenuCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpGet]
        public async Task<ActionResult<ProductsMenuListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetProductsMenuListQuery()));
        }

    }
}
