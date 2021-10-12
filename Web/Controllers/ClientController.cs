﻿using Microsoft.AspNetCore.Mvc;
using OfferMakerForCggCQRS.Application.Clients.Commands.CreateClientCommand;
using OfferMakerForCggCQRS.Application.Clients.Commands.DeleteClientCommand;
using OfferMakerForCggCQRS.Application.Clients.Commands.UpdateClientCommand;
using OfferMakerForCggCQRS.Application.Clients.Queries.GetClientDetail;
using OfferMakerForCggCQRS.Application.Clients.Queries.GetClientsList;
using OfferMakerForCggCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Web.Controllers
{
    [Route("client")]
    public class ClientController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateClientCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetClientDetailQuery { Id = id }));
        }

        [HttpGet]
        public async Task<ActionResult<ClientsListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetClientsListQuery()));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateClientCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await Mediator.Send(new DeleteClientCommand { ClientId = id });

            return NoContent();
        }
    }
}
