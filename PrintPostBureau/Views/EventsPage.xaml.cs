using System.Reflection;

namespace PrintPostBureau.Views
{
    public partial class EventsPage : ContentPage
    {
        public EventsPage(EventsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.Title = "Accueil";
            SetBinding(Page.TitleProperty, new Binding(nameof(EventsViewModel.Title)));
        }
    }
}
