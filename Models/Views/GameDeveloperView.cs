using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApricodeTest.Models.EFCoreModels;

namespace ApricodeTest.Models.Views
{
    public class GameDeveloperView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GameDeveloperView(GameDeveloper gameDeveloper)
        {
            Id = gameDeveloper.Id;
            Name = gameDeveloper.Name;
        }
    }
}
