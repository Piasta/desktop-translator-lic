﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using desktop_translator.MVVM.ViewModel;

namespace desktop_translator.MVVM.View
{
    /// <summary>
    /// Interaction logic for TranslateView.xaml
    /// </summary>
    public partial class TranslateView : UserControl
    {
        public TranslateView()
        {
            TranslateViewModel Tv = new TranslateViewModel();
            InitializeComponent();
            this.AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(Tv.HandleHotKey), true);
        }
    }
}