using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSProject.Commands.Commands;
using CQRSProject.Commands.Extensibility;
using CQRSProject.Core.Entities;
using CQRSProject.Queries.Extensibility;
using CQRSProject.Queries.Queries;
using CQRSProject.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IQueryDispatcher queryDispatcher;

        private readonly ICommandDispatcher commandDispatcher;

        public UsersController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLocationRequestModel>>> GetByUserId([FromQuery]Guid userId)
        {
            var query = new GetUserActivityByIdQuery(userId);
            var userActivities = await queryDispatcher.ExecuteAsync<GetUserActivityByIdQuery, IEnumerable<UserActivity>>(query);

            return new OkObjectResult(userActivities);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]UserLocationRequestModel userLocation)
        {
            var command = new AddUserLocation(userLocation.UserId, userLocation.Latitude, userLocation.Longitude, userLocation.Height);

            await commandDispatcher.ExecuteAsync(command);

            return new OkResult();
        }
    }
}