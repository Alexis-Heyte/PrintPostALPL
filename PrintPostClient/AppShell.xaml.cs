namespace PrintPostClient
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Register the routes of the detail pages
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("listpage", typeof(CommandePage));
            Routing.RegisterRoute("addcommande", typeof(NewEventPage));
            Routing.RegisterRoute("newevent", typeof(NewEventPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Current.GoToAsync("//login");
        }
    }
}
