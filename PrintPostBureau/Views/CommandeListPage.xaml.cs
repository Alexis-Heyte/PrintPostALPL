using PrintPostALPL.Context.Models;
using Microsoft.EntityFrameworkCore;
using PrintPostBureau.ViewModels;

namespace PrintPostBureau.Views
{
    public partial class CommandeListPage : ContentPage
    {
        public CommandeListPage()
        {
            InitializeComponent();
            BindingContext = new CommandeListViewModel();  // Lier au ViewModel
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
