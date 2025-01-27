namespace HealthAppSchool.Pages;
using HealthAppSchool.Data;
using HealthAppSchool.Models;


public partial class CenterPage : ContentPage
{
    HealthAppDatabase healthAppDatabase;
    KlantToken klantToken;

    public CenterPage(HealthAppDatabase dataBase, KlantToken _klantToken)
	{
        healthAppDatabase = dataBase;
        this.klantToken = _klantToken;
        InitializeComponent();
        
	}

    private void backButton_Clicked(object sender, EventArgs e)
    {
        healthAppDatabase.DeleteKlantToken(klantToken);

        Navigation.PopAsync();
    }

    private void FysiekeActiviteitButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FysiekeActiviteitPage(healthAppDatabase));
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
        Navigation.PushAsync(new KennisClipPage(healthAppDatabase));
    }

    private void StressManagementButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StressManagementPage(healthAppDatabase));
    }

    private void MedicijnButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MedicijnPage(healthAppDatabase));
    }
}