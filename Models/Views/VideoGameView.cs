using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApricodeTest.Models.EFCoreModels;

namespace ApricodeTest.Models.Views
{
    public class VideoGameView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GameDeveloperView GameDeveloper { get; set; }
        public List<GameGenreView> GameGenres { get; set; }
        public VideoGameView(VideoGame videoGame)
        {
            Id = videoGame.Id;
            Name = videoGame.Name;
            GameDeveloper = new GameDeveloperView(videoGame.GameDeveloper);
            GameGenres = videoGame.GameGenres.Select(item => new GameGenreView(item)).ToList();
        }
    }
}
