using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PrintPostALPL.Context.Models;
using System.ComponentModel;

namespace PrintPostBureau.ViewModels
{
    public partial class CommandeDetailViewModel : ObservableObject
    {
        private Commande _commande;

        // Le constructeur prend une instance de Commande
        public CommandeDetailViewModel(Commande commande)
        {
            _commande = commande;
        }

        // Propriété pour la Date de dépôt souhaitée
        public DateTime? DateDepotSouhaite
        {
            get => _commande.DateDepotSouhaite;
            set
            {
                if (_commande.DateDepotSouhaite != value)
                {
                    _commande.DateDepotSouhaite = value;
                    OnPropertyChanged(nameof(DateDepotSouhaite));  // Notifier le changement
                }
            }
        }

        // Propriété pour la Date de dépôt réelle
        public DateTime? DateDepotReel
        {
            get => _commande.DateDepotReel;
            set
            {
                if (_commande.DateDepotReel != value)
                {
                    _commande.DateDepotReel = value;
                    OnPropertyChanged(nameof(DateDepotReel));  // Notifier le changement
                }
            }
        }
    }
}
