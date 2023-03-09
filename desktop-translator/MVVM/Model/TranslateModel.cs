namespace Desktop_translator.MVVM.Model
{
    using System;
    using System.Net;
    using System.Web;
    using System.Web.Caching;
    using System.Windows;
    using Desktop_translator.Core;

    /// <summary>
    /// The model in which the methods for the TranslateView are created.
    /// </summary>
    internal class TranslateModel : ObservableObject
    {
        private string rawText;

        public string RawText
        {
            get
            {
                return this.rawText;
            }

            set
            {
                this.rawText = value;
                this.OnPropertyChanged(nameof(this.RawText));
                if (string.IsNullOrEmpty(this.rawText))
                {
                    this.TranslatedText = null;
                }
            }
        }

        private string translatedText;

        public string TranslatedText
        {
            get
            {
                return this.translatedText;
            }

            set
            {
                this.translatedText = value;
                this.OnPropertyChanged(nameof(this.TranslatedText));
            }
        }


        private bool isChecked = true;

        /// <summary>
        /// Gets or sets a value indicating whether automatic language detection is On/Off.
        /// </summary>
        public bool IsChecked
        {
            get
            {
                return this.isChecked;
            }

            set
            {
                this.isChecked = value;
                this.OnPropertyChanged(nameof(this.IsChecked));
            }
        }

        private string toLanguageKey = "Not selected";

        /// <summary>
        /// Gets or sets Key of value from cache which are created in HistoryModel dictionary.
        /// </summary>
        public string ToLanguageKey
        {
            get { return toLanguageKey; }
            set
            {
                toLanguageKey = value;
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

            if (string.IsNullOrEmpty(toLanguageKey))
            {
                ToLanguageKey = "Not selected";
            }
            if (!string.IsNullOrEmpty(toLanguageKey) && toLanguageKey != "Not selected")
            {
                _toLanguageValue = OptionsModel.Languages[toLanguageKey];
            }
            if (isChecked)
            {
                FromLanguageKey = "Auto";
                _fromLanguageValue = "auto"; 
            }
            if (!isChecked && string.IsNullOrEmpty(_fromLanguageKey))
            {
                FromLanguageKey = "Not selected";
                _fromLanguageValue = "";
            }
            if (!isChecked && !string.IsNullOrEmpty(_fromLanguageKey) && _fromLanguageKey != "Not selected")
            {
                _fromLanguageValue = OptionsModel.Languages[_fromLanguageKey];
            }
        }

        public void Translate()
        {
            LanguagesValidation();

            if (!string.IsNullOrEmpty(rawText))
            {
                if (!string.IsNullOrEmpty(toLanguageKey) && toLanguageKey != "Not selected")
                {
                    if (!string.IsNullOrEmpty(_fromLanguageValue))
                    {
                        try
                        {
                            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={_fromLanguageValue}&tl={_toLanguageValue}&dt=t&q={WebUtility.UrlEncode(rawText)}";
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
