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
    [Route("showgame")]
    public class ShowGameController : Controller
    {
        private DataService _dataService;
        public ShowGameController(DataService dataService)
        {
            _dataService = dataService;
        }
        [HttpGet]
        public IActionResult Index(string name)
        {
            return Ok(_dataService.ReadGame(name));
        }
    }
}
