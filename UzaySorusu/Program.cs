using System;
using System.Collections.Generic;
using System.Linq;

namespace Quız
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var plateauSize = Console.ReadLine();
            var roverLocation = Console.ReadLine();
            var commandList = Console.ReadLine();

            Pleateu plateau = ParsePlateauSize(plateauSize);
            List<Rover> rovers = ParseRoverLocations(roverLocation);

            foreach (var rover in rovers)
            {
                ExecuteCommands(plateau, rover, commandList);
            }





            foreach (var rover in rovers)
            {
                Console.WriteLine($"Rover {rover.Id}: {rover.CurrentLocation.x} {rover.CurrentLocation.y} {rover.CurrentLocation.Direction}");
            }
        }

        static Pleateu ParsePlateauSize(string input)
        {
            Pleateu plateau = new Pleateu();

            string[] separate = input.Split(' ');



            return plateau;
        }

        static List<Rover> ParseRoverLocations(string input)
        {

            List<Rover> rovers = new List<Rover>();
            
            

            return rovers;


        }

        static void ExecuteCommands(Pleateu plateau, Rover rover, string commands)
        {
            foreach (var command in commands)
            {
                ICommand cmd;
                if (command == 'L')
                {
                    cmd = new LeftCommand();
                }
                else if (command == 'R')
                {
                    cmd = new RightCommand();
                }
                else if (command == 'M')
                {
                    cmd = new MoveCommand();
                }
                else
                {
                    throw new ArgumentException("Geçersiz komut: " + command);
                }

                cmd.Execute(plateau, rover.Id);
            }
        }
    }

    public class Pleateu
    {       

        public Pleateu(int columnSize, int rowSize, List<Rover> rovers)
        {
            ColumnSize = columnSize;
            RowSize = rowSize;
            Rovers = rovers;
        }

        public int ColumnSize { get; set; }

        public int RowSize { get; set; }

        public List<Rover> Rovers { get; set; }
    }

    public class Rover
    {
        public int Id { get; set; }
        public Location CurrentLocation { get; set; }
    }

    public class Location
    {
        public int x { get; set; }
        public int y { get; set; }
        public Compas Direction { get; set; }
    }

    public enum Compas
    {
        N,
        E,
        S,
        W
    }

    public interface ICommand
    {
        void Execute(Pleateu pleateu, int roverId);
    }

    public class LeftCommand : ICommand
    {
        public void Execute(Pleateu pleateu, int roverId)
        {
            Func<Rover, bool> function = p => p.Id == roverId;

            var currentRover = pleateu.Rovers.FirstOrDefault(function);
            if (currentRover != null)
            {
                switch (currentRover.CurrentLocation.Direction)
                {
                    case Compas.N:
                        currentRover.CurrentLocation.Direction = Compas.W;
                        break;
                    case Compas.E:
                        currentRover.CurrentLocation.Direction = Compas.N;
                        break;
                    case Compas.S:
                        currentRover.CurrentLocation.Direction = Compas.E;
                        break;
                    case Compas.W:
                        currentRover.CurrentLocation.Direction = Compas.S;
                        break;
                }
            }
        }
    }

    public class RightCommand : ICommand
    {
        public void Execute(Pleateu pleateu, int roverId)
        {
            Func<Rover, bool> function = p => p.Id == roverId;

            var currentRover = pleateu.Rovers.FirstOrDefault(function);

            if (currentRover != null)
            {

                switch (currentRover.CurrentLocation.Direction)
                {
                    case Compas.N:
                        currentRover.CurrentLocation.Direction = Compas.E;
                        break;
                    case Compas.S:
                        currentRover.CurrentLocation.Direction = Compas.W;
                        break;
                    case Compas.E:
                        currentRover.CurrentLocation.Direction = Compas.S;
                        break;
                    case Compas.W:
                        currentRover.CurrentLocation.Direction = Compas.N;
                        break;


                }
            }

        }
    }

    public class MoveCommand : ICommand
    {
        public void Execute(Pleateu pleateu, int roverId)
        {
            Func<Rover, bool> function = p => p.Id == roverId;

            var currentRover = pleateu.Rovers.FirstOrDefault(function);

            if (currentRover != null)
            {

                switch (currentRover.CurrentLocation.Direction)
                {
                    case Compas.N:
                        currentRover.CurrentLocation.y += 1;
                        break;
                    case Compas.S:
                        currentRover.CurrentLocation.y -= 1;
                        break;
                    case Compas.E:
                        currentRover.CurrentLocation.x += 1;
                        break;
                    case Compas.W:
                        currentRover.CurrentLocation.x -= 1;
                        break;                        

                }

            }


        }
    }
}