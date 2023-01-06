using MyNotes.Views;

namespace MyNotes;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(NotePage), typeof(NotePage));
		Routing.RegisterRoute(nameof(AllNotesPage), typeof(AllNotesPage));
		MainPage = new AppShell();
	}
}
