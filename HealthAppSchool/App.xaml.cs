using HealthAppSchool.Data;

namespace HealthAppSchool
{
    public partial class App : Application
    {
        public App(HealthAppDatabase database)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(database));
        }
    }
}
