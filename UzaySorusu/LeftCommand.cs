using System;
using System.Linq;

namespace Quiz
{
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
}