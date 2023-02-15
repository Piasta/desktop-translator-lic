using desktop_translator.Core;
using desktop_translator.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Input;

namespace desktop_translator.MVVM.ViewModel
{
    class HistoryViewModel : ObservableObject
    {

        private HistoryModel _historyModel;

        public HistoryModel HistoryModel
        {
            get { return _historyModel; }
            set
            {
                _historyModel = value;
                OnPropertyChanged("HistoryModel");
            }
        }

        private DataTable _phrases;

        public DataTable Phrases
        {
            get { return _phrases; }
            set
            {
                _phrases = value;
                OnPropertyChanged("Phrases");
            }
        }

        public HistoryViewModel()
        {
            HistoryModel = new HistoryModel();
        }

        public ICommand DbViewCommand => new RelayCommand(DbView, CanExecuteView);

        private bool CanExecuteView(object parameter)
        {
            return true;
        }

        private void DbView(object parameter)
        {
            HistoryModel.DbView();
            Phrases = HistoryModel.table;
        }
    }
}
