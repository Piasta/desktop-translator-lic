// <copyright file="App.xaml.cs" company="Piasta-company">
// Copyright (c) Piasta-company. All rights reserved.
// </copyright>

namespace Desktop_translator
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        private static readonly string DatabaseName = "History.db";
        private static readonly string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string DbPath = System.IO.Path.Combine(FolderPath, DatabaseName);
    }
}
