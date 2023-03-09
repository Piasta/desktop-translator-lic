// <copyright file="MainWindow.xaml.cs" company="Piasta-company">
// Copyright (c) Piasta-company. All rights reserved.
// </copyright>

namespace Desktop_translator
{
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Exit_bt_close(object sender, MouseButtonEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Min_bt_minimalize(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Max_bt_maximalize(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Pin_bt_topmost(object sender, MouseButtonEventArgs e)
        {
            this.Topmost = !this.Topmost;

            if (this.Topmost == true)
            {
                this.pin_dot.Style = (Style)this.FindResource("pin_bt_on_content");
            }
            else
            {
                this.pin_dot.Style = (Style)this.FindResource("pin_bt_off_content");
            }
        }
    }
}