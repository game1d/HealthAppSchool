using HealthAppSchool.Data;
using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;
using HealthAppSchool.Models;
using HealthAppSchool.Data;

public partial class VoedselInvulPage : ContentPage
{
    public KlantToken klantToken;
    private readonly HealthAppDatabase _database;
    private readonly int _ingelogdeKlantId;
    public VoedselInvulPage(int ingelogdeKlantId, HealthAppDatabase database, KlantToken _klantToken)
    {
        InitializeComponent();
        _database = database;
        _ingelogdeKlantId = ingelogdeKlantId;
        klantToken = _klantToken;
    }

    private async void OpslaanButton_Clicked(object sender, EventArgs e)
    {
        var voedselNaam = VoedselNaamEntry.Text;
        var gewicht = int.TryParse(GewichtEntry.Text, out var gewichtInGram) ? gewichtInGram : 0;

        if (string.IsNullOrWhiteSpace(voedselNaam) || gewicht <= 0)
        {
            await DisplayAlert("Fout", "Vul alle velden correct in.", "OK");
            return;
        }

        var voedselInname = new VoedselInname
        {
            KlantId = _ingelogdeKlantId,
            VoedselNaam = voedselNaam,
            VoedselGewichtInGram = gewicht,
            Datum = DateOnly.FromDateTime(DateTime.Now)
        };

        _database.CreateVoedselInname(voedselInname);

        await DisplayAlert("Succes", "Voedsel toegevoegd.", "OK");

        await Navigation.PopAsync();
    }



    private void NoodButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NoodKnopPage());
    }

    private void SettingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OptiePage(_database, klantToken));
    }
}