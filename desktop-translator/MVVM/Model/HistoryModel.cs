using desktop_translator.Core;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Net;
using System.Windows;

namespace desktop_translator.MVVM.Model
{
    class HistoryModel : ObservableObject
    {
      
        public void Test()
        {

            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HistoryDB.db");

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");

            m_dbConnection.Open();

            if (m_dbConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("OPEN");
                string sql = "insert into Phrases (TypedText, TranslatedText) values ('WpisaneZ', 'Kodu')";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Close");
            }

        }
    }
}
