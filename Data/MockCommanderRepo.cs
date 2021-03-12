using System;
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {        
        public void CreateCommand(Command cmd)
        {
            if(cmd is null || cmd.HowTo is null || 
            cmd.Line is null || cmd.Platform is null)
                throw new ArgumentNullException();

            // return new Command{Id=3, HowTo=cmd.HowTo, Line=cmd.Line, Platform=cmd.Platform};
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command> 
            {
                new Command{Id=0, HowTo="Become BwO", Line="Be rhizomatic", Platform="A Thousand Plateaus"},
                new Command{Id=1, HowTo="Long for the other shore", Line="Go Under", Platform="Motley Cow"},
                new Command{Id=2, HowTo="Struggle toward heights", Line="Imagine Sisyphus happy", Platform="The Myth of Sisyphus"}
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="Become BwO", Line="Be rhizomatic", Platform="A Thousand Plateaus"};
        }

        public bool SaveChanges()
        {
            return true;
        }
    }
}