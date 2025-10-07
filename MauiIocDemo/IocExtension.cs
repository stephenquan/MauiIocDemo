using SQuan.Helpers.Maui.Mvvm;

namespace MauiIocDemo;

/// <summary>
/// Simple markup extension to resolve services from the IoC container.
/// </summary>
[ContentProperty(nameof(Type))]
[RequireService([typeof(IReferenceProvider), typeof(IProvideValueTarget)])]
public partial class IocExtension : BindableObject, IMarkupExtension<BindingBase>
{
	/// <summary>
	/// Gets or sets the type of the service to resolve.
	/// </summary>
	[BindableProperty] public partial Type? Type { get; set; }

	/// <summary>
	/// Gets the resolved service instance.
	/// </summary>
	public object? InternalResult => (this.Type is Type t) ? IPlatformApplication.Current?.Services.GetService(t) : null;

	/// <summary>
	/// Initializes a new instance of the <see cref="IocExtension"/> class.
	/// </summary>
	public IocExtension()
	{
		this.PropertyChanged += (s, e) =>
		{
			switch (e.PropertyName)
			{
				case nameof(IocExtension.Type):
					OnPropertyChanged(nameof(InternalResult));
					break;
			}
		};
	}

	/// <summary>
	/// Implements the ProvideValue method to return the resolved service instance.
	/// </summary>
	/// <param name="serviceProvider"></param>
	/// <returns></returns>
	public object ProvideValue(IServiceProvider serviceProvider)
		=> (this as IMarkupExtension<BindingBase>).ProvideValue(serviceProvider);

	BindingBase IMarkupExtension<BindingBase>.ProvideValue(IServiceProvider serviceProvider)
	{
		if (serviceProvider.GetService(typeof(IProvideValueTarget)) is IProvideValueTarget provideValueTarget && provideValueTarget.TargetObject is BindableObject targetObject)
		{
			this.SetBinding(BindableObject.BindingContextProperty, static (BindableObject t) => t.BindingContext, BindingMode.OneWay, source: targetObject);
		}
		return BindingBase.Create(static (IocExtension t) => t.InternalResult, BindingMode.OneWay, source: this);
	}
}
