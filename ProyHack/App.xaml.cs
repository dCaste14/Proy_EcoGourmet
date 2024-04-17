namespace ProyHack
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            BBDD.InitializeDatabase();
            MainPage = new AppShell();
        }
    }
}
