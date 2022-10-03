using Microsoft.Maui.Controls.Platform;
using PassBox.Mobile.ViewModels;

namespace PassBox.Mobile.Views;

public partial class PasswordInfoListPage : ContentPage
{
	public PasswordInfoListPage()
	{
		InitializeComponent();
	}

	/*protected override void OnAppearing()
	{
		base.OnAppearing();
		var viewModel = BindingContext as PasswordInfoListViewModel;
		viewModel?.OnAppearing();
    }*/
}