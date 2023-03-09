// <copyright file="CommandGroup.cs" company="Piasta-company">
// Copyright (c) Piasta-company. All rights reserved.
// </copyright>

namespace Desktop_translator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;

    /// <summary>
    /// Class responsible for collecting several commands under one.
    /// </summary>
    public class CommandGroup : ICommand
    {
        private readonly List<ICommand> commands;

        public CommandGroup(IEnumerable<ICommand> commands)
        {
            this.commands = commands.ToList();
        }

        /// <inheritdoc/>
        bool ICommand.CanExecute(object parameter)
        {
            return this.commands.Any(c => c.CanExecute(parameter));
        }

        /// <inheritdoc/>
        void ICommand.Execute(object parameter)
        {
            foreach (var command in this.commands)
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
                foreach (var command in this.commands)
                {
                    command.CanExecuteChanged += value;
                }
            }

            remove
            {
                foreach (ICommand command in this.commands)
                {
                    command.CanExecuteChanged -= value;
                }
            }
        }
    }
}