using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MTP_Notes
{
    public partial class FormMain : Form
    {
        public static DataTable Table;

        FormNote OpeningNote;

        public static bool DidWeSaveChanges = true;

        public FormMain()
        {
            InitializeComponent();

            Table = new DataTable();
            Table.Columns.Add("Title", typeof(String));
            Table.Columns.Add("Content", typeof(String));
            Table.Columns.Add("Date", typeof(String));

            AccessToDatabase access = new AccessToDatabase();
        }

        // При загрузке формы. Настройки нашей таблицы.
        private void FormMain_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Table;
            dataGridView1.Columns["Content"].Visible = false;
            dataGridView1.Columns["Title"].Width = 307;
            dataGridView1.Columns["Date"].Visible = false;
        }

        // Создать новую заметку.
        private void btnCreate_Click(object sender, EventArgs e)
        {
            int rowsBefore = dataGridView1.Rows.Count;

            OpeningNote = new FormNote();
            OpeningNote.Tag = this;
            OpeningNote.ShowDialog();

            int rowsAfter = dataGridView1.Rows.Count;

            // Добавляем в БД новую заметку (последняя запись из списка заметок):
            if (rowsAfter != rowsBefore)
            {
                object insertTitle = dataGridView1[0, dataGridView1.Rows.Count - 1].Value;
                object insertContent = dataGridView1[1, dataGridView1.Rows.Count - 1].Value;
                
                AccessToDatabase.InsertRows(insertTitle, insertContent);
            }
        }

        // Удалить (выбранную) заметку.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int rowsNum = Table.Rows.Count;

                if (rowsNum != 0)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;

                    object deleteTitle = dataGridView1.CurrentCell.Value;

                    Table.Rows[index].Delete();

                    AccessToDatabase.DeleteRows(deleteTitle);
                }
            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show("Произошла ошибка!\n" + ex, "Внимание!",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Открыть заметку по двойному щелчку для её редактирования.
        private void DataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            object unupdatedTitle = dataGridView1.CurrentCell.Value;

            OpeningNote = new FormNote(this);
            OpeningNote.Tag = this;
            OpeningNote.ShowDialog(this);

            if (DidWeSaveChanges)
            {
                try
                {
                    var updateTitle = dataGridView1.CurrentCell.Value;
                    var updateContent = dataGridView1[1, index].Value; ;

                    AccessToDatabase.UpdateRows(updateTitle, updateContent, unupdatedTitle);
                }
                catch (System.NullReferenceException ex)
                {
                    MessageBox.Show("Произошла ошибка при попытке" +
                        "осуществить запрос на обновление базы данных!\n"
                        + ex, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    MessageBox.Show("Были введены некоректные данные!\n"
                        + ex, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            AccessToDatabase.CloseDatabase();
        }
    }
}
