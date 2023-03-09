// <copyright file="TranslateModel.cs" company="Piasta-company">
// Copyright (c) Piasta-company. All rights reserved.
// </copyright>

namespace Desktop_translator.MVVM.Model
{
    using System;
    using System.Net;
    using System.Web;
    using System.Web.Caching;
    using System.Windows;
    using Desktop_translator.Core;

    /// <summary>
    /// The model included methods for the TranslateView.
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
            get
            {
                return this.toLanguageKey;
            }

            set
            {
                this.toLanguageKey = value;
                this.OnPropertyChanged(nameof(this.ToLanguageKey));
            }
        }

        private string toLanguageValue;

        /// <summary>
        /// Gets or sets Value of value from cache which are created in HistoryModel dictionary.
        /// </summary>
        public string ToLanguageValue
        {
            get
            {
                return this.toLanguageValue;
            }

            set
            {
                this.toLanguageValue = value;
                this.OnPropertyChanged(nameof(this.ToLanguageValue));
            }
        }

        private string fromLanguageKey = "Auto";

        /// <summary>
        /// Gets or sets Key of value from cache which are created in HistoryModel dictionary.
        /// </summary>
        public string FromLanguageKey
        {
            get
            {
                return this.fromLanguageKey;
            }

            set
            {
                this.fromLanguageKey = value;
                this.OnPropertyChanged(nameof(this.FromLanguageKey));
            }
        }

        private string fromLanguageValue;

        /// <summary>
        /// Gets or sets Value of value from cache which are created in HistoryModel dictionary.
        /// </summary>
        public string FromLanguageValue
        {
            get
            {
                return this.fromLanguageValue;
            }

            set
            {
                this.fromLanguageValue = value;
                this.OnPropertyChanged(nameof(this.FromLanguageValue));
                Console.WriteLine("Translate model From language value = " + this.FromLanguageValue);
            }
        }

        private readonly OptionsModel optionsModel = new OptionsModel();
        private readonly Cache cache = HttpRuntime.Cache;

        /// <summary>
        /// Data validation for Translate method.
        /// </summary>
        public void LanguagesValidation()
        {
            this.FromLanguageKey = (string)this.cache.Get("fromLanguage");
            this.ToLanguageKey = (string)this.cache.Get("toLanguage");

            if (string.IsNullOrEmpty(this.toLanguageKey))
            {
                this.ToLanguageKey = "Not selected";
            }

            if (!string.IsNullOrEmpty(this.toLanguageKey) && this.toLanguageKey != "Not selected")
            {
                this.toLanguageValue = this.optionsModel.Languages[this.toLanguageKey];
            }

            if (this.isChecked)
            {
                this.FromLanguageKey = "Auto";
                this.fromLanguageValue = "auto";
            }

            if (!this.isChecked && string.IsNullOrEmpty(this.fromLanguageKey))
            {
                this.FromLanguageKey = "Not selected";
                this.fromLanguageValue = "";
            }

            if (!this.isChecked && !string.IsNullOrEmpty(this.fromLanguageKey) && this.fromLanguageKey != "Not selected")
            {
                this.fromLanguageValue = this.optionsModel.Languages[this.fromLanguageKey];
            }
        }

        /// <summary>
        /// Translate method.
        /// </summary>
        public void Translate()
        {
            this.LanguagesValidation();

            if (!string.IsNullOrEmpty(this.rawText))
            {
                if (!string.IsNullOrEmpty(this.toLanguageKey) && this.toLanguageKey != "Not selected")
                {
                    if (!string.IsNullOrEmpty(this.fromLanguageValue))
                    {
                        try
                        {
                            string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={this.fromLanguageValue}&tl={this.toLanguageValue}&dt=t&q={WebUtility.UrlEncode(this.rawText)}";
                            WebClient webClient = new WebClient
                            {
                                Encoding = System.Text.Encoding.UTF8,
                            };
                            string result = webClient.DownloadString(url);
                            result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);

                            this.TranslatedText = result;
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
                        this.FromLanguageKey = "Not selected";
                    }
                }
                else
                {
                    MessageBox.Show("To language has been not selected.");
                    this.ToLanguageKey = "Not selected";
                }
            }
        }
    }
}
