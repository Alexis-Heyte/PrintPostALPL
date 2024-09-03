namespace PrintPostClient.Views
{
    public partial class CommandePage : ContentPage
    {
        public CommandePage()
        {
            InitializeComponent();
            BindingContext = new CommandeViewModel();
        }
    }
}
