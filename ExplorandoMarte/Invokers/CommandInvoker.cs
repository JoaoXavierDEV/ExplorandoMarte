using ExplorandoMarte.Commands;

namespace ExplorandoMarte.Invokers
{
    public class CommandInvoker
    {
        private readonly Queue<ICommand> _commands = new Queue<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commands.Enqueue(command);
        }

        public void ExecuteCommands()
        {
            while (_commands.Count > 0)
            {
                var command = _commands.Dequeue();
                command.Execute();
            }
        }
    }
}
