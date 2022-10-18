using PassBox.Mobile.ViewModels;

namespace PassBox.Mobile.Views;

public partial class PasswordInfoAddUpdatePage : ContentPage
{
	public PasswordInfoAddUpdatePage(PasswordInfoAddUpdateViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}