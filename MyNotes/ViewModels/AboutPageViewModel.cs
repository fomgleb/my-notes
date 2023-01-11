namespace MyNotes.ViewModels;

public partial class AboutPageViewModel : ObservableObject
{
    public string Title => AppInfo.Name;
    public string Version => AppInfo.VersionString;

    [RelayCommand] private static async void OpenWebsiteAsync(string url)
    {
        await Launcher.Default.OpenAsync(url);
    }
}
