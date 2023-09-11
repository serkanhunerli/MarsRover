using System;
using System.Linq;

namespace Quiz
{
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
                        currentRover.CurrentLocation.Y += 1;
                        break;
                    case Compas.S:
                        currentRover.CurrentLocation.Y -= 1;
                        break;
                    case Compas.E:
                        currentRover.CurrentLocation.X += 1;
                        break;
                    case Compas.W:
                        currentRover.CurrentLocation.X -= 1;
                        break;

                }
            }
        }
    }
}