using Foundation;

namespace MauiIocDemo;

#pragma warning disable CS1591 // Suppress XML documentation warnings

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
