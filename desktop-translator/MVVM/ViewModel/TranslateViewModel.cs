using desktop_translator.Core;
using desktop_translator.MVVM.Model;
using System;
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

        public TranslateViewModel()
        {
            TranslateModel = new TranslateModel();
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
    }
}

