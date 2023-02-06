using desktop_translator.Core;
using desktop_translator.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace desktop_translator.MVVM.ViewModel
{
    public class TranslateViewModel
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
 
