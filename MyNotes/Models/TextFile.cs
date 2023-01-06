namespace MyNotes.Models
{
    public class TextFile
    {
        public string PathToFile { get; }
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                File.WriteAllText(PathToFile, value);
            }
        }
        private string _text;

        public TextFile(string pathToFile, string text)
        {
            PathToFile = pathToFile;
            Text = text;
        }

        public TextFile(string pathToFile)
        {
            PathToFile = pathToFile;
            if (File.Exists(pathToFile))
                _text = File.ReadAllText(pathToFile);
            else
                Text = string.Empty;
        }

        public void Delete()
        {
            File.Delete(PathToFile);
        }
    }
}
