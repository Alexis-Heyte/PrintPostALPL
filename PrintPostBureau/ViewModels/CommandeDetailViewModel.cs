using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;
using System.Windows.Input; // Assurez-vous que cette directive est présente
using PrintPostALPL.Context.Models;
using Microsoft.Maui.Controls; // Assurez-vous que cette directive est présente

namespace PrintPostBureau.ViewModels
{
    public partial class CommandeDetailViewModel : ObservableObject
    {
        private Commande _commande;

        // Constructeur
        public CommandeDetailViewModel(Commande commande)
        {
            _commande = commande;
            // Initialisation de la commande UpdateDate
            UpdateDateCommand = new Command(async () => await UpdateDateAsync());
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

        // Commande pour mettre à jour la date de dépôt réelle
        public ICommand UpdateDateCommand { get; }

        // Méthode pour mettre à jour la date de dépôt réelle
        private async Task UpdateDateAsync()
        {
            if (DateDepotReel < DateTime.Now)
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "La date doit être future.", "OK");
                return;
            }

            using (var context = new PrintPostAlplContext())
            {
                var commandeToUpdate = context.Commandes.Find(_commande.IdCommande);
                if (commandeToUpdate != null)
                {
                    commandeToUpdate.DateDepotReel = DateDepotReel;
                    context.SaveChanges();
                }
            }

            await Application.Current.MainPage.DisplayAlert("Succès", "La date a été mise à jour.", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
