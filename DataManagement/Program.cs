using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabSheet8;
using LabSheet8Part2;

namespace DataManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamData db = new TeamData();
            GameData gd = new GameData();
            //Any network connections that are open this will close them if there is a proplem
            using (db)
            {
                Team t1 = new Team() { TeamID = 1, TeamName = "Sligo Rovers", Location = "Sligo" };
                Player p1 = new Player() { PlayerID = 1, Name = "Tom", Position = "Forward", TeamID = 1, Team = t1 };
                Player p2 = new Player() { PlayerID = 2, Name = "Mick", Position = "Defender", TeamID = 1, Team = t1 };
                

                Team t2 = new Team() { TeamID = 2, TeamName = "Finn Harps", Location = "Donegal" };
                Player p3 = new Player() { PlayerID = 3, Name = "Sam", Position = "Midfielder", TeamID = 2, Team = t2 };
                Player p4 = new Player() { PlayerID = 4, Name = "Jim", Position = "Goalkeeper", TeamID = 2, Team = t2 };

                db.Teams.Add(t1);
                db.Teams.Add(t2);

                Console.WriteLine("Added teams to database");

                db.Players.Add(p1);
                db.Players.Add(p2);
                db.Players.Add(p3);
                db.Players.Add(p4);

                Console.WriteLine("Added players to database");

                db.SaveChanges();

                Console.WriteLine("Saved to Database");


            }

            using (gd)
            {
                Character c1 = new Character() { CharacterID = 1, CharacterName = "John Marston" };
                ComputerGame g1 = new ComputerGame() { GameID = 1, Name = "Red Dead Redemption", CharacterID = 1, Character = c1 };
                ComputerGame g2 = new ComputerGame() { GameID = 2, Name = "Red Dead Redemption 2", CharacterID = 1, Character = c1 };



                Character c2 = new Character() { CharacterID = 2, CharacterName = "Hurk Drubman" };
                ComputerGame g3 = new ComputerGame() { GameID = 1, Name = "Far Cry 5", CharacterID = 2, Character = c1 };
                ComputerGame g4 = new ComputerGame() { GameID = 2, Name = "Far Cry 4", CharacterID = 2, Character = c1 };

                gd.Characters.Add(c1);
                gd.Characters.Add(c2);

                Console.WriteLine("Added Characters to database");

                gd.Games.Add(g1);
                gd.Games.Add(g2);
                gd.Games.Add(g3);
                gd.Games.Add(g4);

                Console.WriteLine("Added Games to database");

                gd.SaveChanges();

                Console.WriteLine("Saved to Database");
            }

        }
    }
}
