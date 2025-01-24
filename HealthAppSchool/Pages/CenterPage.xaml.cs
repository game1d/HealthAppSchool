namespace HealthAppSchool.Pages;
using HealthAppSchool.Data;
using HealthAppSchool.Models;


public partial class CenterPage : ContentPage
{
    HealthAppDatabase healthAppDatabase;
    KlantToken KlantToken;

    public CenterPage(HealthAppDatabase dataBase, KlantToken klantToken)
	{
        healthAppDatabase = dataBase;
        KlantToken = klantToken;
        InitializeComponent();
        
	}

    private void backButton_Clicked(object sender, EventArgs e)
    {
        healthAppDatabase.DeleteKlantToken(KlantToken);

        Navigation.PopAsync();
    }

    private void FysiekeActiviteitButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FysiekeActiviteitPage());
    }

    private void VerbrandeCaloriënbutton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VerbrandeCalorienPage());
    }

    private void NoodButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NoodKnopPage());
    }

    private void SettingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OptiePage());
    }

    private void KennisClipButton_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new KennisClipPage());
    }

    private void MedicijnButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MedicijnPage());
    }
}