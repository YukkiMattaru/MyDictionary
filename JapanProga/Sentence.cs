using System.IO;

namespace JapanProga
{
    class Sentence
    {
        private Form1 Form1 { get; set; }
        public Sentence(Form1 f)
        {
            Form1 = f;
        }

        public void SentenceAdd(string sentence, string translate)
        {
            StreamWriter write = new StreamWriter(@"sentence.txt", true);
            write.WriteLine($"{sentence}\\{translate}");
            write.Close();
        }
        public void ReadAll()
        {
            try
            {
                Form1.Clear_Sentence_Grid();
                StreamReader read = new StreamReader(@"sentence.txt");
                string line = "";
                int number = 0;
                while((line = read.ReadLine()) != null)
                {
                    number++;
                    string sentence = "", translate = "";
                    int count = 0;
                    foreach(char ch in line)
                    {
                        if(ch == '\\') { count++; continue; }
                        switch (count)
                        {
                            case 0:
                                {
                                    sentence += ch;
                                    break;
                                }
                            case 1:
                                {
                                    translate += ch;
                                    break;
                                }
                        }
                    }
                    string number_str = number.ToString();
                    Form1.Add_To_Sentence_Grid(number_str, sentence, translate);
                }
                read.Close();
            }
            catch (System.IO.FileNotFoundException)
            {
                StreamWriter write = new StreamWriter(@"sentence.txt");
                write.Close();
            }
        }
        public void SentenceDel(int curcount)
        {
            StreamWriter write = new StreamWriter(@"temp.txt");
            StreamReader read = new StreamReader(@"sentence.txt");
            string line = "";
            int count = 0;
            while((line = read.ReadLine()) != null)
            {
                count++;
                if(count != curcount)
                {
                    write.WriteLine(line);
                }
            }
            write.Close(); read.Close();
            StreamWriter write_2 = new StreamWriter(@"sentence.txt");
            StreamReader read_2 = new StreamReader(@"temp.txt");
            while((line = read_2.ReadLine()) != null)
            {
                write_2.WriteLine(line);
            }
            write_2.Close(); read_2.Close();
            ReadAll();
        }
    }
}
