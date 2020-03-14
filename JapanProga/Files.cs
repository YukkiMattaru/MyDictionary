namespace JapanProga
{
    class Files
    {
        public string name { get; set; }
        public string text { get; set; }
        public Files(string _name, string _text)
        {
            this.name = _name.ToString();
            this.text = _text.ToString();
        }

        public Files(string _text)
        {
            this.text = _text.ToString();
        }

        public override string ToString() { return this.name; }
    }
}
