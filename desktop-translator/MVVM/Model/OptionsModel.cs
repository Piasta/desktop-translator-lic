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
                new {Key = "English", Value = "en" },
                new {Key = "Polish", Value = "pl" },
                new {Key = "Korean", Value = "ko" }
            };
        }
    }
}
