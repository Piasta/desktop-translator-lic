using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            InitializeComponent();

            TranslateViewModel TranslateViewModel = new TranslateViewModel();
            HistoryViewModel HistoryViewModel = new HistoryViewModel();

        }

        private void RawTextBox_TextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}