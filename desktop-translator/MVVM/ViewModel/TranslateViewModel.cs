using desktop_translator.Core;
using desktop_translator.MVVM.Model;
using System;
using System.Collections.Generic;
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

        public TranslateViewModel()
        {
            TranslateModel = new TranslateModel();
            HistoryModel = new HistoryModel();
        }

        public ICommand TranslateCommand => new RelayCommand(Translate, CanExecuteTranslate);
        private bool CanExecuteTranslate(object parameter)
        {
            return true;
        }

        private void Translate(object parameter)
        {
            TranslateModel.Translate();
        }


        public ICommand TestCommand => new RelayCommand(Test, CanExecuteTest);

        private bool CanExecuteTest(object parameter)
        {
            return true;
        }

        private void Test(object parameter)
        {
            HistoryModel.Test();
        }

        private CommandGroup _commandGroup;

        public CommandGroup CommandGroup
        {
            get
            {
                if (_commandGroup == null)
                {
                    _commandGroup = new CommandGroup(new List<ICommand>
                {
                    TranslateCommand,
                    TestCommand
                    });
                }
                return _commandGroup;
            }
        }
    }
}

