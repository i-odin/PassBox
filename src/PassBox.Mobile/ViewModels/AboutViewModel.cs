using CommunityToolkit.Mvvm.ComponentModel;

namespace PassBox.Mobile.ViewModels
{
    internal partial class AboutViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _path = FileSystem.Current.AppDataDirectory;
    }
}
