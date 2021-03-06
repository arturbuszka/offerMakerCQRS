using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace OfferMakerForCggCQRS.Web.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator
        {
            get
            {
                if (_mediator == null)
                {
                    return _mediator = HttpContext.RequestServices.GetService<IMediator>();
                }
                return _mediator;
            }
        }



    }
}
