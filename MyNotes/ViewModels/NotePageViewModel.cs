using System.ComponentModel;
using MyNotes.Models;

namespace MyNotes.ViewModels
{
    public class NotePageViewModel : ViewModelBase
    {
        private const string NOTES_STORAGE_FILE_NAME = "notes.txt";

        private readonly string pathToStorageNotes = Path.Combine(FileSystem.AppDataDirectory, NOTES_STORAGE_FILE_NAME);

        public string EditorText { get => _editorText; set => Set(ref _editorText, value); }
        private string _editorText = string.Empty;

        public Command SaveNoteCommand { get; }
        public Command DeleteNoteCommand { get; }

        private readonly TxtFileStorage noteFileStorage;

        public NotePageViewModel()
        {
            noteFileStorage = new TxtFileStorage(pathToStorageNotes);

            #region Commands
            SaveNoteCommand = new Command(
                execute: () =>
                {
                    noteFileStorage.Save(EditorText);
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return noteFileStorage.Load() != EditorText;
                });

            DeleteNoteCommand = new Command(
                execute: () =>
                {
                    noteFileStorage.Save(string.Empty);
                    EditorText = string.Empty;
                    DeleteNoteCommand.ChangeCanExecute();
                },
                canExecute: () =>
                {
                    return noteFileStorage.Load() != string.Empty;
                });
            #endregion

            var loadedText = noteFileStorage.Load();
            EditorText = loadedText ?? string.Empty;

            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RefreshCanExecutes();
        }

        private void RefreshCanExecutes()
        {
            SaveNoteCommand.ChangeCanExecute();
            DeleteNoteCommand.ChangeCanExecute();
        }
    }
}
