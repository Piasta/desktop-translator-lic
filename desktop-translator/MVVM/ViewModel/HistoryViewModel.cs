// <copyright file="HistoryViewModel.cs" company="Piasta-company">
// Copyright (c) Piasta-company. All rights reserved.
// </copyright>

namespace Desktop_translator.MVVM.ViewModel
{
    using System.Data;
    using System.Windows.Input;
    using Desktop_translator.Core;
    using Desktop_translator.MVVM.Model;

    internal class HistoryViewModel : ObservableObject
    {
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

        private DataTable phrases;

        public DataTable Phrases
        {
            get
            {
                return this.phrases;
            }

            set
            {
                this.phrases = value;
                this.OnPropertyChanged(nameof(this.Phrases));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryViewModel"/> class.
        /// </summary>
        public HistoryViewModel()
        {
            this.HistoryModel = new HistoryModel();
        }

        /// <summary>
        /// Gets command which execute DbView method which include DbView and table with created data.
        /// </summary>
        public ICommand DbViewCommand => new RelayCommand(this.DbView, this.CanExecuteView);

        private bool CanExecuteView(object parameter)
        {
            return true;
        }

        private void DbView(object parameter)
        {
            this.HistoryModel.DbView();
            this.Phrases = this.HistoryModel.table;
        }
    }
}
