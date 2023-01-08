using MyNotes.Models;
using MyNotes.Views;
using System.Collections.ObjectModel;

namespace MyNotes.ViewModels
{
    public class AllNotesPageViewModel : ViewModelBase
    {
        public ObservableCollection<TextFile> NotesCollection { get => _notesCollection; set => Set(ref _notesCollection, value); }
        private ObservableCollection<TextFile> _notesCollection;

        private readonly TextFilesSaverLoader _notesSaverLoader = new(FileSystem.AppDataDirectory, ".notes.txt");

        public Command AddNewNoteCommand { get; }
        public Command EditNoteCommand { get; }

        public AllNotesPageViewModel()
        {
            NotesCollection = new ObservableCollection<TextFile>(_notesSaverLoader.Load());

            AddNewNoteCommand = new Command(
                execute: async () =>
                {
                    var navigationParameter = new Dictionary<string, object>
                    {
                        { nameof(NotePageViewModel.EditingNote), _notesSaverLoader.CreateFile(string.Empty) }
                    };
                    await Shell.Current.GoToAsync(nameof(NotePage), navigationParameter);
                });

            EditNoteCommand = new Command(
                execute: async selectedNote =>
                {
                    if (selectedNote == null) return;
                    var navigationParameter = new Dictionary<string, object>
                    {
                        { nameof(NotePageViewModel.EditingNote), selectedNote }
                    };
                    await Shell.Current.GoToAsync(nameof(NotePage), navigationParameter);
                });

            Shell.Current.Navigating += OnNavigating;
        }

        private void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            if (e.Target.Location.OriginalString == "..")
            {
                NotesCollection = new ObservableCollection<TextFile>(_notesSaverLoader.Load());
            }
        }
    }
}
