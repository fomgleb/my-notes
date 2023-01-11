namespace MyNotes.ViewModels;

public partial class AllNotesPageViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<TextFile> notesCollection;

    private readonly TextFilesSaverLoader _notesSaverLoader = new(FileSystem.AppDataDirectory, ".notes.txt");

    public AllNotesPageViewModel()
    {
        NotesCollection = new ObservableCollection<TextFile>(_notesSaverLoader.Load());

        Shell.Current.Navigating += OnNavigating;
    }

    [RelayCommand] private async void AddNewNote()
    {
        await Shell.Current.GoToAsync(nameof(NotePage), new Dictionary<string, object>
        {
            { nameof(NotePageViewModel.EditingNote), _notesSaverLoader.CreateFile(string.Empty) }
        });
    }

    [RelayCommand] private async void EditNote(object selectedNote)
    {
        if (selectedNote == null) return;
        await Shell.Current.GoToAsync(nameof(NotePage), new Dictionary<string, object>
        {
            { nameof(NotePageViewModel.EditingNote), selectedNote }
        });
    }

    private void OnNavigating(object sender, ShellNavigatingEventArgs e)
    {
        if (e.Target.Location.OriginalString == "..")
        {
            NotesCollection = new ObservableCollection<TextFile>(_notesSaverLoader.Load());
        }
    }
}
