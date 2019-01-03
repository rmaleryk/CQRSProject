using System;
using System.Collections.Generic;
using CQRSProject.Commands.Commands;
using CQRSProject.Commands.Extensibility;
using CQRSProject.Domain.Entities;
using CQRSProject.Queries.Extensibility;
using CQRSProject.Queries.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopItemsController : ControllerBase
    {
        private readonly IQueryDispatcher queryDispatcher;

        private readonly ICommandDispatcher commandDispatcher;

        public ShopItemsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShopItem>> GetByName([FromQuery]string name)
        {
            var query = new FindShopItemsByName(name);
            var shopItems = queryDispatcher.Execute<FindShopItemsByName, IEnumerable<ShopItem>>(query);

            return new OkObjectResult(shopItems);
        }

        [HttpPost]
        public ActionResult Post([FromBody]string itemName)
        {
            var itemId = Guid.NewGuid();
            var command = new CreateShopItem(itemId, itemName);

            commandDispatcher.Execute(command);

            return new CreatedResult("shopitems", itemId);
        }
    }
}