using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApricodeTest.AppExceptions;
using ApricodeTest.Models;
using ApricodeTest.Models.EFCoreModels;
using Microsoft.EntityFrameworkCore;

namespace ApricodeTest.EFCore
{
    public class DBManager
    {
        private static DBManager _dbManager = new DBManager();
        public static DBManager GetSingleton() => _dbManager;
        private DBManager()
        {
            using (var context = new DataBaseContext())
            {
                context.Init();
                InitFakeData();
            }
        }
        public void InitFakeData()
        {
            using (var context = new DataBaseContext())
            {
                var existGame = GetVideoGame(context, "Stalker");
                if (existGame != null)
                    return;


                var cdprDev = new GameDeveloper("CD Project");
                var gscDev = new GameDeveloper("GSC Game World");
                var eaDev = new GameDeveloper("EA");
                var valveDev = new GameDeveloper("Valve");
                context.GameDevelopers.AddRange(cdprDev, gscDev, eaDev, valveDev);

                var rpgGenre = new GameGenre("RPG");
                var shooterGenre = new GameGenre("Shooter");
                var simGenre = new GameGenre("Simulator");
                var sportGenre = new GameGenre("Sport");
                context.GameGenres.AddRange(rpgGenre, shooterGenre, simGenre, sportGenre);

                var stalkerGame = new VideoGame("Stalker", gscDev);
                var csgoGame = new VideoGame("CS:GO", valveDev);
                var witcherGame = new VideoGame("Witcher", cdprDev);
                var fifaGame = new VideoGame("FIFA", eaDev);
                context.VideoGames.AddRange(stalkerGame, csgoGame, witcherGame, fifaGame);

                stalkerGame.GameGenres.AddRange(new []{ rpgGenre, shooterGenre});
                csgoGame.GameGenres.Add(shooterGenre);
                witcherGame.GameGenres.Add(rpgGenre);
                fifaGame.GameGenres.AddRange(new[] { simGenre, sportGenre });
                context.SaveChanges();
            }
        }

        public void CreateGame(string name, string developerName, IEnumerable<string> genreNames)
        {
            using (var context = new DataBaseContext())
            {
                if (GetVideoGame(context, name) != null)
                    throw new ObjectIsExistException();
                var developer = GetOrAddGameDeveloper(context, developerName);
                var game = new VideoGame() { Name = name, GameDeveloper = developer };
                context.VideoGames.Add(game);
                foreach (var genre in genreNames)
                {
                    var genreModel = GetOrAddGenre(context, genre);
                    game.GameGenres.Add(genreModel);
                }
                context.SaveChanges();
            }
        }

        public VideoGame ReadGame(string name)
        {
            using (var context = new DataBaseContext())
            {
                var game = GetVideoGame(context, name);
                if (game == null)
                    throw new ArgumentIsNotExistException();
                return game;
            }
        }

        public void ChangeGameDeveloper(string name, string developerName)
        {
            using (var context = new DataBaseContext())
            {
                var game = GetVideoGame(context, name);
                if (game == null)
                    throw new ArgumentIsNotExistException();
                var developer = GetOrAddGameDeveloper(context, developerName);
                game.GameDeveloper = developer;
                context.SaveChanges();
            }
        }

        public void AddGenreForGame(string name, string genre)
        {
            using (var context = new DataBaseContext())
            {
                var game = GetVideoGame(context, name);
                if (game == null)
                    throw new ArgumentIsNotExistException();
                var genreModel = GetOrAddGenre(context, genre);
                game.GameGenres.Add(genreModel);
                context.SaveChanges();
            }
        }

        public void RemoveGenreFromGame(string name, string genre)
        {
            using (var context = new DataBaseContext())
            {
                var game = GetVideoGame(context, name);
                if (game == null)
                    throw new ArgumentIsNotExistException();
                var genreModel = GetOrAddGenre(context, genre);
                if (!game.GameGenres.Remove(genreModel))
                    throw new ArgumentIsNotExistException();
                context.SaveChanges();
            }
        }

        public void DeleteGame(string name)
        {
            using (var context = new DataBaseContext())
            {
                var videoGame = context.VideoGames.FirstOrDefault(item => item.Name.Equals(name));
                if (videoGame == null)
                    throw new ArgumentIsNotExistException();
                context.VideoGames.Remove(videoGame);
                context.SaveChanges();
            }
        }

        public List<VideoGame> GetGameWithGenre(string genreName)
        {
            using (var context = new DataBaseContext())
            {
                var genreModel = context.GameGenres
                    .Include(u => u.VideoGames)
                        .ThenInclude(v => v.GameDeveloper)
                    .FirstOrDefault(item => item.Name.Equals(genreName));
                if (genreModel == null || genreModel.VideoGames.Count == 0)
                    throw new ArgumentIsNotExistException();
                return genreModel.VideoGames;
            }
        }

        private VideoGame GetVideoGame(DataBaseContext context, string name)
        {
            return context.VideoGames
                .Include(u => u.GameGenres)
                .Include(u => u.GameDeveloper)
                .FirstOrDefault(item => item.Name.Equals(name));
        }

        private GameDeveloper GetOrAddGameDeveloper(DataBaseContext context, string name)
        {
            var developer = context.GameDevelopers.FirstOrDefault(item => item.Name.Equals(name));
            if (developer == null)
            {
                developer = new GameDeveloper() { Name = name };
                context.GameDevelopers.Add(developer);
            }
            return developer;
        }

        private GameGenre GetOrAddGenre(DataBaseContext context, string name)
        {
            var genre = context.GameGenres.FirstOrDefault(item => item.Name.Equals(name));
            if (genre == null)
            {
                genre = new GameGenre() { Name = name };
                context.GameGenres.Add(genre);
            }
            return genre;
        }
    }
}
