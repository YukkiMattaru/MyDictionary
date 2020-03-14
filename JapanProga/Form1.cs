using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace JapanProga
{
    public partial class Form1 : Form
    {
        #region form
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FormSize szfm = new FormSize(this);
            Text text = new Text(this);
            Glossary gloss = new Glossary(this);
            Anki anki = new Anki(this);
            Sentence sentence = new Sentence(this);
            text.Load_Collection();
            gloss.showAll();
            sentence.ReadAll();
            if (Text_Sent_Sentence.Text.Length == 0)
            {
                Button_Sent_Add.Enabled = false;
            }
            else { Button_Sent_Add.Enabled = true; }
            if (Text_Sent_Translate.Text.Length == 0)
            {
                Button_Sent_Add.Enabled = false;
            }
            else { Button_Sent_Add.Enabled = false; }
            if (Text_Japanese.Text == "")
            {
                Button_Anki_Text_Start.Enabled = false;
                Text_Anki_Text_Russian_Sentence.Text = "Выберите текст во вкладке \"Текст\"";
            }
            if (dataGrid_Sentence.RowCount <= 1)
            {
                Button_Anki_Sentence_New.Enabled = false;
                Text_Anki_Russian_Sentence.Text = "Заполните хотя бы одну ячейку во вкладке \"Предложения\"";
            }
            else
            {
                Button_Anki_Sentence_New.Enabled = true;
                Text_Anki_Russian_Sentence.Text = "Нажмите кнопку \"Новое предложение\"";
            }
            if (dataGrid_Glossary.RowCount <= 1)
            {
                Button_Anki_New.Enabled = false;
                label_Anki.Text = "Заполните хотя бы одну ячейку во вкладке \"Словарь\"";
            }
            else
            {
                Button_Anki_New.Enabled = true;
                label_Anki.Text = "Нажмите кнопку \"Новое слово\"";
            }
            //typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dataGrid_Glossary, true, null);
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region text_manager
        public string _Text_Manager(int value)
        {
            return T_Manager.Items[value].ToString();
        }
        public void _Text_Manager_Set(object obj)
        {
            T_Manager.Items.Add(obj);
        }
        public void Clear_T_Manager()
        {
            T_Manager.Items.Clear();
        }
        #endregion
        #region get and set
        public string _dataGridGlossary(int column, int row)
        {
            return dataGrid_Glossary[column, row].Value.ToString();
        }
        public int _dataGridGlossary_Length()
        {
            return dataGrid_Glossary.RowCount - 1;
        }
        public string _Text_Japanese
        {
            get { return Text_Japanese.Text; }
            set { Text_Japanese.Text = value; }
        }
        public string _Text_Russian
        {
            get { return Text_Russian.Text; }
            set { Text_Russian.Text = value; }
        }
        public void Msg(string path)
        {
            MessageBox.Show(path);
        }
        public string Glossary_Cell_Value(int col, int row)
        {
                return dataGrid_Glossary[col, row].Value.ToString();
        }
        #endregion
        #region glossary
        FormSize szform = new FormSize();
        private void dataGrid_Glossary_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) // отвечает за отображение кнопок в "запоминании"
        {
            if (dataGrid_Glossary.RowCount > 1)
            {
                Button_Anki_New.Enabled = true;
                label_Anki.Text = "Нажмите кнопку \"Новое слово\"";
            }
            else
            {
                Text_Anki.ReadOnly = true;
                Button_Anki_New.Enabled = false;
                label_Anki.Text = "Заполните хотя бы одну ячейку во вкладке \"Словарь\"";
            }
        }
        private void dataGrid_Glossary_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGrid_Glossary.RowCount > 1)
            {
                Button_Anki_New.Enabled = true;
                label_Anki.Text = "Нажмите кнопку \"Новое слово\"";
            }
            else
            {
                Text_Anki.ReadOnly = true;
                Button_Anki_New.Enabled = false;
                label_Anki.Text = "Заполните хотя бы одну ячейку во вкладке \"Словарь\"";
            }
        }
        private void dataGrid_Glossary_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 & e.RowIndex != dataGrid_Glossary.Rows.Count - 1)
            {
                szform.Glossary_CMEnter(e.RowIndex, dataGrid_Glossary);
            }
        }
        private void dataGrid_Glossary_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            szform.Glossary_CMLeave(e.RowIndex);
        }
        private void tabControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (Text_Glossary_Kanji.Text != "" && Text_Glossary_Result.Text != "")
                {
                    Button_Glossary_Add_Click(this, e);
                }
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                if (Text_Glossary_Kanji.Text != "" || Text_Glossary_Result.Text != "" || Text_Glossary_Yomikata.Text != "")
                {
                    Button_Glossary_Search_Click(this, e);
                }
            }
        } // горячие клавиши

        public void Add_To_Glossary_Grid(string number, string word, string reading, string translate)
        {
            dataGrid_Glossary.Rows.Add(number, word, reading, translate);
        } // добавляет новую строку в таблицу и перезагружает ее
        public void Delete_From_Glossary_Grid(int row)
        {
            dataGrid_Glossary.Rows.RemoveAt(row);
        } // удаляет строку таблицы и перезагружает ее
        public void Clear_Glossary_Grid()
        {
            dataGrid_Glossary.Rows.Clear();
        } // очищает таблицу и перезагружает ее 

        private void Button_Glossary_Add_Click(object sender, EventArgs e) // добавляет новое слово в словарь и в таблицу
        {
            if (Text_Glossary_Kanji.Text != "" && Text_Glossary_Result.Text != "")
            {
                Glossary gloss = new Glossary(this);
                gloss.addWord(Text_Glossary_Kanji.Text, Text_Glossary_Yomikata.Text, Text_Glossary_Result.Text);
                Text_Glossary_Kanji.Text = ""; Text_Glossary_Yomikata.Text = ""; Text_Glossary_Result.Text = "";
            }
            else { Msg("Введите значение в \"Иностранное слово\" и в \"Перевод\"."); }
        }
        private void Button_Glossary_Delete_Click(object sender, EventArgs e)
        {
            if (dataGrid_Glossary.Rows.Count > 1 && dataGrid_Glossary.CurrentCell.RowIndex != dataGrid_Glossary.Rows.Count-1)
            {
                Glossary gloss = new Glossary(this);
                int curcount = dataGrid_Glossary.CurrentCell.RowIndex;
                gloss.delWord(curcount);
                gloss.showAll();
            }
        } // удаляет слово из словаря
        private void Button_Clear_Glossary_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            Form2 dial = new Form2();
            dr = dial.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Glossary glos = new Glossary(this);
                glos.ClearGlossaryFile("glossary.txt");
            }
        } // очищает файл словаря
        private void Search_OutPut(string _word, int _word_col, int _col_out_1, int _col_out_2)
        {
            Glossary glos = new Glossary(this);
            int index = glos.Search(_word, _word_col);
            if (index != -1)
            {
                dataGrid_Glossary[_word_col, index].Selected = true;
                MessageBox.Show($"{dataGrid_Glossary[_col_out_1, index].Value.ToString()} | {dataGrid_Glossary[_col_out_2, index].Value.ToString()}", $"Результат по {_word}");
                return;
            }
            else
            {
                MessageBox.Show("Результатов не найдено", $"Результат по {_word}");
                return;
            }
        } // ищет исходное слово в словаре
        private void Button_Glossary_Search_Click(object sender, EventArgs e) // событие нажатия кнопки "Поиск по словарю"
        {
            if (Text_Glossary_Kanji.Text.Length != 0)
            {
                Search_OutPut(Text_Glossary_Kanji.Text, 1, 2, 3);
                return;
            }
            else if (Text_Glossary_Result.Text.Length != 0)
            {
                Search_OutPut(Text_Glossary_Result.Text, 3, 1, 2);
                return;
            }
            else if (Text_Glossary_Yomikata.Text.Length != 0)
            {
                Search_OutPut(Text_Glossary_Yomikata.Text, 2, 1, 3);
                return;
            }
            else
            {
                MessageBox.Show("Введите запрос в любое из трех полей", "Пустой запрос");
            }
        }
      
        private void Button_Export_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application Exl = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wb;
                XlReferenceStyle RefStyle = Exl.ReferenceStyle;
                Exl.Visible = false;
                wb = Exl.Workbooks.Add(Type.Missing);
                Worksheet ws = wb.Worksheets.get_Item(1) as Worksheet;
                for (int j = 0; j < dataGrid_Glossary.Columns.Count; ++j)
                {
                    for (int i = 0; i < dataGrid_Glossary.Rows.Count; ++i)
                    {
                        object Val = dataGrid_Glossary.Rows[i].Cells[j].Value;
                        if (Val != null)
                            (ws.Cells[i + 2, j + 1] as Range).Value2 = Val.ToString();
                    }
                }
                ws.Columns.EntireColumn.AutoFit();
                Exl.ReferenceStyle = RefStyle;        
                Exl.Application.ActiveWorkbook.SaveAs("glossary.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Exl.Quit();
            }
            catch (ExternalException a)
            {
                Debug.WriteLine(a.Message);
            }
        }
        #endregion
        #region anki
        #region anki_glossary       
        private void Text_Anki_TextChanged(object sender, EventArgs e)
        {
            string current_word = dataGrid_Glossary[3, Convert.ToInt16(Text_Anki_Glossary_ID.Text)].Value.ToString();
            if (Text_Anki.Text.Length > current_word.Length) { Label_anki_help.Text = "Превышен размер исходного слова."; }
            else if (Text_Anki.Text == current_word) { Button_Anki_New_Click(sender, e); }
            else if (Text_Anki.Text.Length <= current_word.Length)
            {
                for (int i = 0; i < Text_Anki.Text.Length; i++) {
                    if (Text_Anki.Text[i] != current_word[i]) {
                        Label_anki_help.Text = $"Вместо символа {Text_Anki.Text[i]} нужно использовать {current_word[i]}";
                        break;
                    }
                    else { Label_anki_help.Text = "Пока все правильно. Строка активна."; }
                }
            }
        }

        private void Button_Anki_New_Click(object sender, EventArgs e)
        {
            Anki anki = new Anki(this);
            int word_id = anki.Generate_Random_Number(dataGrid_Glossary.RowCount - 1);
            Text_Anki.Text = "";
            label_Anki.Text = dataGrid_Glossary[1, word_id].Value.ToString() + 
                " (" + dataGrid_Glossary[2, word_id].Value.ToString() + ")";
            Text_Anki_Glossary_ID.Text = word_id.ToString();
            Text_Anki.ReadOnly = false;
        }

        #endregion anki_glossary
        #region anki_sentence
        private void Button_Anki_Sentence_New_Click(object sender, EventArgs e)
        {
            Text_Anki_Japanese_Sentence.ReadOnly = false;
            Text_Anki_Sentence_Mistake.Text = "Пока все правильно. Строка активна.";
            Text_Anki_Japanese_Sentence.Text = "";
            Anki anki = new Anki(this);
            int max_value = dataGrid_Sentence.RowCount - 1;
            int sentence_id = anki.Generate_Random_Number(max_value);
            if (Text_Anki_Sentence_Number.Text != "" && dataGrid_Sentence.RowCount > 2)
            {
                while (sentence_id == Convert.ToInt16(Text_Anki_Sentence_Number.Text))
                {
                    sentence_id = anki.Generate_Random_Number(max_value);
                }
            }
            Text_Anki_Russian_Sentence.Text = dataGrid_Sentence[2, sentence_id].Value.ToString();
            Text_Anki_Sentence_Number.Text = (sentence_id).ToString();
        }
        private void Text_Anki_Japanese_Sentence_TextChanged(object sender, EventArgs e)
        {
            string current_japanese_sentence = dataGrid_Sentence[1, Convert.ToInt16(Text_Anki_Sentence_Number.Text)].Value.ToString();
            if (Text_Anki_Japanese_Sentence.Text.Length > current_japanese_sentence.Length)
            {
                Text_Anki_Sentence_Mistake.Text = "Превышен размер исходной фразы.";
            }
            else if (Text_Anki_Japanese_Sentence.Text == current_japanese_sentence) { Button_Anki_Sentence_New_Click(sender, e); }
            else if (Text_Anki_Japanese_Sentence.Text.Length <= current_japanese_sentence.Length)
            {
                for (int i = 0; i < Text_Anki_Japanese_Sentence.Text.Length; i++)
                {
                    if (Text_Anki_Japanese_Sentence.Text[i] != current_japanese_sentence[i])
                    {
                        Text_Anki_Sentence_Mistake.Text = $"Вместо символа {Text_Anki_Japanese_Sentence.Text[i]} нужно использовать {current_japanese_sentence[i]}";
                        break;
                    }
                    else
                    {
                        Text_Anki_Sentence_Mistake.Text = "Пока все правильно. Строка активна.";
                    }
                }
            }
        }
        #endregion anki_sentence
        #region anki_text
        private void Button_Anki_Text_Start_Click(object sender, EventArgs e)
        {
            dataGrid_Anki_Japanese.Rows.Clear();
            dataGrid_Anki_Russian.Rows.Clear();
            string temp = "";
            foreach (char ch in Text_Japanese.Text)
            {
                if (ch == '\\')
                {
                    dataGrid_Anki_Japanese.Rows.Add(temp);
                    temp = "";
                    continue;
                }
                temp += ch;
            }
            foreach (char ch in Text_Russian.Text)
            {
                if (ch == '\\')
                {
                    dataGrid_Anki_Russian.Rows.Add(temp);
                    temp = "";
                    continue;
                }
                temp += ch;
            }
            if (dataGrid_Anki_Japanese.RowCount == dataGrid_Anki_Russian.RowCount && dataGrid_Anki_Japanese.RowCount > 1 && dataGrid_Anki_Russian.RowCount > 1)
            {
                Text_Anki_Text_Russian_Sentence.Text = dataGrid_Anki_Russian[0, 0].Value.ToString();
                Text_Anki_Text_Text.ReadOnly = false;
                Text_Anki_Text_CurID.Text = "0";
            }
            else
            {
                Text_Anki_Text_Text.ReadOnly = true;
                MessageBox.Show("Количество предложений в иностранном тексте не совпадают с количеством предложений в тексте перевода, либо предложений нет вовсе.", "Неверный формат текста");
            }
        }
        private void Text_Anki_Text_Text_TextChanged(object sender, EventArgs e)
        {
            string current_japanese_sentence = dataGrid_Anki_Japanese[0, Convert.ToInt16(Text_Anki_Text_CurID.Text)].Value.ToString();
            if (Text_Anki_Text_Text.Text.Length > current_japanese_sentence.Length)
            {
                Text_Anki_Text_Mistake.Text = "Превышен размер исходной фразы.";
            }
            else if (Text_Anki_Text_Text.Text == current_japanese_sentence)
            {
                Text_Anki_Text_CurID.Text = (Convert.ToInt16(Text_Anki_Text_CurID.Text) + 1).ToString();
                if (Convert.ToInt16(Text_Anki_Text_CurID.Text) >= dataGrid_Anki_Japanese.RowCount - 1)
                {
                    Text_Anki_Text_CurID.Text = "0";
                    Text_Anki_Text_Russian_Sentence.Text = "Поздравляем! Это было последнее предложение в тексте.";
                    Text_Anki_Text_Text.Text = "";
                }
                else
                {
                    Text_Anki_Text_Russian_Sentence.Text = dataGrid_Anki_Russian[0, Convert.ToInt16(Text_Anki_Text_CurID.Text)].Value.ToString();
                    Text_Anki_Text_Text.Text = "";
                }
            }
            else if (Text_Anki_Text_Text.Text.Length <= current_japanese_sentence.Length)
            {
                for (int i = 0; i < Text_Anki_Text_Text.Text.Length; i++)
                {
                    if (Text_Anki_Text_Text.Text[i] != current_japanese_sentence[i])
                    {
                        Text_Anki_Text_Mistake.Text = $"Вместо символа {Text_Anki_Text_Text.Text[i]} нужно использовать {current_japanese_sentence[i]}";
                        break;
                    }
                    else
                    {
                        Text_Anki_Text_Mistake.Text = "Пока все правильно. Строка активна.";
                    }
                }
            }
        }
        #endregion anki_text
        #endregion anki
        #region sentence
        private void dataGrid_Sentence_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGrid_Sentence.RowCount > 1)
            {
                Button_Anki_Sentence_New.Enabled = true;
                Text_Anki_Russian_Sentence.Text = "Нажмите кнопку \"Новое предложение\"";
            }
            else
            {
                Button_Anki_Sentence_New.Enabled = false;
                Text_Anki_Russian_Sentence.Text = "Заполните хотя бы одну ячейку во вкладке \"Предложение\"";
                Text_Anki_Japanese_Sentence.ReadOnly = true;
            }
        }
        private void dataGrid_Sentence_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGrid_Sentence.RowCount > 1)
            {
                Button_Anki_Sentence_New.Enabled = true;
                Text_Anki_Russian_Sentence.Text = "Нажмите кнопку \"Новое предложение\"";
            }
            else
            {
                Button_Anki_Sentence_New.Enabled = false;
                Text_Anki_Russian_Sentence.Text = "Заполните хотя бы одну ячейку во вкладке \"Предложение\"";
                Text_Anki_Japanese_Sentence.ReadOnly = true;
            }
        }
        public void Clear_Sentence_Grid()
        {
            dataGrid_Sentence.Rows.Clear();
            dataGrid_Sentence.Refresh();
        }
        public void Add_To_Sentence_Grid(string number, string sentence, string translate)
        {
            dataGrid_Sentence.Rows.Add(number, sentence, translate);
            Text_Sent_Sentence.Text = "";
            Text_Sent_Translate.Text = "";
        }
        private void Button_Sent_Add_Click(object sender, EventArgs e)
        {
            Sentence sentence = new Sentence(this);
            sentence.SentenceAdd(Text_Sent_Sentence.Text, Text_Sent_Translate.Text);
            sentence.ReadAll();
        }
        private void Button_Sent_Del_Click(object sender, EventArgs e)
        {
            try
            {
                int curcount = Convert.ToInt16(dataGrid_Sentence[0, dataGrid_Sentence.CurrentCell.RowIndex].Value);

                Sentence sentence = new Sentence(this);
                sentence.SentenceDel(curcount);
            }
            catch (System.NullReferenceException)
            {
                Msg("Словарь пуст");
            }
        }
        private void Check()
        {
            if (Text_Sent_Sentence.Text.Length == 0 || Text_Sent_Translate.Text.Length == 0)
            {
                Button_Sent_Add.Enabled = false;
            }
            else
            {
                Button_Sent_Add.Enabled = true;
            }
        }

        private void Text_Sent_Sentence_TextChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void Text_Sent_Translate_TextChanged(object sender, EventArgs e)
        {
            Check();
        }
        #endregion
        #region text
        private void Button_Text_Add_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            AddText at = new AddText();
            at.Owner = this;
            dr = at.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Text text = new Text(this);
                text.Add_Text(at);
            }
        }
        private void Button_Text_Del_Click(object sender, EventArgs e)
        {
            string filename = T_Manager.GetItemText(T_Manager.Items[T_Manager.SelectedIndex]);
            DialogResult dr = new DialogResult();
            Form2 dial = new Form2();
            dr = dial.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Text text = new Text(this);
                text.Delete_Text(filename);
            }
        }
        private void T_Manager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (T_Manager.SelectedIndex != -1)
            {
                bool isPlus = false;
                Text_Japanese.Text = ""; Text_Russian.Text = "";
                string filename = T_Manager.GetItemText(T_Manager.Items[T_Manager.SelectedIndex]);
                StreamReader read = new StreamReader(@filename);
                string line = "";
                while ((line = read.ReadLine()) != null)
                {
                    if (line == "+")
                    {
                        if ((line = read.ReadLine()) != null)
                        {
                            isPlus = true;
                        }
                    }
                    if (!isPlus)
                    {
                        Text_Japanese.Text += line;
                    }
                    else { Text_Russian.Text += line; }
                }
                read.Close();
                Button_Anki_Text_Start.Enabled = true;
                Text_Anki_Text_Russian_Sentence.Text = "Вы выбрали текст: " + filename + "." + Environment.NewLine + "Нажмите НАЧАТЬ для старта.";
            }
        }
        #endregion
    }
}
