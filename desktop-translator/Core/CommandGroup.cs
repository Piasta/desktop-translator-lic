using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace desktop_translator.Core
{
    public class CommandGroup : ICommand
    {
        private readonly List<ICommand> _commands;

        public CommandGroup(IEnumerable<ICommand> commands)
        {
            _commands = commands.ToList();
        }

        public bool CanExecute(object parameter)
        {
            return _commands.Any(c => c.CanExecute(parameter));
        }

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
