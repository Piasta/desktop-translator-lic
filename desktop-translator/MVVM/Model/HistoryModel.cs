using System;
using SQLite;
using desktop_translator.Core;

namespace desktop_translator.MVVM.Model
{
    class HistoryModel : ObservableObject
    {
        private TranslateModel _translateModel;

        public TranslateModel TranslateModel
        {
            get { return _translateModel; }
            set
            {
                _translateModel = value;
                OnPropertyChanged("TranslateModel");
            }
        }

        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public override string ToString()
        {
            return $"{TranslateModel.RawText} - {TranslateModel.TranslatedText}";
        }

    }
}
