using PrintPostALPL.Context.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PrintPostClient.ViewModels
{
    public partial class HomeViewModel(IDialogService dialogService, INavigationService navigationService) : BaseViewModel(dialogService, navigationService)
    {
        [RelayCommand]
        private Task LoginAsync() => NavigationService.GoToAsync("listpage");
    }


}
