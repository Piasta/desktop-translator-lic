using desktop_translator.Core;
using System;
using System.Net;
using System.Web;
using System.Web.Caching;
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

        private bool _isChecked = true;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        private string _toLanguageKey = "Not selected";
        public string ToLanguageKey
        {
            get { return _toLanguageKey; }
            set
            {
                _toLanguageKey = value;
                OnPropertyChanged(nameof(ToLanguageKey));
            }
        }

        private string _toLanguageValue;
        public string ToLanguageValue
        {
            get { return _toLanguageValue; }
            set
            {
                _toLanguageValue = value;
                OnPropertyChanged(nameof(ToLanguageValue));
            }
        }

        private string _fromLanguageKey = "Auto";
        public string FromLanguageKey
        {
            get { return _fromLanguageKey; }
            set
            {
                _fromLanguageKey = value;
                OnPropertyChanged(nameof(FromLanguageKey));
            }
        }
        private string _fromLanguageValue;
        public string FromLanguageValue
        {
            get { return _fromLanguageValue; }
            set
            {
                _fromLanguageValue = value;
                OnPropertyChanged(nameof(FromLanguageValue));
                Console.WriteLine("Translate model From language value = " + FromLanguageValue);
            }
        }

        OptionsModel OptionsModel = new OptionsModel();

        Cache cache = HttpRuntime.Cache;
        public void LanguagesValidation()
        {
            FromLanguageKey = (string)cache.Get("fromLanguage");
            ToLanguageKey = (string)cache.Get("toLanguage");

            if (string.IsNullOrEmpty(_toLanguageKey))
            {
                ToLanguageKey = "Not selected";
            }
            if (!string.IsNullOrEmpty(_toLanguageKey) && _toLanguageKey != "Not selected")
            {
                _toLanguageValue = OptionsModel.Languages[_toLanguageKey];
            }
            if (_isChecked)
            {
                FromLanguageKey = "Auto";
                _fromLanguageValue = "auto"; 
            }
            if (!_isChecked && string.IsNullOrEmpty(_fromLanguageKey))
            {
                FromLanguageKey = "Not selected";
                _fromLanguageValue = "";
            }
            if (!_isChecked && !string.IsNullOrEmpty(_fromLanguageKey) && _fromLanguageKey != "Not selected")
            {
                _fromLanguageValue = OptionsModel.Languages[_fromLanguageKey];
            }
        }

        public void Translate()
        {
            LanguagesValidation();

            if (!string.IsNullOrEmpty(_rawText))
            {
                if (!string.IsNullOrEmpty(_toLanguageKey) && _toLanguageKey != "Not selected")
                {
                    if (!string.IsNullOrEmpty(_fromLanguageValue))
                    {
                        try
                        {
                            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={_fromLanguageValue}&tl={_toLanguageValue}&dt=t&q={WebUtility.UrlEncode(_rawText)}";
                            var webClient = new WebClient
                            {
                                Encoding = System.Text.Encoding.UTF8
                            };
                            var result = webClient.DownloadString(url);
                            result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);

                            TranslatedText = result;
                            Console.WriteLine("Result is = " + result);
                        }
                        catch
                        {
                            MessageBox.Show("No internet connection.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("From language has been not selected.");
                        FromLanguageKey = "Not selected";
                    }
                }
                else
                {
                    MessageBox.Show("To language has been not selected.");
                    ToLanguageKey = "Not selected";
                }
            }
        }
    }
}
