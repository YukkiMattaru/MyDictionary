using System;
using System.Windows.Forms;

namespace JapanProga
{
    public partial class AddText : Form
    {
        public AddText()
        {
            InitializeComponent();
        }

        private void AddText_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            Button_AddText_Add.Enabled = false;
        }

        private void Check()
        {
            if (Text_Add_Name.Text.Length == 0 || Text_Add_Japan.Text.Length == 0 || Text_Add_Translate.Text.Length == 0)
            {
                Button_AddText_Add.Enabled = false;
            }
            else
            {
                Button_AddText_Add.Enabled = true;
            }
        }

        private void Text_Add_Name_TextChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void Text_Add_Japan_TextChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void Text_Add_Translate_TextChanged(object sender, EventArgs e)
        {
            Check();
        }
    }
}
