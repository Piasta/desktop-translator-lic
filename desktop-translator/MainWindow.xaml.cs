using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Desktop_translator.MVVM.Model;
using Desktop_translator.MVVM.ViewModel;

namespace Desktop_translator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void exit_bt_close(object sender, MouseButtonEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void min_bt_minimalize(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void max_bt_maximalize(object sender, MouseButtonEventArgs e)
        {
            if(WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
        private void pin_bt_topmost(object sender, MouseButtonEventArgs e)
        {
            this.Topmost = !this.Topmost;

            if (this.Topmost == true)
            {
                pin_dot.Style = (Style)FindResource("pin_bt_on_content");
            }
            else
            {
                pin_dot.Style = (Style)FindResource("pin_bt_off_content");
            }
        }
    }
}