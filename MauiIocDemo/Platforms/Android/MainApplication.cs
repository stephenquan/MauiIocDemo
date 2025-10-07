using Android.App;
using Android.Runtime;

namespace MauiIocDemo;

#pragma warning disable CS1591 // Suppress XML documentation warnings

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
