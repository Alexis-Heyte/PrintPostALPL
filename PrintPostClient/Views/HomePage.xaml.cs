using System.Reflection;

namespace PrintPostClient.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage(HomeViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.Title = "Connexion";
            SetBinding(Page.TitleProperty, new Binding(nameof(HomeViewModel.Title)));
        }
    }
}
