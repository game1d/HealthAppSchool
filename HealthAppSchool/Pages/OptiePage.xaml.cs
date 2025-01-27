using HealthAppSchool.Data;
using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class OptiePage : ContentPage
{
	HealthAppDatabase database { get;set; }
        
    KlantToken klantToken { get; set; }
    
    public OptiePage(HealthAppDatabase _database, KlantToken _klantToken)
	{
		InitializeComponent();
        database = _database;
        klantToken = _klantToken;
        

    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs e)
    {
        base.OnNavigatedTo(e);
        Klant klant = await database.GetKlantOnId(klantToken.KlantId);
        VoorNaamEntry.Text= klant.Voornaam;
        AchterNaamEntry.Text = klant.Achternaam;
        EmailEntry.Text = klant.Email;
    }


    private void NoodButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NoodKnopPage());
    }

    private async void VoorNaamButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            await database.UpdateKlantVoornaam(klantToken.KlantId, VoorNaamEntry.Text);
            await DisplayAlert("Voornaam verandert", $"Je hebt je voornaam verandert in {VoorNaamEntry.Text}", "ok");
        }
        catch (Exception ex) { await DisplayAlert("Error", $"er is iets misgegaan.{ex}", "ok"); }
    }

    private async void AchterNaamButton_Clicked(object sender, EventArgs e)
    {
        try {
            await database.UpdateKlantAchternaam(klantToken.KlantId, AchterNaamEntry.Text);
            await DisplayAlert("Achternaam verandert", $"Je hebt je achternaam verandert in {AchterNaamEntry.Text}", "ok");
        }
        catch (Exception ex) { await DisplayAlert("Error", $"er is iets misgegaan.{ex}", "ok"); }
    }

    private async void EmailButton_Clicked(object sender, EventArgs e)
    {
        try {
            await database.UpdateKlantEmail(klantToken.KlantId, EmailEntry.Text);
            await database.UpdateKlantTokenEmail(klantToken, EmailEntry.Text);
            await DisplayAlert("Email verandert", $"Je hebt je email verandert in {EmailEntry.Text}", "ok");
        }
        catch (Exception ex) { await DisplayAlert("Error", $"er is iets misgegaan.{ex}", "ok"); }
    }

    private async void WachtwoordButton_Clicked(object sender, EventArgs e)
    {
        try {
            if (OudWachtwoordEntry.Text == klantToken.KlantWachtwoord)
            {
                await database.UpdateKlantWachtWoord(klantToken.KlantId, WachtwoordEntry.Text);
                await database.UpdateKlantTokenWachtwoord(klantToken, WachtwoordEntry.Text);
                await DisplayAlert("Wachtwoord verandert", $"Je hebt je wachtwoord verandert", "ok");
            }
            else
            {
                await DisplayAlert("Verkeerd wachtwoord", "Je hebt niet het goede oude wachtwoord opgegeven", "ok");
            }
        }
        catch (Exception ex) { await DisplayAlert("Error", $"er is iets misgegaan.{ex}", "ok"); }
        WachtwoordEntry = null;
        OudWachtwoordEntry = null;
    }
}