using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiIocDemo;

/// <summary>
/// Sample view model demonstrating the use of the IocExtension.
/// </summary>
public partial class MainViewModel : ObservableObject
{
	/// <summary>
	/// Gets or sets the first name.
	/// </summary>
	[ObservableProperty, NotifyPropertyChangedFor(nameof(FullName))]
	public partial string FirstName { get; set; } = "John";

	/// <summary>
	/// Gets or sets the last name.
	/// </summary>
	[ObservableProperty, NotifyPropertyChangedFor(nameof(FullName))]
	public partial string LastName { get; set; } = "Doe";

	/// <summary>
	/// Gets the full name by combining first and last names.
	/// </summary>
	public string FullName => $"{FirstName} {LastName}";
}
