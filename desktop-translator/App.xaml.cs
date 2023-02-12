using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace desktop_translator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string DatabaseName = "History.db";
        static string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string DbPath = System.IO.Path.Combine(FolderPath, DatabaseName);
    }
}
