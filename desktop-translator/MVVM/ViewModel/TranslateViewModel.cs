// <copyright file="TranslateViewModel.cs" company="Piasta-company">
// Copyright (c) Piasta-company. All rights reserved.
// </copyright>

namespace Desktop_translator.MVVM.ViewModel
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Input;
    using Desktop_translator.Core;
    using Desktop_translator.MVVM.Model;

    internal class TranslateViewModel : ObservableObject
    {
        private TranslateModel translateModel;

        public TranslateModel TranslateModel
        {
            get
            {
                return this.translateModel;
            }

            set
            {
                this.translateModel = value;
                this.OnPropertyChanged(nameof(this.TranslateModel));
            }
        }

        private HistoryModel historyModel;

        public HistoryModel HistoryModel
        {
            get
            {
                return this.historyModel;
            }

            set
            {
                this.historyModel = value;
                this.OnPropertyChanged(nameof(this.HistoryModel));
            }
        }

        private OptionsModel optionsModel;

        public OptionsModel OptionsModel
        {
            get
            {
                return this.optionsModel;
            }

            set
            {
                this.optionsModel = value;
                this.OnPropertyChanged(nameof(this.OptionsModel));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslateViewModel"/> class.
        /// </summary>
        public TranslateViewModel()
        {
            this.TranslateModel = new TranslateModel();
            this.HistoryModel = new HistoryModel();
            this.OptionsModel = new OptionsModel();
        }

        /// <summary>
        /// Gets command which execute Translate method from TranslateModel.
        /// </summary>
        public ICommand TranslateCommand => new RelayCommand(this.Translate, this.CanExecuteTranslate);

        /// <summary>
        /// Gets command which execute DbInsert method from HistoryModel.
        /// </summary>
        public ICommand DbInsertCommand => new RelayCommand(this.DbInsert, this.CanExecuteInsert);

        private bool CanExecuteTranslate(object parameter)
        {
            return true;
        }

        private bool CanExecuteInsert(object parameter)
        {
            return true;
        }

        private void Translate(object parameter)
        {
            this.TranslateModel.Translate();
        }

        private void DbInsert(object parameter)
        {
            this.HistoryModel.DbInsert(this.TranslateModel.RawText, this.TranslateModel.TranslatedText);
        }

        /// <summary>
        /// Gets commandgroup after combine TranslateCommand & DbInsertCommand.
        /// </summary>
        private CommandGroup translateCommandGroup;

        public CommandGroup TranslateCommandGroup
        {
            get
            {
                if (this.translateCommandGroup == null)
                {
                    this.translateCommandGroup = new CommandGroup(new List<ICommand>
                {
                    this.TranslateCommand,
                    this.DbInsertCommand,
                });
                }

                return this.translateCommandGroup;
            }
        }
    }
}