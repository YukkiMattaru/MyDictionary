using System.IO;

namespace JapanProga
{
    class Glossary
    {
        private Form1 Form1 { get; set; }
        public Glossary(Form1 f)
        {
            Form1 = f;
        }

        bool isRewrite = false;
        public void addWord(string word, string reading, string translate)
        {
            for (int i = 0; i < Form1._dataGridGlossary_Length(); i++)
            {
                if (word == Form1._dataGridGlossary(1, i))
                {
                    Form1.Msg("Это слово уже есть в словаре");
                    isRewrite = true;
                }
            }
            if (!isRewrite)
            {
                StreamWriter write = new StreamWriter(@"glossary.txt", true);
                string number_str = (Form1._dataGridGlossary_Length()+1).ToString();
                write.WriteLine($"{word}\\{reading}\\{translate}");
                write.Close();
                Form1.Add_To_Glossary_Grid(number_str, word, reading, translate);
            }
        }
        public void showAll()
        {
            try
            {
                Form1.Clear_Glossary_Grid();
                StreamReader read = new StreamReader(@"glossary.txt");
                string line;
                int number = 0;
                while ((line = read.ReadLine()) != null)
                {
                    number++;
                    string word = "", reading = "", translate = "";
                    int count = 0;
                    foreach (char ch in line)
                    {
                        if (ch == '\\') { count++; continue; }
                        switch (count)
                        {
                            case 0: { word += ch; break; }
                            case 1: { reading += ch; break; }
                            case 2: { translate += ch; break; }
                        }
                    }
                    string number_str = number.ToString();
                    Form1.Add_To_Glossary_Grid(number_str, word, reading, translate);
                }
                read.Close();
            }
            catch (System.IO.FileNotFoundException)
            {
                StreamWriter write = new StreamWriter(@"glossary.txt");
                write.Close();
            }
        }
        /*public void showAll()
        {
            try
            {
                Form1.Clear_Glossary_Grid();
                StreamReader read = new StreamReader(@"glossary.txt");
                string line;
                //int number = 0;
                while ((line = read.ReadLine()) != null)
                {
                    //number++;5
                    string number_str = "", word = "", reading = "", translate = "";
                    int count = 0;
                    foreach (char ch in line)
                    {
                        if (ch == '\\') { count++; continue; }
                        switch (count)
                        {
                            case 0: { number_str += ch; break; }
                            case 1: { word += ch; break; }
                            case 2: { reading += ch; break; }
                            case 3: { translate += ch; break; }
                        }
                    }
                    //string number_str = number.ToString();
                    Form1.Add_To_Glossary_Grid(number_str, word, reading, translate);
                }
                read.Close();
            }
            catch (System.IO.FileNotFoundException)
            {
                StreamWriter write = new StreamWriter(@"glossary.txt");
                write.Close();
            }
        }*/
        public void ClearGlossaryFile(string path)
        {
            try
            {
                File.Delete(@path);
                StreamWriter write = new StreamWriter(@path);
                write.Close();
                Form1.Clear_Glossary_Grid();
            }
            catch (System.IO.FileNotFoundException) { StreamWriter write = new StreamWriter(@path); write.Close(); }
        }
        public void delWord(int curcount)
        {
            StreamWriter write = new StreamWriter(@"temp.txt");
            StreamReader read = new StreamReader(@"glossary.txt");
            string line = "";
            int count = -1;
            while ((line = read.ReadLine()) != null)
            {
                count++;
                if (count != curcount)
                {
                    write.WriteLine(line);
                }
            }
            write.Close(); read.Close();
            StreamWriter write_2 = new StreamWriter(@"glossary.txt");
            StreamReader read_2 = new StreamReader(@"temp.txt");
            while ((line = read_2.ReadLine()) != null)
            {
                write_2.WriteLine(line);
            }
            write_2.Close(); read_2.Close();
        }
        public int Search(string _Text, int row)
        {
            for (int i = 0; i < Form1._dataGridGlossary_Length(); i++)
            {
                if (_Text == Form1._dataGridGlossary(row, i))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
