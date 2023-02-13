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
            private List<ICommand> _commands;

            public CommandGroup(List<ICommand> commands)
            {
                _commands = commands;
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

            public bool CanExecute(object parameter)
            {
                return _commands.All(c => c.CanExecute(parameter));
            }

            public void Execute(object parameter)
            {
                foreach (var command in _commands)
                {
                    command.Execute(parameter);
                }
            }
        }
    }
