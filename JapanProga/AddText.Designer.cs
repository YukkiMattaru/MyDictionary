namespace JapanProga
{
    partial class AddText
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Text_Add_Name = new System.Windows.Forms.TextBox();
            this.Text_Add_Japan = new System.Windows.Forms.TextBox();
            this.Text_Add_Translate = new System.Windows.Forms.TextBox();
            this.Label_TextAdd_Japan = new System.Windows.Forms.Label();
            this.Label_TextAdd_Translate = new System.Windows.Forms.Label();
            this.Label_TextAdd_name = new System.Windows.Forms.Label();
            this.Button_AddText_Add = new System.Windows.Forms.Button();
            this.Button_AddText_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Text_Add_Name
            // 
            this.Text_Add_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Text_Add_Name.Location = new System.Drawing.Point(103, 12);
            this.Text_Add_Name.Name = "Text_Add_Name";
            this.Text_Add_Name.Size = new System.Drawing.Size(555, 30);
            this.Text_Add_Name.TabIndex = 0;
            this.Text_Add_Name.TextChanged += new System.EventHandler(this.Text_Add_Name_TextChanged);
            // 
            // Text_Add_Japan
            // 
            this.Text_Add_Japan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Text_Add_Japan.Location = new System.Drawing.Point(12, 72);
            this.Text_Add_Japan.Multiline = true;
            this.Text_Add_Japan.Name = "Text_Add_Japan";
            this.Text_Add_Japan.Size = new System.Drawing.Size(320, 350);
            this.Text_Add_Japan.TabIndex = 1;
            this.Text_Add_Japan.TextChanged += new System.EventHandler(this.Text_Add_Japan_TextChanged);
            // 
            // Text_Add_Translate
            // 
            this.Text_Add_Translate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Text_Add_Translate.Location = new System.Drawing.Point(338, 71);
            this.Text_Add_Translate.Multiline = true;
            this.Text_Add_Translate.Name = "Text_Add_Translate";
            this.Text_Add_Translate.Size = new System.Drawing.Size(320, 350);
            this.Text_Add_Translate.TabIndex = 2;
            this.Text_Add_Translate.TextChanged += new System.EventHandler(this.Text_Add_Translate_TextChanged);
            // 
            // Label_TextAdd_Japan
            // 
            this.Label_TextAdd_Japan.AutoSize = true;
            this.Label_TextAdd_Japan.Location = new System.Drawing.Point(11, 51);
            this.Label_TextAdd_Japan.Name = "Label_TextAdd_Japan";
            this.Label_TextAdd_Japan.Size = new System.Drawing.Size(201, 17);
            this.Label_TextAdd_Japan.TabIndex = 3;
            this.Label_TextAdd_Japan.Text = "Текст на иностранном языке";
            // 
            // Label_TextAdd_Translate
            // 
            this.Label_TextAdd_Translate.AutoSize = true;
            this.Label_TextAdd_Translate.Location = new System.Drawing.Point(335, 51);
            this.Label_TextAdd_Translate.Name = "Label_TextAdd_Translate";
            this.Label_TextAdd_Translate.Size = new System.Drawing.Size(113, 17);
            this.Label_TextAdd_Translate.TabIndex = 4;
            this.Label_TextAdd_Translate.Text = "Перевод текста";
            // 
            // Label_TextAdd_name
            // 
            this.Label_TextAdd_name.AutoSize = true;
            this.Label_TextAdd_name.Location = new System.Drawing.Point(15, 17);
            this.Label_TextAdd_name.Name = "Label_TextAdd_name";
            this.Label_TextAdd_name.Size = new System.Drawing.Size(82, 17);
            this.Label_TextAdd_name.TabIndex = 5;
            this.Label_TextAdd_name.Text = "Имя файла";
            // 
            // Button_AddText_Add
            // 
            this.Button_AddText_Add.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button_AddText_Add.Location = new System.Drawing.Point(12, 428);
            this.Button_AddText_Add.Name = "Button_AddText_Add";
            this.Button_AddText_Add.Size = new System.Drawing.Size(320, 26);
            this.Button_AddText_Add.TabIndex = 6;
            this.Button_AddText_Add.Text = "Добавить";
            this.Button_AddText_Add.UseVisualStyleBackColor = true;
            // 
            // Button_AddText_Close
            // 
            this.Button_AddText_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_AddText_Close.Location = new System.Drawing.Point(338, 427);
            this.Button_AddText_Close.Name = "Button_AddText_Close";
            this.Button_AddText_Close.Size = new System.Drawing.Size(320, 26);
            this.Button_AddText_Close.TabIndex = 7;
            this.Button_AddText_Close.Text = "Отмена";
            this.Button_AddText_Close.UseVisualStyleBackColor = true;
            // 
            // AddText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 461);
            this.Controls.Add(this.Button_AddText_Close);
            this.Controls.Add(this.Button_AddText_Add);
            this.Controls.Add(this.Label_TextAdd_name);
            this.Controls.Add(this.Label_TextAdd_Translate);
            this.Controls.Add(this.Label_TextAdd_Japan);
            this.Controls.Add(this.Text_Add_Translate);
            this.Controls.Add(this.Text_Add_Japan);
            this.Controls.Add(this.Text_Add_Name);
            this.Name = "AddText";
            this.Text = "AddText";
            this.Load += new System.EventHandler(this.AddText_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Label_TextAdd_Japan;
        private System.Windows.Forms.Label Label_TextAdd_Translate;
        private System.Windows.Forms.Label Label_TextAdd_name;
        private System.Windows.Forms.Button Button_AddText_Add;
        private System.Windows.Forms.Button Button_AddText_Close;
        public System.Windows.Forms.TextBox Text_Add_Name;
        public System.Windows.Forms.TextBox Text_Add_Japan;
        public System.Windows.Forms.TextBox Text_Add_Translate;
    }
}