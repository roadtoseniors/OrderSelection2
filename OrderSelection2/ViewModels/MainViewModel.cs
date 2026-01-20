using CommunityToolkit.Mvvm.ComponentModel;

namespace OrderSelection2.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _greeting = "Welcome to Avalonia!";
}