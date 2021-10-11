using Microsoft.AspNetCore.Mvc;
using OfferMakerForCggCQRS.Application.Products.Commands.CreateProductCommand;
using OfferMakerForCggCQRS.Application.Products.Commands.DeleteProductCommand;
using OfferMakerForCggCQRS.Application.Products.Commands.UpdateProductCommand;
using OfferMakerForCggCQRS.Application.Products.Queries.GetProductDetail;
using OfferMakerForCggCQRS.Application.Products.Queries.GetProductsList;
using OfferMakerForCggCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Web.Controllers
{
    [Route("product")]
    public class ProductController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProductCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetProductDetailQuery { Id = id }));
        }

        [HttpGet]
        public async Task<ActionResult<ProductsListVm>> GetAll()
        {

            return Ok(await Mediator.Send(new GetProductsListQuery()));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }
    }
}
