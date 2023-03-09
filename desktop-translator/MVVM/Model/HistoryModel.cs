// <copyright file="HistoryModel.cs" company="Piasta-company">
// Copyright (c) Piasta-company. All rights reserved.
// </copyright>

namespace Desktop_translator.MVVM.Model
{
    using System;
    using System.Data;
    using System.Data.SQLite;
    using System.Windows;
    using Desktop_translator.Core;

    /// <summary>
    /// The model included methods for the HistoryView.
    /// </summary>
    internal class HistoryModel : ObservableObject
    {
        /// <summary>
        /// Method that opens a connection to a database and enters data into it.
        /// </summary>
        public void DbInsert(string typedText, string translatedText)
        {
            if (!string.IsNullOrEmpty(typedText) && !string.IsNullOrEmpty(translatedText))
            {

                string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HistoryDB.db");
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
                m_dbConnection.Open();

                if (m_dbConnection.State == ConnectionState.Open)
                {
                    string sql = "insert into Phrases (TypedText, TranslatedText, UPDDTTM) values (@TypedText, @TranslatedText, @Now)";
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    command.Parameters.AddWithValue("@TypedText", typedText);
                    command.Parameters.AddWithValue("@TranslatedText", translatedText);

                    DateTime now = DateTime.Now;
                    string formattedData = now.ToString("hh:mm:ss MM/dd/yy");

                    command.Parameters.AddWithValue("@Now", formattedData);
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("DbInsertBREAK");
                }

                m_dbConnection.Close();
            }
        }

        public DataTable table;

        /// <summary>
        /// Method that opens a connection to a database and select data from it.
        /// </summary>
        public void DbView()
        {
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HistoryDB.db");
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            m_dbConnection.Open();

            if (m_dbConnection.State == ConnectionState.Open)
            {
                string sql = "select * from Phrases order by UPDDTTM desc";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, m_dbConnection);
                this.table = new DataTable();
                adapter.Fill(this.table);
            }
            else
            {
                MessageBox.Show("DbViewBREAK");
            }

            m_dbConnection.Close();
        }
    }
}