namespace MauiWheater;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.DailyForecastPage), typeof(Views.DailyForecastPage));
    }
}
