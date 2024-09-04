namespace PrintPostClient.Views
{
    public partial class CommandePage : ContentPage
    {
        public CommandePage(CommandeViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Title = "Liste Commandes";
            BindingContext = viewModel;
            SetBinding(Page.TitleProperty, new Binding(nameof(CommandeViewModel.Title)));
        }

    }
}
