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
    [Route("changedev")]
    public class ChangeDeveloperForGameController : Controller
    {
        private DataService _dataService;
        public ChangeDeveloperForGameController(DataService dataService)
        {
            _dataService = dataService;
        }
        [HttpPut]
        public IActionResult Index(string name, string developerName)
        {
            return Ok(_dataService.ChangeGameDeveloper(name, developerName));
        }
    }
}
