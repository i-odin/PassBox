using PassBox.Mobile.ViewModels;

namespace PassBox.Mobile.Views;

public partial class SiteViewPage : ContentPage
{
	public const string Location = "//SiteViewPage";

    public SiteViewPage(SiteViewModel viewModel)
    {
		InitializeComponent();

		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        (BindingContext as SiteViewModel)?.Load();
    }
}