using desktop_translator.Core;
using desktop_translator.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace desktop_translator.MVVM.ViewModel
{
    class TranslateViewModel : ObservableObject
    {
        private TranslateModel translateModel;

        public TranslateModel TranslateModel
        {
            get { return translateModel; }
            set
            {
                translateModel = value;
                OnPropertyChanged("TranslateModel");
            }
        }

        private HistoryModel historyModel;

        public HistoryModel HistoryModel
        {
            get { return historyModel; }
            set
            {
                historyModel = value;
                OnPropertyChanged("HistoryModel");
            }
        }

        private OptionsModel _optionsModel;

        public OptionsModel OptionsModel
        {
            get { return _optionsModel; }
            set
            {
                _optionsModel = value;
                OnPropertyChanged("OptionsModel");
            }
        }


        public TranslateViewModel()
        {
            TranslateModel = new TranslateModel();
            HistoryModel = new HistoryModel();
            OptionsModel = new OptionsModel();
        }


        public ICommand TranslateCommand => new RelayCommand(Translate, CanExecuteTranslate);

        public ICommand DbInsertCommand => new RelayCommand(DbInsert, CanExecuteInsert);

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
            TranslateModel.Translate();
        }

        private void DbInsert(object parameter)
        {
            HistoryModel.DbInsert(TranslateModel.RawText, TranslateModel.TranslatedText);
        }

        private CommandGroup _translateCommandGroup;

        public CommandGroup TranslateCommandGroup
        {
            get
            {
                if (_translateCommandGroup == null)
                {
                    _translateCommandGroup = new CommandGroup(new List<ICommand>
                {
                    TranslateCommand,
                    DbInsertCommand
                    });
                }
                return _translateCommandGroup;
            }
        }
        
        public void HandleHotKey(object parameter, KeyEventArgs e)
        {
            if (e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control)
            {
                TranslateModel.RawText = Clipboard.GetText();
                TranslateCommandGroup.Execute(null);
            }
        }
    }
}

