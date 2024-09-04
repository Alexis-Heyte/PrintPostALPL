namespace PrintPostBureau.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (username == "printpost" && password == "1234")
            {
                Application.Current.MainPage = new NavigationPage(new CommandeListPage());
            }
            else
            {
                DisplayAlert("Erreur", "Identifiants incorrects", "OK");
            }
        }
    }
}
