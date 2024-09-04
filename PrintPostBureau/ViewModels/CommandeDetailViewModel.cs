using CommunityToolkit.Mvvm.ComponentModel;
using PrintPostALPL.Context.Models;
using System;

namespace PrintPostBureau.ViewModels
{
    public partial class CommandeDetailViewModel : ObservableObject
    {
        private Commande _commande;

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
                    OnPropertyChanged(nameof(DateDepotSouhaite));
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
                    OnPropertyChanged(nameof(DateDepotReel));
                    OnPropertyChanged(nameof(Penalite)); // Met à jour la pénalité
                }
            }
        }

        // Propriété pour la Pénalité
        public decimal? Penalite
        {
            get
            {
                if (_commande.DateDepotReel.HasValue && _commande.DateDepotSouhaite.HasValue)
                {
                    // Calcul de la pénalité seulement si la date réelle est après la date souhaitée
                    if (_commande.DateDepotReel > _commande.DateDepotSouhaite)
                    {
                        TimeSpan delay = _commande.DateDepotReel.Value - _commande.DateDepotSouhaite.Value;
                        decimal? penaliteParJour = _commande.IdClientNavigation.MntPenalite; // Le montant de pénalité par jour pour ce client
                        return penaliteParJour * (decimal)delay.TotalDays;
                    }
                }
                return 0;
            }
        }
    }
}
