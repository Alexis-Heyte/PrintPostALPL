using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PrintPostALPL.Context.Models;

namespace PrintPostBureau.ViewModels
{
    public partial class CommandeListViewModel : ObservableObject
    {
        public ObservableCollection<Commande> Commandes { get; set; }

        public CommandeListViewModel()
        {
            LoadCommandes();
        }

        private void LoadCommandes()
        {
            using (var context = new PrintPostAlplContext())
            {
                // Charger les commandes avec les clients associés via la propriété de navigation
                var commandes = context.Commandes
                                       .Include(c => c.IdClientNavigation)  // Inclure les données du client
                                       .ToList();

                // Initialiser la collection Observable avec les commandes chargées
                Commandes = new ObservableCollection<Commande>(commandes);
            }
        }
    }
}
