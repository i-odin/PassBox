using CommunityToolkit.Mvvm.ComponentModel;
using PassBox.Mobile.ViewModels.Base;

namespace PassBox.Mobile.ViewModels;

internal partial class AboutViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _path = FileSystem.Current.AppDataDirectory;
}