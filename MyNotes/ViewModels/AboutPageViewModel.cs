using System.Windows.Input;

namespace MyNotes.ViewModels
{
    public class AboutPageViewModel : ViewModelBase
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string MoreInfoUrl => "https://aka.ms/maui";
        public string Message => "This app is written in XAML and C# with .NET MAUI.";

        public ICommand LearnMoreCommand { get; }

        public AboutPageViewModel()
        {
            LearnMoreCommand = new Command(
                execute: async () =>
                {
                    await Launcher.Default.OpenAsync(MoreInfoUrl);
                });
        }
    }
}
