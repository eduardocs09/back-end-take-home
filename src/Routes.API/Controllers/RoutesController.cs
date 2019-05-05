using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Routes.Application.Interfaces;

namespace Routes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IAppPopulator _appPopulator;
        private readonly IAppRoutes _appRoutes;

        public RoutesController(IAppPopulator appPopulator, IAppRoutes appRoutes)
        {
            _appPopulator = appPopulator;
            _appRoutes = appRoutes;
        }

        [HttpGet]
        public IActionResult Get(string origin, string destination)
        {
            var connectedRoute = _appRoutes.FindShortestRoute(origin, destination);
            return Ok(connectedRoute);
        }

        [HttpPost("populate")]
        public IActionResult Populate()
        {
            int result = _appPopulator.PopulateDatabase();
            return Ok(result);
        }
    }
}