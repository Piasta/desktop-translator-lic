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

        private string _cacheToLanguage;
        public string CacheToLanguage
        {
            get { return _cacheToLanguage; }
            set
            {
                _cacheToLanguage = value;
                OnPropertyChanged(nameof(CacheToLanguage));
                Console.WriteLine("Translate model TO Cache " + CacheToLanguage);

            }
        }

        private string _cacheFromLanguage;
        public string CacheFromLanguage
        {
            get { return _cacheFromLanguage; }
            set
            {
                _cacheFromLanguage = value;
                OnPropertyChanged(nameof(CacheFromLanguage));
                Console.WriteLine("Translate model FROM Cache " + CacheFromLanguage);

            }
        }

        Cache cache = HttpRuntime.Cache;
        public void test()
        {
            CacheFromLanguage = (string)cache.Get("fromLanguage");
            CacheToLanguage = (string)cache.Get("toLanguage");
        }

        public void Translate()
        {
            if (!string.IsNullOrEmpty(RawText))
            {
                if (!string.IsNullOrEmpty(CacheToLanguage))
                {
                    if (IsChecked == true)
                    {
                        CacheFromLanguage = "auto";
                    }

                    if (!string.IsNullOrEmpty(CacheFromLanguage))
                    {
                        try
                        {
                            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={CacheFromLanguage}&tl={CacheToLanguage}&dt=t&q={WebUtility.UrlEncode(RawText)}";
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
