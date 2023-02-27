using desktop_translator.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;

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
                if (string.IsNullOrEmpty(_rawText))
                {
                    TranslatedText = null;
                }
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

        private Boolean _isChecked = true;
        public Boolean IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        private string _fromLanguage;
        public string FromLanguage
        {
            get { return _fromLanguage; }
            set
            {
                _fromLanguage = value;
                OnPropertyChanged("FromLanguage");
            }
        }

        public void Translate()
        {
            if (!string.IsNullOrEmpty(RawText))
            {
                var toLanguage = "pl";

                if (IsChecked == true)
                {
                    FromLanguage = "auto";
                }

                if (!string.IsNullOrEmpty(FromLanguage))
                {
                    try
                    {
                        var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={FromLanguage}&tl={toLanguage}&dt=t&q={WebUtility.UrlEncode(RawText)}";
                        var webClient = new WebClient
                        {
                            Encoding = System.Text.Encoding.UTF8
                        };
                        var result = webClient.DownloadString(url);
                        result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);

                        TranslatedText = result;
                    }
                    catch
                    {
                        MessageBox.Show("NoNetwork");
                    }
                }
                else
                {
                    MessageBox.Show("ChooseLanguage");
                }
            }
        }

        private List<object> _languages;

        public List<object> Languages
        {
            get { return _languages; }
            set
            {
                _languages = value;
                OnPropertyChanged("Languages");
            }
        }

        public TranslateModel()
        {
            Languages = new List<object>
            {
                new {Key = "English", Value = "en" },
                new {Key = "Polish", Value = "pl" }
            };
        }
    }
}
