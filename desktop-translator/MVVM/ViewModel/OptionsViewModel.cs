// <copyright file="OptionsViewModel.cs" company="Piasta-company">
// Copyright (c) Piasta-company. All rights reserved.
// </copyright>

namespace Desktop_translator.MVVM.ViewModel
{
    using Desktop_translator.Core;
    using Desktop_translator.MVVM.Model;

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
