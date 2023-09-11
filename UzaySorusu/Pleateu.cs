using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz
{
    public class Pleateu
    {
        public int ColumnSize { get; set; }

        public int RowSize { get; set; }

        public List<Rover> Rovers { get; set; }

        public Pleateu(int columnSize, int rowSize)
        {
            ColumnSize = columnSize;
            RowSize = rowSize;
            Rovers = new List<Rover>();
        }

        public Pleateu(int columnSize, int rowSize, List<Rover> rovers)
            : this(columnSize, rowSize)
        {
            Rovers = rovers;
        }

        public void AddRover(Rover rover)
        {
            Rovers.Add(rover);
        }

        public void ExecuteCommands(int roverId, string commands)
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
                cmd.Execute(this, roverId);
            }
        }
    }
}