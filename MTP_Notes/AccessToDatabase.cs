using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace MTP_Notes
{
    class AccessToDatabase
    {
        public static string connectString;
        protected static string table = "Notes";

        public static OleDbConnection myConnection;

        public static DateTime noteTime = new DateTime();

        public AccessToDatabase()
        {
            connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Notepad_Acs.mdb;";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            GetDataFromDatabase();
        }

        public void GetDataFromDatabase()
        {
            string query = "SELECT COUNT(db_title) FROM " + AccessToDatabase.table;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            int numberOfFields = Convert.ToInt32(command.ExecuteScalar().ToString());

            // Проверяем, надо ли создать новую запись или апдейтнуть старую: 
            string doesFieldExist = "0";
            for (int i = 0, j_id = 0; i < numberOfFields; i++, j_id++)
            {
                for (; ; )
                {
                    query = $"SELECT COUNT(db_id) > 0 FROM {AccessToDatabase.table} WHERE db_id = {j_id}";
                    command = new OleDbCommand(query, myConnection);
                    doesFieldExist = command.ExecuteScalar().ToString();

                    if (doesFieldExist == "0")
                    {
                        j_id++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                query = "SELECT db_title FROM Notes WHERE db_id = " + j_id;
                command = new OleDbCommand(query, myConnection);
                string selectTitle = command.ExecuteScalar().ToString();

                query = "SELECT db_content FROM Notes WHERE db_id = " + j_id;
                command = new OleDbCommand(query, myConnection);
                string selectContent = command.ExecuteScalar().ToString();

                query = "SELECT db_date FROM Notes WHERE db_id = " + j_id;
                command = new OleDbCommand(query, myConnection);
                string selectTime = command.ExecuteScalar().ToString();

                FormMain.Table.Rows.Add(selectTitle, selectContent, selectTime);
            }
        }

        public static void UpdateRows(object updateTitle, object updateContent, object unupdatedTitle)
        {
            string query = $"UPDATE Notes SET db_title = '{updateTitle}', db_content = '" +
                        updateContent + "', db_date = '" + GetTime() + "' WHERE db_title = '" + unupdatedTitle + "'";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
        }

        public static void DeleteRows(object deleteTitle)
        {
            string query = "DELETE FROM Notes WHERE db_title = '" + deleteTitle + "'";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        public static void InsertRows(object insertTitle, object insertContent)
        {
            string query = "INSERT INTO Notes (db_title, db_content, db_date) VALUES ('" +
                               insertTitle + "', '" + insertContent + "', '" + GetTime() + "');";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        public static void CloseDatabase()
        {
            myConnection.Close();
        }

        public static string GetTime()
        {
            noteTime = DateTime.Now;
            return Convert.ToString(noteTime);
        }
    }
}

