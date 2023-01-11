namespace MyNotes.ViewModels;

[QueryProperty(nameof(EditingNote), nameof(EditingNote))]
public partial class NotePageViewModel : ObservableObject
{
    [ObservableProperty] private string editorText = string.Empty;
    [ObservableProperty] private TextFile editingNote;
    [ObservableProperty] private bool editorTextIsEmpty;

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        EditorTextIsEmpty = editorText == string.Empty;
    }

    [RelayCommand] private async void SaveNote()
    {
        EditingNote.Text = EditorText;
        await Shell.Current.GoToAsync("..", true);
    }

    [RelayCommand] private async void DeleteNote()
    {
        EditingNote.Delete();
        await Shell.Current.GoToAsync("..", true);
    }

    [RelayCommand] private void UpdateEditorText()
    {
        EditorText = EditingNote.Text;
    }

    [RelayCommand] private async void OnBackButtonClicked()
    {
        if (EditingNote.Text == string.Empty)
            EditingNote.Delete();
        await Shell.Current.GoToAsync("..", true);
    }
}
