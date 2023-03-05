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
                    _translatedText = null;
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
                Console.WriteLine("Translate model To language key = " + ToLanguageKey);

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
                Console.WriteLine("Translate model To language value = " + ToLanguageValue);

            }
        }

        private string _fromLanguageKey;
        public string FromLanguageKey
        {
            get { return _fromLanguageKey; }
            set
            {
                _fromLanguageKey = value;
                OnPropertyChanged(nameof(FromLanguageKey));
                Console.WriteLine("Translate model From language key = " + FromLanguageKey);

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


        Cache cache = HttpRuntime.Cache;
        public void test()
        {
            FromLanguageKey = (string)cache.Get("fromLanguage");
            ToLanguageKey = (string)cache.Get("toLanguage");
            
            if (!string.IsNullOrEmpty(_fromLanguageKey) && !string.IsNullOrEmpty(_toLanguageKey))
            {
                OptionsModel OptionsModel = new OptionsModel();
                FromLanguageValue = OptionsModel.Languages[_fromLanguageKey];
                ToLanguageValue = OptionsModel.Languages[_toLanguageKey];
            }
        }

        public void Translate()
        {

            if (!string.IsNullOrEmpty(_rawText))
            {
                if (!string.IsNullOrEmpty(_toLanguageKey) && _toLanguageKey != "Not selected")
                {
                    if (_isChecked == true)
                    {
                        _fromLanguageValue = "auto";
                    }

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
                    }
                }
                else
                {
                    MessageBox.Show("To language has been not selected.");
                }
            }
        }
    }
}
