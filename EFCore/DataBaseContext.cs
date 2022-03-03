using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApricodeTest.Models;
using ApricodeTest.Models.EFCoreModels;
using Microsoft.EntityFrameworkCore;

namespace ApricodeTest.EFCore
{
    internal class DataBaseContext : DbContext
    {
        public DbSet<GameDeveloper> GameDevelopers { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
        public void Init()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=ApricodeTest;", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
