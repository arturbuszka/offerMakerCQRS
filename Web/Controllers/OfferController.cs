using Microsoft.AspNetCore.Mvc;
using OfferMakerForCggCQRS.Application.Common.Models;
using OfferMakerForCggCQRS.Application.Offers.Commands;
using OfferMakerForCggCQRS.Application.Offers.Commands.ConvertOfferToPdf;
using OfferMakerForCggCQRS.Application.Offers.Commands.DeleteOffer;
using OfferMakerForCggCQRS.Application.Offers.Commands.UpdateOffer;
using OfferMakerForCggCQRS.Application.Offers.Queries.GetOfferDetail;
using OfferMakerForCggCQRS.Application.Offers.Queries.GetOfferPdf;
using OfferMakerForCggCQRS.Application.Offers.Queries.GetOffersList;
using OfferMakerForCggCQRS.Domain.Entities;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Web.Controllers
{
    [Route("offer")]
    //[Authorize(Policy = "Admin")]
    public class OfferController : BaseController
    {

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOfferCommand command)
        {
           await Mediator.Send(command);
            
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Offer>> Get([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetOfferDetailQuery { Id = id }));
        }


        [HttpGet]
        public async Task<ActionResult<PagedResult<OffersListVm>>> GetAll([FromQuery] PaginationQuery query)
        {
            var pagedResult = await Mediator.Send(new GetOffersListQuery() { Pagination = query });

            return Ok(pagedResult);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateOfferCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await Mediator.Send(new DeleteOfferCommand { Id = id });

            return NoContent();
        }

        [HttpPost("pdf")]
        public async Task<ActionResult<ProductModel>> GeneratePdf(ConvertOfferToPdfCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpGet("pdf/{id}")]
        public async Task<ActionResult<PdfFileModel>> DownloadPdf([FromRoute] int id)
        {
            var file = await Mediator.Send(new GetOfferPdfQuery() { Id = id });

            return File(file.Content, file.ContentType, file.FilePath);
        }

    }
}
