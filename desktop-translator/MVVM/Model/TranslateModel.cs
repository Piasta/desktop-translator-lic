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

        Cache cache = HttpRuntime.Cache;

        private string _cacheToLanguage;
        public string CacheToLanguage
        {
            get { return _cacheToLanguage; }
            set
            {
                _cacheToLanguage = value;
                OnPropertyChanged("CacheToLanguage");
            }
        }

        private string _cacheFromLanguage;
        public string CacheFromLanguage
        {
            get { return _cacheFromLanguage; }
            set
            {
                _cacheFromLanguage = value;
                OnPropertyChanged("CacheFromLanguage");
                _cacheFromLanguage = (string)cache.Get("fromLanguage");
            }
        }


        public void Translate()
        {



            Console.WriteLine(CacheFromLanguage);

            if (!string.IsNullOrEmpty(CacheToLanguage))
            {
                if (!string.IsNullOrEmpty(RawText))
                {
                    if (IsChecked == true)
                    {
                        CacheFromLanguage = "auto";
                    }

                    Console.WriteLine(CacheFromLanguage);

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
                            MessageBox.Show("NoNetwork");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ChooseLanguage");
                    }
                }
                else
                {
                    MessageBox.Show("ChooseToLanguage");
                }
            }
        }

        public TranslateModel()
        {

        }
    }
}
