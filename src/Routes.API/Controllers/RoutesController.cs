using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Routes.API.ViewModels;
using Routes.Application.Interfaces;

namespace Routes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IAppPopulator _appPopulator;
        private readonly IAppRoutes _appRoutes;
        private readonly IMapper _mapper;

        public RoutesController(IAppPopulator appPopulator, IAppRoutes appRoutes, IMapper mapper)
        {
            _appPopulator = appPopulator;
            _appRoutes = appRoutes;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(string origin, string destination)
        {
            var shortestRoute = _appRoutes.FindShortestRoute(origin, destination);

            RouteViewModel route;
            if (shortestRoute == null)
            {
                route = new RouteViewModel();
            }
            else
            {
                route = _mapper.Map<RouteViewModel>(shortestRoute);
            }

            return Ok(route);
        }

        [HttpPost("populate")]
        public IActionResult Populate()
        {
            int result = _appPopulator.PopulateDatabase();
            return Ok(result);
        }
    }
}