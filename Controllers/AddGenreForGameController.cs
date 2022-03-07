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
    [Route("addgenre")]
    public class AddGenreForGameController : Controller
    {
        private DataService _dataService;
        public AddGenreForGameController(DataService dataService)
        {
            _dataService = dataService;
        }
        [HttpPut]
        public IActionResult Index(string name, string genre)
        {
            return Ok(_dataService.AddGenreForGame(name, genre));
        }
    }
}
