using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet8Part2
{
    public class ComputerGame
    {
        public int GameID { get; set; }
        public string Name { get; set; }

        public int CharacterID { get; set; }
        public virtual Character Character { get; set; }
    }
    public class Character
    {
        public int CharacterID { get; set; }
        public string CharacterName { get; set; }

        public virtual List<ComputerGame> Games { get; set; }

    }
    public class GameData : DbContext
    {
        public GameData() : base("MyGameData") { }
        public DbSet<ComputerGame> Games { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}
