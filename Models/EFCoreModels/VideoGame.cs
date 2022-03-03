using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApricodeTest.Models.EFCoreModels
{
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int GameDeveloperId { get; set; }
        public GameDeveloper GameDeveloper { get; set; }
        public List<GameGenre> GameGenres { get; set; } = new List<GameGenre>();
        public VideoGame(string name, GameDeveloper gameDeveloper)
        {
            Name = name;
            GameDeveloper = gameDeveloper;
        }
        public VideoGame()
        {
        }
    }
}