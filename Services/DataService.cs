using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApricodeTest.AppExceptions;
using ApricodeTest.EFCore;
using ApricodeTest.Models.Views;

namespace ApricodeTest.Services
{
    public class DataService
    {
        private DBManager _dbManager;
        public DataService(DBManager dbManager)
        {
            _dbManager = dbManager;
        }

        public object CreateGame(string name, string developerName, IEnumerable<string> genreNames)
        {
            try
            {
                _dbManager.CreateGame(name, developerName, genreNames);
            }
            catch (ObjectIsExistException)
            {
                return $"A game named {name} already exists";
            }
            catch (Exception)
            {
                return "An unknown error occurred";
            }
            return $"Game {name} added successfully";
        }

        public object ReadGame(string name)
        {
            try
            {
                var game = _dbManager.ReadGame(name);
                return new VideoGameView(game);
            }
            catch (ArgumentIsNotExistException)
            {
                return $"A game named {name} does not exist";
            }
            catch (Exception)
            {
                return "An unknown error occurred";
            }

        }

        public object ChangeGameDeveloper(string name, string developerName)
        {
            try
            {
                _dbManager.ChangeGameDeveloper(name, developerName);
            }
            catch (ArgumentIsNotExistException)
            {
                return $"A game named {name} does not exist";
            }
            catch (Exception)
            {
                return "An unknown error occurred";
            }
            return $"Developer {developerName} changed successfully for game {name}";
        }

        public object AddGenreForGame(string name, string genre)
        {
            try
            {
                _dbManager.AddGenreForGame(name, genre);
            }
            catch (ArgumentIsNotExistException)
            {
                return $"A game named {name} does not exist";
            }
            catch (Exception)
            {
                return "An unknown error occurred";
            }
            return $"Genre {genre} added successfully for game {name}";
        }

        public object RemoveGenreFromGame(string name, string genre)
        {
            try
            {
                _dbManager.RemoveGenreFromGame(name, genre);
            }
            catch (ArgumentIsNotExistException)
            {
                return $"A game named {name} or genre in game does not exist";
            }
            catch (Exception)
            {
                return "An unknown error occurred";
            }
            return $"Genre {genre} removed successfully for game {name}";
        }

        public object DeleteGame(string name)
        {
            try
            {
                _dbManager.DeleteGame(name);
            }
            catch (ArgumentIsNotExistException)
            {
                return $"A game named {name} does not exist";
            }
            catch (Exception)
            {
                return "An unknown error occurred";
            }
            return $"Game {name} removed successfully";
        }

        public object GetGameWithGenre(string genreName)
        {
            try
            {
                var games = _dbManager.GetGameWithGenre(genreName);
                return games.Select(item => item.Name).ToList();
            }
            catch (ArgumentIsNotExistException)
            {
                return $"Games in genre {genreName} not found";
            }
            catch (Exception)
            {
                return "An unknown error occurred";
            }
        }
    }
}
