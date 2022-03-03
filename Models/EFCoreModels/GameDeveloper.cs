using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApricodeTest.Models.EFCoreModels
{
    public class GameDeveloper
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public GameDeveloper(string name)
        {
            Name = name;
        }
        public GameDeveloper()
        {

        }
    }
}