using PassBox.Mobile.ViewModels;

namespace PassBox.Mobile
{
    public partial class AppShell : Shell
    {
        //public AppShell()
        public AppShell(AppShellViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
