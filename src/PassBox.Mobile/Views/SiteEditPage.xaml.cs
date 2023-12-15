using PassBox.Mobile.ViewModels;

namespace PassBox.Mobile.Views;

public partial class SiteEditPage : ContentPage
{
	public const string Location = "//SiteEditPage";

    public SiteEditPage(SiteEditViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}