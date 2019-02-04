using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTP_Notes
{
    public partial class FormNote : Form
    {
        public int Index;
        public bool IsNoteOpenedToEdit = false;
        public string TitleNameBeforeEditing = "";

        // Создание новой заметки.
        public FormNote()
        {
            InitializeComponent();
        }

        // Открытие существующей заметки для редактирования.
        public FormNote(FormMain accessToFormMain)
        {
            InitializeComponent();

            // Запись данных по заметке и её тайтлу из нашей таблицы из главной формы.
            try
            {
                Index = accessToFormMain.dataGridView1.CurrentCell.RowIndex;

                if (Index > -1)
                {
                    tbTitle.Text = FormMain.Table.Rows[Index].ItemArray[0].ToString();
                    tbContent.Text = FormMain.Table.Rows[Index].ItemArray[1].ToString();
                    lDate.Text = FormMain.Table.Rows[Index].ItemArray[2].ToString();
                }
                TitleNameBeforeEditing = tbTitle.Text;
                IsNoteOpenedToEdit = true;
            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show("Произошла ошибка при открытии заметки!\n"
                    + ex, "Внимание!",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isTitleNameOkay = CheckTitleNameIsOkay();

            if (!isTitleNameOkay)
            {
                return;
            }
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult saveIt = MessageBox.Show("Хотите сохранить изменения?",
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (saveIt == DialogResult.Yes)
            {
                bool isTitleNameOkay = CheckTitleNameIsOkay();

                if (!isTitleNameOkay)
                {
                    return;
                }
                FormMain.DidWeSaveChanges = true;
            }
            else
            {
                FormMain.DidWeSaveChanges = false;
            }
            this.Close();
        }
        
        public bool CheckTitleNameIsOkay()
        {
            // Проверка на оригинальность имени заметки, если имеем дело с чем-то новым.
            for (int i = 0; i < ((FormMain)this.Tag).dataGridView1.Rows.Count; ++i)
            {
                object namesOfTitles = ((FormMain)this.Tag).dataGridView1[0, i].Value;

                if (tbTitle.Text == Convert.ToString(namesOfTitles))
                {
                    // Если заметка уже существовала и была открытка для редактирования,
                    // и её имя совпадает с каким-то другим именем, кроме её первоначального:
                    if ((IsNoteOpenedToEdit && tbTitle.Text != TitleNameBeforeEditing) || !IsNoteOpenedToEdit)
                    {
                        MessageBox.Show("Такое имя уже существует." + 
                            "Пожалуйста, придумайте другой заголовок", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            tbTitle.Text = tbTitle.Text.Trim();
            if (String.IsNullOrEmpty(tbTitle.Text))
            {
                MessageBox.Show("Вы оставили заголовок пустым." +
                    "Пожалуйста, исправьте это", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (IsNoteOpenedToEdit)
            {
                ((FormMain)this.Tag).dataGridView1[0, Index].Value = tbTitle.Text;
                ((FormMain)this.Tag).dataGridView1[1, Index].Value = tbContent.Text;
                ((FormMain)this.Tag).dataGridView1[2, Index].Value = AccessToDatabase.GetTime();///
            }
            else
            {
                //((FormMain)this.Tag).Table.Rows.Add(tbTitle.Text, tbContent.Text);
                FormMain.Table.Rows.Add(tbTitle.Text, tbContent.Text, AccessToDatabase.GetTime());///
            }
            return true;
        }
    }
}