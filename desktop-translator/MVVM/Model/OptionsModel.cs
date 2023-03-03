using desktop_translator.Core;
using System;
using System.Collections.Generic;
using System.Web;

namespace desktop_translator.MVVM.Model
{
    class OptionsModel : ObservableObject
    {
        System.Web.Caching.Cache cache = HttpRuntime.Cache;

        private string _fromLanguage;
        public string FromLanguage
        {
            get { return _fromLanguage; }
            set
            {
                _fromLanguage = value;
                OnPropertyChanged("FromLanguage");
                cache.Insert("fromLanguage", _fromLanguage);
            }
        }

        private string _toLanguage;
        public string ToLanguage
        {
            get { return _toLanguage; }
            set
            {
                _toLanguage = value;
                OnPropertyChanged("ToLanguage");
                cache.Insert("toLanguage", _toLanguage);
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

        public OptionsModel()
        {
            Languages = new List<object>
            {
                new {Key =  "Afrikaans", Value = "af"},
                new {Key =  "Albanian", Value = "sq"},
                new {Key =  "Amharic", Value = "am"},
                new {Key =  "Arabic", Value = "ar"},
                new {Key =  "Armenian", Value = "hy"},
                new {Key =  "Assamese", Value = "as"},
                new {Key =  "Aymara", Value = "ay"},
                new {Key =  "Azerbaijani", Value = "az"},
                new {Key =  "Bambara", Value = "bm"},
                new {Key =  "Basque", Value = "eu"},
                new {Key =  "Belarusian", Value = "be"},
                new {Key =  "Bengali", Value = "bn"},
                new {Key =  "Bhojpuri", Value = "bho"},
                new {Key =  "Bosnian", Value = "bs"},
                new {Key =  "Bulgarian", Value = "bg"},
                new {Key =  "Catalan", Value = "ca"},
                new {Key =  "Cebuano", Value = "ceb"},
                new {Key =  "Chichewa", Value = "ny"},
                new {Key =  "Chinese", Value = "zh-CN"},
                new {Key =  "Corsican", Value = "co"},
                new {Key =  "Croatian", Value = "hr"},
                new {Key =  "Czech", Value = "cs"},
                new {Key =  "Danish", Value = "da"},
                new {Key =  "Dhivehi", Value = "dv"},
                new {Key =  "Dogri", Value = "doi"},
                new {Key =  "Dutch", Value = "nl"},
                new {Key =  "English", Value = "en"},
                new {Key =  "Esperanto", Value = "eo"},
                new {Key =  "Estonian", Value = "et"},
                new {Key =  "Ewe", Value = "ee"},
                new {Key =  "Filipino", Value = "tl"},
                new {Key =  "Finnish", Value = "fi"},
                new {Key =  "French", Value = "fr"},
                new {Key =  "Frisian", Value = "fy"},
                new {Key =  "Galician", Value = "gl"},
                new {Key =  "Georgian", Value = "ka"},
                new {Key =  "German", Value = "de"},
                new {Key =  "Greek", Value = "el"},
                new {Key =  "Guarani", Value = "gn"},
                new {Key =  "Gujarati", Value = "gu"},
                new {Key =  "Haitian Creole", Value = "ht"},
                new {Key =  "Hausa", Value = "ha"},
                new {Key =  "Hawaiian", Value = "haw"},
                new {Key =  "Hebrew", Value = "iw"},
                new {Key =  "Hindi", Value = "hi"},
                new {Key =  "Hmong", Value = "hmn"},
                new {Key =  "Hungarian", Value = "hu"},
                new {Key =  "Icelandic", Value = "is"},
                new {Key =  "Igbo", Value = "ig"},
                new {Key =  "Ilocano", Value = "ilo"},
                new {Key =  "Indonesian", Value = "id"},
                new {Key =  "Irish", Value = "ga"},
                new {Key =  "Italian", Value = "it"},
                new {Key =  "Japanese", Value = "ja"},
                new {Key =  "Javanese", Value = "jw"},
                new {Key =  "Kannada", Value = "kn"},
                new {Key =  "Kazakh", Value = "kk"},
                new {Key =  "Khmer", Value = "km"},
                new {Key =  "Kinyarwanda", Value = "rw"},
                new {Key =  "Konkani", Value = "gom"},
                new {Key =  "Korean", Value = "ko"},
                new {Key =  "Krio", Value = "kri"},
                new {Key =  "Kurdish (Kurmanji)", Value = "ku"},
                new {Key =  "Kurdish (Sorani)", Value = "ckb"},
                new {Key =  "Kyrgyz", Value = "ky"},
                new {Key =  "Lao", Value = "lo"},
                new {Key =  "Latin", Value = "la"},
                new {Key =  "Latvian", Value = "lv"},
                new {Key =  "Lingala", Value = "ln"},
                new {Key =  "Lithuanian", Value = "lt"},
                new {Key =  "Luganda", Value = "lg"},
                new {Key =  "Luxembourgish", Value = "lb"},
                new {Key =  "Macedonian", Value = "mk"},
                new {Key =  "Maithili", Value = "mai"},
                new {Key =  "Malagasy", Value = "mg"},
                new {Key =  "Malay", Value = "ms"},
                new {Key =  "Malayalam", Value = "ml"},
                new {Key =  "Maltese", Value = "mt"},
                new {Key =  "Maori", Value = "mi"},
                new {Key =  "Marathi", Value = "mr"},
                new {Key =  "Meiteilon (Manipuri)", Value = "mni-Mtei"},
                new {Key =  "Mizo", Value = "lus"},
                new {Key =  "Mongolian", Value = "mn"},
                new {Key =  "Myanmar (Burmese)", Value = "my"},
                new {Key =  "Nepali", Value = "ne"},
                new {Key =  "Norwegian", Value = "no"},
                new {Key =  "Odia (Oriya)", Value = "or"},
                new {Key =  "Oromo", Value = "om"},
                new {Key =  "Pashto", Value = "ps"},
                new {Key =  "Persian", Value = "fa"},
                new {Key =  "Polish", Value = "pl"},
                new {Key =  "Portuguese", Value = "pt"},
                new {Key =  "Punjabi", Value = "pa"},
                new {Key =  "Quechua", Value = "qu"},
                new {Key =  "Romanian", Value = "ro"},
                new {Key =  "Russian", Value = "ru"},
                new {Key =  "Samoan", Value = "sm"},
                new {Key =  "Sanskrit", Value = "sa"},
                new {Key =  "Scots Gaelic", Value = "gd"},
                new {Key =  "Sepedi", Value = "nso"},
                new {Key =  "Serbian", Value = "sr"},
                new {Key =  "Sesotho", Value = "st"},
                new {Key =  "Shona", Value = "sn"},
                new {Key =  "Sindhi", Value = "sd"},
                new {Key =  "Sinhala", Value = "si"},
                new {Key =  "Slovak", Value = "sk"},
                new {Key =  "Slovenian", Value = "sl"},
                new {Key =  "Somali", Value = "so"},
                new {Key =  "Spanish", Value = "es"},
                new {Key =  "Sundanese", Value = "su"},
                new {Key =  "Swahili", Value = "sw"},
                new {Key =  "Swedish", Value = "sv"},
                new {Key =  "Tajik", Value = "tg"},
                new {Key =  "Tamil", Value = "ta"},
                new {Key =  "Tatar", Value = "tt"},
                new {Key =  "Telugu", Value = "te"},
                new {Key =  "Thai", Value = "th"},
                new {Key =  "Tigrinya", Value = "ti"},
                new {Key =  "Tsonga", Value = "ts"},
                new {Key =  "Turkish", Value = "tr"},
                new {Key =  "Turkmen", Value = "tk"},
                new {Key =  "Twi", Value = "ak"},
                new {Key =  "Ukrainian", Value = "uk"},
                new {Key =  "Urdu", Value = "ur"},
                new {Key =  "Uyghur", Value = "ug"},
                new {Key =  "Uzbek", Value = "uz"},
                new {Key =  "Vietnamese", Value = "vi"},
                new {Key =  "Welsh", Value = "cy"},
                new {Key =  "Xhosa", Value = "xh"},
                new {Key =  "Yiddish", Value = "yi"},
                new {Key =  "Yoruba", Value = "yo"},
                new {Key =  "Zulu", Value = "zu"}
            };
        }
    }
}
