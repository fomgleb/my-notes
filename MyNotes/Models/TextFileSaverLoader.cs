namespace MyNotes.Models
{
    public class TextFilesSaverLoader
    {
        private readonly string _pathToFolder;
        private readonly string _endOfFilename;

        public TextFilesSaverLoader(string pathToFolder, string endOfFilename)
        {
            _pathToFolder = pathToFolder;
            _endOfFilename = endOfFilename;
        }

        public TextFile CreateFile(string text)
        {
            var pathToNewFile = Path.Combine(_pathToFolder, Path.GetRandomFileName() + _endOfFilename);
            return new TextFile(pathToNewFile, text);
        }

        public IEnumerable<TextFile> Load()
        {
            var notesEnumerable = Directory
                .EnumerateFiles(_pathToFolder, "*" + _endOfFilename)
                .Select(pathToFile => new TextFile(pathToFile))
                .OrderBy(textFile => File.GetCreationTime(textFile.PathToFile))
                .Reverse();
            return notesEnumerable;
        }
    }
}
