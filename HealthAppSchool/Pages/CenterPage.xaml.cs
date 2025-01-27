namespace HealthAppSchool.Pages;
using HealthAppSchool.Data;
using HealthAppSchool.Models;


public partial class CenterPage : ContentPage
{
    HealthAppDatabase healthAppDatabase;
    KlantToken klantToken;
    public Klant IngelogdeKlant { get; set; }

    public CenterPage(HealthAppDatabase dataBase, KlantToken _klantToken )
	{
        healthAppDatabase = dataBase;
        klantToken = _klantToken;




        InitializeComponent();
        
	}
    protected override async void OnNavigatedTo(NavigatedToEventArgs e)
    {
        base.OnNavigatedTo(e);
        IngelogdeKlant = await healthAppDatabase.GetKlantOnId(klantToken.KlantId);
    }

    private void backButton_Clicked(object sender, EventArgs e)
    {
        healthAppDatabase.DeleteKlantToken(klantToken);
        
        Navigation.PopAsync();
    }

    private void FysiekeActiviteitButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FysiekeActiviteitPage(healthAppDatabase, klantToken));
    }

    private void VerbrandeCaloriënbutton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VerbrandeCalorienPage(healthAppDatabase, klantToken));
    }

   
    private void VoedingsInnameButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VoedingInnamePage(klantToken.KlantId,healthAppDatabase, klantToken));
    }

    private void VoedingsWaardeButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VoedingWaardePage(healthAppDatabase, klantToken));
    }
    private void SlaapPatroonButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SlaapPatroonPage(healthAppDatabase, klantToken));
    }
    private void KennisClipButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new KennisClipPage(healthAppDatabase, klantToken));
    }

    private void StressManagementButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StressManagementPage(healthAppDatabase, klantToken));
    }

    private void MedicijnButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MedicijnPage(healthAppDatabase, klantToken));
    }


    private void NoodButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NoodKnopPage());
    }

    private void SettingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OptiePage(healthAppDatabase, klantToken));
    }
    protected override bool OnBackButtonPressed()
    {
        // Return true to prevent back button 
        return true;
    }
}