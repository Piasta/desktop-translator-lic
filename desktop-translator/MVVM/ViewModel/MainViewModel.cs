using desktop_translator.Core;
using System;

namespace desktop_translator.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand TranslateViewCommand { get; set; }
        public RelayCommand HistoryViewCommand { get; set; }
        public RelayCommand OptionsViewCommand { get; set; }
        public RelayCommand InfoViewCommand { get; set; }

        public TranslateViewModel TranslateVM { get; set; }
        public HistoryViewModel HistoryVM { get; set; }
        public OptionsViewModel OptionsVM { get; set; }
        public InfoViewModel InfoVM { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            TranslateVM = new TranslateViewModel();
            HistoryVM = new HistoryViewModel();
            OptionsVM = new OptionsViewModel();
            InfoVM = new InfoViewModel();

            CurrentView = TranslateVM;

            TranslateViewCommand = new RelayCommand(o => {
                CurrentView = TranslateVM;
            });

            HistoryViewCommand = new RelayCommand(o => {
                CurrentView = HistoryVM;
            });

            OptionsViewCommand = new RelayCommand(o => {
                CurrentView = OptionsVM;
            });

            InfoViewCommand = new RelayCommand(o => {
                CurrentView = InfoVM;
            });
        }
    }
}
