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
    [Route("addgame")]
    public class CreateGameController : Controller
    {
        private DataService _dataService;
        public CreateGameController(DataService dataService)
        {
            _dataService = dataService;
        }
        [HttpPost]
        public IActionResult Index(string name, string developerName, string[] genreNames)
        {
            return Ok(_dataService.CreateGame(name, developerName, genreNames));
        }
    }
}
