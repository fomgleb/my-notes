using MyNotes.Models;
using System.ComponentModel;

namespace MyNotes.ViewModels
{
    [QueryProperty(nameof(EditingNote), nameof(EditingNote))]
    public class NotePageViewModel : ViewModelBase
    {
        public string EditorText { get => _editorText; set => Set(ref _editorText, value); }
        private string _editorText;

        public TextFile EditingNote { get => _editingNote; set => Set(ref _editingNote, value); }
        private TextFile _editingNote;

        public Command SaveNoteCommand { get; }
        public Command DeleteNoteCommand { get; }
        public Command UpdateEditorTextCommand { get; }
        public Command FocusOnEditorCommand { get; }

        public NotePageViewModel()
        {
            SaveNoteCommand = new Command(
                execute: async () =>
                {
                    EditingNote.Text = EditorText;
                    EditorText = string.Empty;
                    await Shell.Current.GoToAsync("..", true);
                },
                canExecute: () =>
                {
                    return EditorText != null && EditorText != EditingNote.Text;
                });

            DeleteNoteCommand = new Command(
                execute: async () =>
                {
                    EditingNote.Delete();
                    await Shell.Current.GoToAsync("..", true);
                });

            UpdateEditorTextCommand = new Command(
                execute: () =>
                {
                    EditorText = EditingNote.Text;
                });

            FocusOnEditorCommand = new Command(
                execute: async editor =>
                {
                    await Task.Delay(600);
                    ((Editor)editor).Focus();
                });

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
