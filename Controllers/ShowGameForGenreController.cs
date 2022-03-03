using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApricodeTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApricodeTest.Controllers
{
    [ApiController]
    [Route("showgenregame")]
    public class ShowGameForGenreController : Controller
    {
        private DataService _dataService;
        public ShowGameForGenreController(DataService dataService)
        {
            _dataService = dataService;
        }
        [HttpGet]
        public IActionResult Index(string genre)
        {
            return Ok(_dataService.GetGameWithGenre(genre));
        }
    }
}
