using System.IO;

namespace JapanProga
{
    class Text
    {
        private Form1 Form1 { get; set; }
        public Text(Form1 f)
        {
            Form1 = f;
        }
        public void Add_Text(AddText at)
        {
            string text_name = at.Text_Add_Name.Text, japan_text = at.Text_Add_Japan.Text, translate_text = at.Text_Add_Translate.Text;
            StreamWriter write = new StreamWriter($@"texts\{text_name}.txt", true);
            string japan_text_in_file = "", translate_text_in_file = "";
            foreach (char ch in japan_text)
            {
                japan_text_in_file += ch;
                if (ch == '.' || ch == '。' || ch == '!' || ch == '！' || ch == '?' || ch == '？') 
                {
                    japan_text_in_file += '\\';
                }
            }
            if(japan_text_in_file[japan_text_in_file.Length-1] != '\\') { japan_text_in_file += '\\'; }
            write.WriteLine(japan_text_in_file);
            write.WriteLine("+");
            foreach (char ch in translate_text)
            {
                translate_text_in_file += ch;
                if (ch == '.' || ch == '!' || ch == '?')
                {
                    translate_text_in_file += '\\';
                }
            }
            if(translate_text_in_file[translate_text_in_file.Length-1] != '\\') { translate_text_in_file += '\\'; }
            write.WriteLine(translate_text_in_file);
            write.Close();
            Load_Collection();
        }
        public void Delete_Text(string path)
        {
            File.Delete(@path);
            Load_Collection();
            Form1._Text_Japanese = "";
            Form1._Text_Russian = "";
        }
        public void Load_Collection()
        {
            Form1.Clear_T_Manager();
            var file = Directory.Exists(@"texts");
            if (file == false)
            {
                Directory.CreateDirectory(@"texts");
            }
            else
            {
                string[] files = Directory.GetFiles(@"texts");
                for (int i = 0; i < files.Length; i++)
                {
                    Form1._Text_Manager_Set(new Files(files[i], files[i]));
                }
            }
        }
    }
}
