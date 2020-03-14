using System;

namespace JapanProga
{
    class Anki
    {
        private Form1 Form1 { get; set; }

        public Anki(Form1 f)
        {
            Form1 = f;
        }

        public int Generate_Random_Number(int max_value)
        {
            Random rand = new Random();
            return rand.Next(0, max_value);
        }
    }
}
