namespace desktop_translator.MVVM.ViewModel
{
    using desktop_translator.Core;
    using desktop_translator.MVVM.Model;

    internal class OptionsViewModel : ObservableObject
    {
        private OptionsModel optionsModel;

        public OptionsModel OptionsModel
        {
            get
            {
                return this.optionsModel;
            }

            set
            {
                this.optionsModel = value;
                this.OnPropertyChanged("OptionsModel");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsViewModel"/> class.
        /// </summary>
        public OptionsViewModel()
        {
            this.OptionsModel = new OptionsModel();
        }
    }
}
