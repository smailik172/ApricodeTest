using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApricodeTest.Models.EFCoreModels;

namespace ApricodeTest.Models.Views
{
    public class GameGenreView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GameGenreView(GameGenre gameGenre)
        {
            Id = gameGenre.Id;
            Name = gameGenre.Name;
        }
    }
}
