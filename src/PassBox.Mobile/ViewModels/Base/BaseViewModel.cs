using CommunityToolkit.Mvvm.ComponentModel;

namespace PassBox.Mobile.ViewModels.Base;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    public bool _isBusy;

    [ObservableProperty]
    public string _title;
}
