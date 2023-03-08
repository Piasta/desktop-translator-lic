namespace desktop_translator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class CommandGroup : ICommand
    {
        private readonly List<ICommand> _commands;

        public CommandGroup(IEnumerable<ICommand> commands)
        {
            _commands = commands.ToList();
        }

        /// <inheritdoc/>
        public bool CanExecute(object parameter)
        {
            return _commands.Any(c => c.CanExecute(parameter));
        }

        /// <inheritdoc/>
        public void Execute(object parameter)
        {
            foreach (var command in _commands)
            {
                if (command.CanExecute(parameter))
                {
                    command.Execute(parameter);
                }
            }
        }

        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                foreach (var command in _commands)
                {
                    command.CanExecuteChanged += value;
                }
            }
            remove
            {
                foreach (var command in _commands)
                {
                    command.CanExecuteChanged -= value;
                }
            }
        }
    }
}
