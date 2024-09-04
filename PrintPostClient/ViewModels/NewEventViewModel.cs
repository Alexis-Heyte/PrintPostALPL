using PrintPostALPL.Context.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PrintPostClient.ViewModels
{
    public partial class NewEventViewModel(IDialogService dialogService, INavigationService navigationService) : BaseViewModel(dialogService, navigationService)
    {
        private readonly PrintPostAlplContext _context = new PrintPostAlplContext();

        [ObservableProperty]
        public ObservableCollection<Commande> _commandes = new ObservableCollection<Commande>();

        [ObservableProperty]
        private Event _event = new();

        [RelayCommand]
        private async Task SaveAsync()
        {
            await DialogService.DisplayAlertAsync("Add Event", "Save the event details to a data store.", "OK");
            await NavigationService.GoBackAsync();
        }

        [RelayCommand]
        private Task CancelAsync() => NavigationService.GoBackAsync();
    }

}

