using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApricodeTest.EFCore;
using ApricodeTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApricodeTest.Controllers
{
    [ApiController]
    [Route("delgame")]
    public class DeleteGameController : Controller
    {
        private DataService _dataService;
        public DeleteGameController(DataService dataService)
        {
            _dataService = dataService;
        }
        [HttpGet]
        public IActionResult Index(string name)
        {
            return Ok(_dataService.DeleteGame(name));
        }
    }
}
