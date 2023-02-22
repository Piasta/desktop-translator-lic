using desktop_translator.Core;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Media;

namespace desktop_translator.MVVM.Model
{
    class HistoryModel : ObservableObject
    {

        public void DbInsert(string TypedText, string TranslatedText)
        {
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HistoryDB.db");
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            m_dbConnection.Open();

            if (m_dbConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("DbInsertWORK");
                string sql = "insert into Phrases (TypedText, TranslatedText) values (@TypedText, @TranslatedText)";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.Parameters.AddWithValue("@TypedText", TypedText);
                command.Parameters.AddWithValue("@TranslatedText", TranslatedText);
                command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("DbInsertBREAK");
            }
            m_dbConnection.Close();

            TranslateModel TranslateModel = new TranslateModel();

            Console.WriteLine("CHUJ" + TranslateModel.TranslatedText);

        }

        public DataTable table;

        public void DbView()
        {
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HistoryDB.db");
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            m_dbConnection.Open();

            if (m_dbConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("DbViewOpen");
                string sql = "select * from Phrases";

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, m_dbConnection);
                table = new DataTable();
                adapter.Fill(table);
                

                //SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                //SQLiteDataReader reader = command.ExecuteReader();

                //while (reader.Read())
                //    for (int i = 0; i < reader.FieldCount; i++)
                //        Console.WriteLine(reader[i]);
            }
            else
            {
                MessageBox.Show("DbViewBREAK");
            }
            m_dbConnection.Close();
        }

        //private Brush _backgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#15A"));
        //public Brush BackgroundColor
        //{
        //    get { return _backgroundColor; }
        //    set { _backgroundColor = value; OnPropertyChanged(nameof(BackgroundColor)); }
        //}
    }
}

