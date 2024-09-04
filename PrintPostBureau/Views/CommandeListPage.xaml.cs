using PrintPostALPL.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace PrintPostBureau.Views
{
    public partial class CommandeListPage : ContentPage
    {
        public CommandeListPage()
        {
            InitializeComponent();
            LoadCommandes();
        }

        private void LoadCommandes()
        {
            using (var context = new PrintPostAlplContext())
            {
                var commandes = context.Commandes
                                       .Include(c => c.IdClientNavigation)
                                       .ToList();

                CommandeListView.ItemsSource = commandes;
            }
        }

        private async void OnDetailButtonClicked(object sender, EventArgs e)
        {
            // Récupérer la commande à partir du bouton
            var button = sender as Button;
            var commande = button?.CommandParameter as Commande;

            if (commande != null)
            {
                // Naviguer vers la page des détails de la commande
                await Navigation.PushAsync(new CommandeDetailPage(commande));
            }
        }
    }
}
