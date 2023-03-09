// <copyright file="MainViewModel.cs" company="Piasta-company">
// Copyright (c) Piasta-company. All rights reserved.
// </copyright>

namespace Desktop_translator.MVVM.ViewModel
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using Desktop_translator.Core;

    internal class MainViewModel : ObservableObject
    {
        /// <summary>
        /// Gets or sets command which select TranslateView.
        /// </summary>
        public RelayCommand TranslateViewCommand { get; set; }

        /// <summary>
        /// Gets or sets command which select HistoryView.
        /// </summary>
        public RelayCommand HistoryViewCommand { get; set; }

        /// <summary>
        /// Gets or sets command which select OptionsView.
        /// </summary>
        public RelayCommand OptionsViewCommand { get; set; }

        /// <summary>
        /// Gets or sets command which select InfoView.
        /// </summary>
        public RelayCommand InfoViewCommand { get; set; }

        /// <summary>
        /// Gets or sets command which select TranslateView.
        /// </summary>
        public TranslateViewModel TranslateVM { get; set; }

        /// <summary>
        /// Gets or sets command which select HistoryView.
        /// </summary>
        public HistoryViewModel HistoryVM { get; set; }

        /// <summary>
        /// Gets or sets command which select OptionsView.
        /// </summary>
        public OptionsViewModel OptionsVM { get; set; }

        /// <summary>
        /// Gets or sets command which select InfoView.
        /// </summary>
        public InfoViewModel InfoVM { get; set; }

        private object currentView;

        public object CurrentView
        {
            get
            {
                return this.currentView;
            }

            set
            {
                this.currentView = value;

                this.OnPropertyChanged(nameof(this.CurrentView));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.TranslateVM = new TranslateViewModel();
            this.HistoryVM = new HistoryViewModel();
            this.OptionsVM = new OptionsViewModel();
            this.InfoVM = new InfoViewModel();

            this.CurrentView = this.TranslateVM;

            this.TranslateViewCommand = new RelayCommand(o => {
                this.CurrentView = this.TranslateVM;
                this.TranslateVM.TranslateModel.LanguagesValidation();
            });

            this.HistoryViewCommand = new RelayCommand(o =>
            {
                this.CurrentView = this.HistoryVM;
            });

            this.OptionsViewCommand = new RelayCommand(o =>
            {
                this.CurrentView = this.OptionsVM;
            });

            this.InfoViewCommand = new RelayCommand(o =>
            {
                this.CurrentView = this.InfoVM;
            });
        }

        private CommandGroup historyCommandGroup;

        public CommandGroup HistoryCommandGroup
        {
            get
            {
                if (this.historyCommandGroup == null)
                {
                    this.historyCommandGroup = new CommandGroup(new List<ICommand>
                {
                    this.HistoryViewCommand,
                    this.HistoryVM.DbViewCommand,
                });
                }

                return this.historyCommandGroup;
            }
        }
    }
}