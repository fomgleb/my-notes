namespace MyNotes.ViewModels
{
    public class AboutPageViewModel : ViewModelBase
    {
        private const string ABOUT_MAUI_LINK = "https://aka.ms/maui";
        private const string APP_ON_GITHUB_LINK = "https://github.com/fomgleb/my-notes";

        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;

        public Command OpenWebsiteAboutMaui { get; }
        public Command OpenWebsiteAppOnGithub { get; }

        public AboutPageViewModel()
        {
            OpenWebsiteAboutMaui = new Command(
                execute: async () =>
                {
                    await Launcher.Default.OpenAsync(ABOUT_MAUI_LINK);
                });

            OpenWebsiteAppOnGithub = new Command(
                execute: async () =>
                {
                    await Launcher.Default.OpenAsync(APP_ON_GITHUB_LINK);
                });
        }
    }
}
