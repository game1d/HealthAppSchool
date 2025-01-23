using HealthAppSchool.Data;
using HealthAppSchool.Models;
using HealthAppSchool.Pages;

namespace HealthAppSchool
{
    public partial class MainPage : ContentPage
    {


        HealthAppDatabase healthAppDatabase;

        public MainPage(HealthAppDatabase dataBase)
        {
            InitializeComponent();
            healthAppDatabase = dataBase;
            KlantToken klantToken = healthAppDatabase.GetKlantToken();
            if (klantToken != null) { Navigation.PushAsync(new CenterPage(healthAppDatabase, klantToken)); }
        }

        private async void InlogButton_Clicked(object sender, EventArgs e)
        {
            try 
            {
                if (EmailInput.Text != null && WachtwoordInput.Text != null)
                {
                    Klant inlogKlant = await healthAppDatabase.GetKlantOnEmail(EmailInput.Text);
                    if (inlogKlant.Email == null) { await DisplayAlert("Verkeerd email", "Het email dat is ingevuld bestaat niet.", "ok"); }
                    else if (inlogKlant.WachtWoord == WachtwoordInput.Text)
                    {
                        healthAppDatabase.CreateKlantToken(inlogKlant, WachtwoordInput.Text);
                        KlantToken klantToken2 = healthAppDatabase.GetKlantToken();
                        Navigation.PushAsync(new CenterPage(healthAppDatabase, klantToken2));
                    }
                    else { await DisplayAlert("Verkeerd wachtwoord", "Het wachtwoord dat is ingevuld klopt niet.", "ok"); }
                }
                else { await DisplayAlert("Velden leeg", "Niet alle velden zijn ingevuld.", "ok"); }
            }
            catch (Exception excep) 
            { await DisplayAlert("Inlogerror", $"{excep}", "ok");  }
        }
    }
}
