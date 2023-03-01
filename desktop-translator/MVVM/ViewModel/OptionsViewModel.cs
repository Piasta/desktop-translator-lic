using desktop_translator.Core;
using desktop_translator.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_translator.MVVM.ViewModel
{
    class OptionsViewModel : ObservableObject
    {
        private OptionsModel _optionsModel;
        public OptionsModel OptionsModel
        {
            get { return _optionsModel; }
            set
            {
                _optionsModel = value;
                OnPropertyChanged("OptionsModel");
            }
        }

        public OptionsViewModel()
        {
            OptionsModel = new OptionsModel();
        }
    }
}
