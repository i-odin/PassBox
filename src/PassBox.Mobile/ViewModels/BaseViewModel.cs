using CommunityToolkit.Mvvm.ComponentModel;

namespace PassBox.Mobile.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        public bool _isBusy;

        [ObservableProperty]
        public string _title;
    }
}
