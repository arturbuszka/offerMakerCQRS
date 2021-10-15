using Microsoft.AspNetCore.Mvc;
using OfferMakerForCggCQRS.Application.Products.Commands.CreateProductCommand;
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

        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProductMenu>> Get([FromRoute] int id)
        //{
        //    return Ok(await Mediator.Send(new GetProductDetailQuery { Id = id }));
        //}

        [HttpGet]
        public async Task<ActionResult<ProductsMenuListVm>> GetAll()
        {

            return Ok(await Mediator.Send(new GetProductsMenuListQuery()));
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        //{

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete([FromRoute] int id)
        //{
        //    await Mediator.Send(new DeleteProductCommand { Id = id });

        //    return NoContent();
        //}
    }
}
