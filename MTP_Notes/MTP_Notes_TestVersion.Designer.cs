namespace MTP_Notes
{
    partial class Main_form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.title_lbl = new System.Windows.Forms.Label();
            this.content_lbl = new System.Windows.Forms.Label();
            this.title_txtBox = new System.Windows.Forms.TextBox();
            this.content_txtBox = new System.Windows.Forms.TextBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.read_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // title_lbl
            // 
            this.title_lbl.AutoSize = true;
            this.title_lbl.Location = new System.Drawing.Point(12, 31);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(27, 13);
            this.title_lbl.TabIndex = 0;
            this.title_lbl.Text = "Title";
            // 
            // content_lbl
            // 
            this.content_lbl.AutoSize = true;
            this.content_lbl.Location = new System.Drawing.Point(143, 87);
            this.content_lbl.Name = "content_lbl";
            this.content_lbl.Size = new System.Drawing.Size(44, 13);
            this.content_lbl.TabIndex = 1;
            this.content_lbl.Text = "Content";
            // 
            // title_txtBox
            // 
            this.title_txtBox.Location = new System.Drawing.Point(45, 28);
            this.title_txtBox.Name = "title_txtBox";
            this.title_txtBox.Size = new System.Drawing.Size(284, 20);
            this.title_txtBox.TabIndex = 2;
            // 
            // content_txtBox
            // 
            this.content_txtBox.Location = new System.Drawing.Point(12, 116);
            this.content_txtBox.Multiline = true;
            this.content_txtBox.Name = "content_txtBox";
            this.content_txtBox.Size = new System.Drawing.Size(317, 281);
            this.content_txtBox.TabIndex = 3;
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(12, 413);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(108, 37);
            this.btn_create.TabIndex = 4;
            this.btn_create.Text = "Create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(221, 413);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(108, 37);
            this.save_btn.TabIndex = 5;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // read_btn
            // 
            this.read_btn.Location = new System.Drawing.Point(353, 413);
            this.read_btn.Name = "read_btn";
            this.read_btn.Size = new System.Drawing.Size(108, 37);
            this.read_btn.TabIndex = 6;
            this.read_btn.Text = "Read";
            this.read_btn.UseVisualStyleBackColor = true;
            this.read_btn.Click += new System.EventHandler(this.read_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(528, 413);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(108, 39);
            this.delete_btn.TabIndex = 7;
            this.delete_btn.Text = "Delete";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(353, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(283, 309);
            this.dataGridView1.TabIndex = 8;
            // 
            // Main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 464);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.read_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.content_txtBox);
            this.Controls.Add(this.title_txtBox);
            this.Controls.Add(this.content_lbl);
            this.Controls.Add(this.title_lbl);
            this.Name = "Main_form";
            this.Text = "Заметки";
            this.Load += new System.EventHandler(this.Main_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.Label content_lbl;
        private System.Windows.Forms.TextBox title_txtBox;
        private System.Windows.Forms.TextBox content_txtBox;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button read_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

