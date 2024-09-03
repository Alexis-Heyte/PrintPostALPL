using PrintPostALPL.Context.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PrintPostClient.ViewModels
{
    //public partial class CommandeViewModel(IDialogService dialogService, INavigationService navigationService) : BaseViewModel(dialogService, navigationService)
    //{

    //}

    public class CommandeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Commande> Commandes { get; set; }
        public Command AjouterCommandeCommand { get; }

        public CommandeViewModel()
        {
            Commandes = new ObservableCollection<Commande>();

            AjouterCommandeCommand = new Command(AjouterCommande);
        }

        private void AjouterCommande()
        {
            // Logique pour ajouter une nouvelle commande
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
