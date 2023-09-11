using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Quiz
{
    public class Program
    {
        static void Main(string[] args)
        {
            var plateauSize = Console.ReadLine();
            var roverLocation = Console.ReadLine();
            var commandList = Console.ReadLine();

            Pleateu plateau = InitPlateau(plateauSize);
            Rover rover = ParseRoverLocations(plateau, roverLocation);
            plateau.AddRover(rover);
            plateau.ExecuteCommands(rover.Id, commandList);

            Console.WriteLine($"Rover {rover.Id}: {rover.CurrentLocation.X} {rover.CurrentLocation.Y} {rover.CurrentLocation.Direction}");
        }

        static Pleateu InitPlateau(string input)
        {
            string[] separate = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (separate.Length < 2)
                throw new Exception("you must enter valid numbers. ");

            int rowSize;

            int columSize;

            if (!int.TryParse(separate[0], out rowSize))
                throw new Exception("you must enter numeric for x value.");

            if (!int.TryParse(separate[1], out columSize))
                throw new Exception("you must enter numeric for y value.");

            if (rowSize < 0 || columSize < 0)
                throw new Exception("you must enter positive values.");

            Pleateu plateau = new Pleateu(columSize, rowSize);

            return plateau;
        }

        static Rover ParseRoverLocations(Pleateu pleateu, string input)
        {
            string[] separate = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var x = int.Parse(separate[0]);
            var y = int.Parse(separate[1]);
            var direction = (Compas)Enum.Parse(typeof(Compas), separate[2], true);

            var rover = new Rover(pleateu.Rovers.Count + 1);
            rover.CurrentLocation = new Location()
            {
                X = x,
                Y = y,
                Direction = direction
            };
            return rover;
        }
    }
}