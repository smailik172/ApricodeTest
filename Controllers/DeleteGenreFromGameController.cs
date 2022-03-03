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
    [Route("delgenre")]
    public class DeleteGenreFromGameController : Controller
    {
        private DataService _dataService;
        public DeleteGenreFromGameController(DataService dataService)
        {
            _dataService = dataService;
        }
        [HttpGet]
        public IActionResult Index(string name, string genre)
        {
            return Ok(_dataService.RemoveGenreFromGame(name, genre));
        }
    }
}
