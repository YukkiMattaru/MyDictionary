namespace JapanProga
{
    partial class FormSize
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
            this.size_label_word = new System.Windows.Forms.Label();
            this.size_label_reading = new System.Windows.Forms.Label();
            this.size_label_translate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // size_label_word
            // 
            this.size_label_word.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.size_label_word.Location = new System.Drawing.Point(12, 9);
            this.size_label_word.Name = "size_label_word";
            this.size_label_word.Size = new System.Drawing.Size(311, 71);
            this.size_label_word.TabIndex = 0;
            this.size_label_word.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // size_label_reading
            // 
            this.size_label_reading.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.size_label_reading.Location = new System.Drawing.Point(12, 99);
            this.size_label_reading.Name = "size_label_reading";
            this.size_label_reading.Size = new System.Drawing.Size(311, 71);
            this.size_label_reading.TabIndex = 1;
            this.size_label_reading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // size_label_translate
            // 
            this.size_label_translate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.size_label_translate.Location = new System.Drawing.Point(12, 189);
            this.size_label_translate.Name = "size_label_translate";
            this.size_label_translate.Size = new System.Drawing.Size(313, 89);
            this.size_label_translate.TabIndex = 2;
            this.size_label_translate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(335, 287);
            this.Controls.Add(this.size_label_translate);
            this.Controls.Add(this.size_label_reading);
            this.Controls.Add(this.size_label_word);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSize";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label size_label_word;
        private System.Windows.Forms.Label size_label_reading;
        private System.Windows.Forms.Label size_label_translate;
    }
}