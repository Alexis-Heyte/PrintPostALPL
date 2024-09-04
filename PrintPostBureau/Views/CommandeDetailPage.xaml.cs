using PrintPostALPL.Context.Models;
using PrintPostBureau.ViewModels;

namespace PrintPostBureau.Views
{
    public partial class CommandeDetailPage : ContentPage
    {
        public CommandeDetailPage(Commande commande)
        {
            InitializeComponent();
            // Utiliser le ViewModel et passer la commande
            BindingContext = new CommandeDetailViewModel(commande);
        }
    }
}