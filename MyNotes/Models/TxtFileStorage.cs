namespace MyNotes.Models
{
    public class TxtFileStorage
    {
        public string PathToStorage { get; }

        public TxtFileStorage(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path), "Path to storage file can't be null.");

            PathToStorage = path;
        }

        public void Save(string text)
        {
            File.WriteAllText(PathToStorage, text);
        }

        public string Load()
        {
            if (File.Exists(PathToStorage))
                return File.ReadAllText(PathToStorage);
            return null;
        }
    }
}
