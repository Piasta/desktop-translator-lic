using desktop_translator.Core;
using desktop_translator.MVVM.ViewModel;
using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

namespace desktop_translator.MVVM.Model
{
    class TranslateModel : ObservableObject
    {
        private string _rawText;

        public string RawText
        {
            get { return _rawText; }
            set
            {
                _rawText = value;
                OnPropertyChanged("RawText");
            }
        }

        private string _translatedText;

        public string TranslatedText
        {
            get { return _translatedText; }
            set
            {
                _translatedText = value;
                OnPropertyChanged("TranslatedText");
            }
        }

        public void Translate()
        {
            var toLanguage = "en";
            var fromLanguage = "pl";


            Console.WriteLine("raw " + RawText);
            Console.WriteLine("translated " + TranslatedText);

            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={WebUtility.UrlEncode(RawText)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            
            try
            {
                var result = webClient.DownloadString(url);
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                TranslatedText = result;

                Console.WriteLine("raw2" + RawText);
                Console.WriteLine("translated2" + TranslatedText);
            }
            catch
            {
                MessageBox.Show("Error");
            }            
        }
    }
}
