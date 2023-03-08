using desktop_translator.Core;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace desktop_translator.MVVM.Model
{
    class HistoryModel : ObservableObject
    {
        public void DbInsert(string TypedText, string TranslatedText)
        {
            if (!string.IsNullOrEmpty(TypedText) && !string.IsNullOrEmpty(TranslatedText))
            {

                string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HistoryDB.db");
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
                m_dbConnection.Open();

                if (m_dbConnection.State == ConnectionState.Open)
                {
                    string sql = "insert into Phrases (TypedText, TranslatedText, UPDDTTM) values (@TypedText, @TranslatedText, @Now)";
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    command.Parameters.AddWithValue("@TypedText", TypedText);
                    command.Parameters.AddWithValue("@TranslatedText", TranslatedText);

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
        public void DbView()
        {
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HistoryDB.db");
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            m_dbConnection.Open();

            if (m_dbConnection.State == ConnectionState.Open)
            {
                string sql = "select * from Phrases order by UPDDTTM desc";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, m_dbConnection);
                table = new DataTable();
                adapter.Fill(table);
            }
            else
            {
                MessageBox.Show("DbViewBREAK");
            }
            m_dbConnection.Close();
        }
    }
}