using PassBox.Mobile.ViewModels;

namespace PassBox.Mobile.Views;

public partial class SiteEditPage : ContentPage
{
	public SiteEditPage(SiteEditViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}