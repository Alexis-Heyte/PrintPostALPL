using PrintPostALPL.Context.Models;
using PrintPostALPL.Context;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Mvvm.Input; // Assuming you're using CommunityToolkit.Mvvm for AsyncRelayCommand

namespace PrintPostClient.ViewModels
{

    public partial class CommandeViewModel(IDialogService dialogService, INavigationService navigationService) : BaseViewModel(dialogService, navigationService)
    {
        private readonly PrintPostAlplContext _context = new PrintPostAlplContext();

        [ObservableProperty]
        public ObservableCollection<Commande> _commandes = new ObservableCollection<Commande>();



        [RelayCommand]
        private async Task ActualiserAsync()
            => Commandes = new ObservableCollection<Commande>(
                await _context.Commandes
                .OrderBy(o => o.DateCreation)
                .ToListAsync());

        [RelayCommand]
        Task AddCommandeAsync() => NavigationService.GoToAsync("addcommande");
    }
}
