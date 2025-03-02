using ExplorandoMarte.Models;

namespace ExplorandoMarte.Commands
{
    public class TurnRightCommand : ICommand
    {
        private readonly Rover _rover;

        public TurnRightCommand(Rover rover)
        {
            _rover = rover;
        }

        public void Execute()
        {
            _rover.TurnRight();
        }
    }
}