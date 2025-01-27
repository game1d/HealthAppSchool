using HealthAppSchool.Data;
using HealthAppSchool.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.ObjectModel;

namespace HealthAppSchool.Pages;

public partial class VoedingInnamePage : ContentPage
{
    public HealthAppDatabase healthAppDatabase { get; set; }
    public KlantToken klantToken { get; set; }

    public ObservableCollection<VoedselInname> Voedsels { get; set; } = new();
    private readonly HealthAppDatabase _database;
    public int IngelogdeKlant;
    public VoedingInnamePage( int klantId ,HealthAppDatabase database, KlantToken _klantToken)
	{
		InitializeComponent();
        IngelogdeKlant = klantId;
        _database = database;
        klantToken = _klantToken;
        BindingContext = this;

    }

        
	
    private void NoodButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NoodKnopPage());
    }

    private void SettingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OptiePage(healthAppDatabase, klantToken));
    }

    private void voegVoedselToeBtn_Clicked(object sender, EventArgs e)
    {
         Navigation.PushAsync(new VoedselInvulPage(IngelogdeKlant, _database, klantToken));
    }
    private async Task<ObservableCollection<VoedselInname>> GetVoedselInname()
    {
        Voedsels = new ObservableCollection<VoedselInname>(
            await _database.GetVoedselInnamesOnKlant(IngelogdeKlant)
        );    
        return Voedsels;
    }


    protected async override void OnAppearing()
    {
        base.OnAppearing();
         Voedsels = await GetVoedselInname();
    }
}