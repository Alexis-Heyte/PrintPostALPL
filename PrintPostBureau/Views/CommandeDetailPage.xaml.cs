using PrintPostALPL.Context.Models;

namespace PrintPostBureau.Views
{
    public partial class CommandeDetailPage : ContentPage
    {
        private Commande _commande;
        public CommandeDetailPage(Commande commande)
        {
            InitializeComponent();
            _commande = commande;
            BindingContext = _commande;
        }

        private async void OnUpdateDateClicked(object sender, EventArgs e)
        {
            var selectedDate = DateDepotReellePicker.Date;
            if (selectedDate < DateTime.Now)
            {
                await DisplayAlert("Erreur", "La date doit être future.", "OK");
                return;
            }

            using (var context = new PrintPostAlplContext())
            {
                var commandeToUpdate = context.Commandes.Find(_commande.IdCommande);
                if (commandeToUpdate != null)
                {
                    commandeToUpdate.DateDepotReel = selectedDate;
                    context.SaveChanges();
                }
            }

            await DisplayAlert("Succès", "La date a été mise à jour.", "OK");
            await Navigation.PopAsync();
        }
    }
}
