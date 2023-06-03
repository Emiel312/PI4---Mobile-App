namespace PI4___Mobile_App;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new PersonenPage());
    }
}
