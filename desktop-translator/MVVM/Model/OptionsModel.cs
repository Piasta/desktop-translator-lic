// <copyright file="OptionsModel.cs" company="Piasta-company">
// Copyright (c) Piasta-company. All rights reserved.
// </copyright>

namespace Desktop_translator.MVVM.Model
{
    using System.Collections.Generic;
    using System.Web;
    using Desktop_translator.Core;

    /// <summary>
    /// The model included methods for the OptionsView.
    /// </summary>
    internal class OptionsModel : ObservableObject
    {
        private readonly System.Web.Caching.Cache cache = HttpRuntime.Cache;

        private string fromLanguage;

        /// <summary>
        /// Gets or sets variable to store and send selected language to cache.
        /// </summary>
        public string FromLanguage
        {
            get
            {
                return this.fromLanguage;
            }

            set
            {
                this.fromLanguage = value;
                this.OnPropertyChanged(nameof(this.FromLanguage));
                this.cache.Insert(nameof(this.fromLanguage), this.fromLanguage);
            }
        }

        private string toLanguage;

        /// <summary>
        /// Gets or sets variable to store and send selected language to cache.
        /// </summary>
        public string ToLanguage
        {
            get
            {
                return this.toLanguage;
            }

            set
            {
                this.toLanguage = value;
                this.OnPropertyChanged(nameof(this.ToLanguage));
                this.cache.Insert(nameof(this.toLanguage), this.toLanguage);
            }
        }


        private Dictionary<string, string> languages;

        /// <summary>
        /// Gets or sets dictionary of all languages to select.
        /// </summary>
        public Dictionary<string, string> Languages
        {
            get
            {
                return this.languages;
            }

            set
            {
                this.languages = value;
                this.OnPropertyChanged(nameof(this.Languages));
            }
        }

        public OptionsModel()
        {
            this.languages = new Dictionary<string, string>
            {
                { "Afrikaans", "af" },
                { "Albanian", "sq" },
                { "Amharic", "am" },
                { "Arabic", "ar" },
                { "Armenian", "hy" },
                { "Assamese", "as" },
                { "Aymara", "ay" },
                { "Azerbaijani", "az" },
                { "Bambara", "bm" },
                { "Basque", "eu" },
                { "Belarusian", "be" },
                { "Bengali", "bn" },
                { "Bhojpuri", "bho" },
                { "Bosnian", "bs" },
                { "Bulgarian", "bg" },
                { "Catalan", "ca" },
                { "Cebuano", "ceb" },
                { "Chichewa", "ny" },
                { "Chinese", "zh-CN" },
                { "Corsican", "co" },
                { "Croatian", "hr" },
                { "Czech", "cs" },
                { "Danish", "da" },
                { "Dhivehi", "dv" },
                { "Dogri", "doi" },
                { "Dutch", "nl" },
                { "English", "en" },
                { "Esperanto", "eo" },
                { "Estonian", "et" },
                { "Ewe", "ee" },
                { "Filipino", "tl" },
                { "Finnish", "fi" },
                { "French", "fr" },
                { "Frisian", "fy" },
                { "Galician", "gl" },
                { "Georgian", "ka" },
                { "German", "de" },
                { "Greek", "el" },
                { "Guarani", "gn" },
                { "Gujarati", "gu" },
                { "Haitian Creole", "ht" },
                { "Hausa", "ha" },
                { "Hawaiian", "haw" },
                { "Hebrew", "iw" },
                { "Hindi", "hi" },
                { "Hmong", "hmn" },
                { "Hungarian", "hu" },
                { "Icelandic", "is" },
                { "Igbo", "ig" },
                { "Ilocano", "ilo" },
                { "Indonesian", "id" },
                { "Irish", "ga" },
                { "Italian", "it" },
                { "Japanese", "ja" },
                { "Javanese", "jw" },
                { "Kannada", "kn" },
                { "Kazakh", "kk" },
                { "Khmer", "km" },
                { "Kinyarwanda", "rw" },
                { "Konkani", "gom" },
                { "Korean", "ko" },
                { "Krio", "kri" },
                { "Kurdish (Kurmanji)", "ku" },
                { "Kurdish (Sorani)", "ckb" },
                { "Kyrgyz", "ky" },
                { "Lao", "lo" },
                { "Latin", "la" },
                { "Latvian", "lv" },
                { "Lingala", "ln" },
                { "Lithuanian", "lt" },
                { "Luganda", "lg" },
                { "Luxembourgish", "lb" },
                { "Macedonian", "mk" },
                { "Maithili", "mai" },
                { "Malagasy", "mg" },
                { "Malay", "ms" },
                { "Malayalam", "ml" },
                { "Maltese", "mt" },
                { "Maori", "mi" },
                { "Marathi", "mr" },
                { "Meiteilon (Manipuri)", "mni-Mtei" },
                { "Mizo", "lus" },
                { "Mongolian", "mn" },
                { "Myanmar (Burmese)", "my" },
                { "Nepali", "ne" },
                { "Norwegian", "no" },
                { "Odia (Oriya)", "or" },
                { "Oromo", "om" },
                { "Pashto", "ps" },
                { "Persian", "fa" },
                { "Polish", "pl" },
                { "Portuguese", "pt" },
                { "Punjabi", "pa" },
                { "Quechua", "qu" },
                { "Romanian", "ro" },
                { "Russian", "ru" },
                { "Samoan", "sm" },
                { "Sanskrit", "sa" },
                { "Scots Gaelic", "gd" },
                { "Sepedi", "nso" },
                { "Serbian", "sr" },
                { "Sesotho", "st" },
                { "Shona", "sn" },
                { "Sindhi", "sd" },
                { "Sinhala", "si" },
                { "Slovak", "sk" },
                { "Slovenian", "sl" },
                { "Somali", "so" },
                { "Spanish", "es" },
                { "Sundanese", "su" },
                { "Swahili", "sw" },
                { "Swedish", "sv" },
                { "Tajik", "tg" },
                { "Tamil", "ta" },
                { "Tatar", "tt" },
                { "Telugu", "te" },
                { "Thai", "th" },
                { "Tigrinya", "ti" },
                { "Tsonga", "ts" },
                { "Turkish", "tr" },
                { "Turkmen", "tk" },
                { "Twi", "ak" },
                { "Ukrainian", "uk" },
                { "Urdu", "ur" },
                { "Uyghur", "ug" },
                { "Uzbek", "uz" },
                { "Vietnamese", "vi" },
                { "Welsh", "cy" },
                { "Xhosa", "xh" },
                { "Yiddish", "yi" },
                { "Yoruba", "yo" },
                { "Zulu", "zu" },
            };
        }
    }
}
