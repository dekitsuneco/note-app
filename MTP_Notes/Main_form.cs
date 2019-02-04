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
    public partial class Main_form : Form
    {
        DataTable table;

        public Main_form()
        {
            InitializeComponent();
        }

        private void Main_form_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Content", typeof(String));

            dataGridView1.DataSource = table;
            dataGridView1.Columns["Content"].Visible = false;
            dataGridView1.Columns["Title"].Width = 283;
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            title_txtBox.Clear();
            content_txtBox.Clear();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            table.Rows.Add(title_txtBox.Text, content_txtBox.Text);

            title_txtBox.Clear();
            content_txtBox.Clear();
        }

        private void read_btn_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            if (index > -1)
            {
                title_txtBox.Text = table.Rows[index].ItemArray[0].ToString();
                content_txtBox.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            table.Rows[index].Delete();
        }
    }
}
