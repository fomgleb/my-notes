﻿using MyNotes.Views;

namespace MyNotes;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
