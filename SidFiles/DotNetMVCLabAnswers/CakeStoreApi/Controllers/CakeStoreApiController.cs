using CakeStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CakeStoreApi.Controllers
{


    [Route("/api/[controller")]
    [ApiController]
    public class CakeStoreApiController : ControllerBase
    {
        private IData _data;

        private readonly ILogger<CakeStoreApiController> _logger;

        public CakeStoreApiController(IData data, ILogger<CakeStoreApiController> logger)
        {   
            _data = data;
            _logger = logger;
        }

        [HttpGet("/api/CakeStore")]
        public ActionResult<List<CakeStore>> GetAll()
        {
            return _data.CakesInitializeData();
        }

        [HttpGet("/api/CakeStore/{id}"), Name="GetCake")]


    }
}