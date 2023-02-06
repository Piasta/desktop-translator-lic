using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace desktop_translator.MVVM.Model
{
    public class TranslateModel 
    {
        private string rawText;

        public string RawText
        {
            get { return rawText; }
            set
            {
                rawText = value;
                OnPropertyChanged("RawText");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Translate()
        {
            MessageBox.Show(rawText);
        }
    }
}
