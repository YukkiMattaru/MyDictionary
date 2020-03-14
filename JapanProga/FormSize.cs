using System.Windows.Forms;
using System.Diagnostics;

namespace JapanProga
{
    public partial class FormSize : Form
    {
        private Form1 Form1 { get; set; }
        public FormSize(Form1 f)
        {
            Form1 = f;
            Visible = false;
        }
        public FormSize()
        {
            InitializeComponent();
        }
        public string _label_word
        {
            get { return size_label_word.Text; }
            set { size_label_word.Text = value; }
        }
        public string _label_reading
        {
            get { return size_label_reading.Text; }
            set { size_label_reading.Text = value; }
        }
        public string _label_translate
        {
            get { return size_label_translate.Text; }
            set { size_label_translate.Text = value; }
        }
        public void Glossary_CMEnter(int row, DataGridView data)
        {
            int currow = row;
            this.Visible = true;
            this.size_label_word.Text = data[1, row].Value.ToString();
            this.size_label_reading.Text = data[2, row].Value.ToString();
            this.size_label_translate.Text = data[3, row].Value.ToString();
        }
        public void Glossary_CMLeave(int row)
        {
            this.Visible = false;
        }
    }
}
