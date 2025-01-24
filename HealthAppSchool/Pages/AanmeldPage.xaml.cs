namespace HealthAppSchool.Pages;
using HealthAppSchool.Data;
using HealthAppSchool.Models;

public partial class AanmeldPage : ContentPage
{
    private readonly HealthAppDatabase _healthAppDatabase;
   
    public AanmeldPage(HealthAppDatabase healtAppDatase)
	{
		InitializeComponent();

        _healthAppDatabase = healtAppDatase;

        BindingContext = this;  

    }

    private void aanmeldBtn_Clicked(object sender, EventArgs e)
    {
        Klant nieuweKlant = new Klant
        {
            Voornaam = voornaamEntry.Text,
            Achternaam = achternaamEntry.Text,
            Email = emailEntry.Text,
            WachtWoord = wachtwoordEntry.Text

        };
        //KlantToken klantToken = new KlantToken();
        _healthAppDatabase.CreateKlant(nieuweKlant);

        Navigation.PushAsync(new MainPage(_healthAppDatabase));
    }

    private void annuleerBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}