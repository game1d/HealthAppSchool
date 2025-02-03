using HealthAppSchool.Models;
using HealthAppSchool.Data;

namespace HealthAppSchool.Pages;

//Bedoeling was om met deze pagina op alle andere de nood en settingsknop te krijgen.
public partial class InheritPage : ContentPage //Geprobeerd hier iets mee te doen, maar niet gelukt. Navigiation is nog te fixen met base. maar er zijn meer ronde kringtjes waar ik de oplossing niet voor weet.
{
    public HealthAppDatabase healthAppDatabase { get; set; }
    public KlantToken klantToken { get; set; }

    public InheritPage(HealthAppDatabase _healthAppDatabase, KlantToken _klantToken)
	{
		InitializeComponent();
        healthAppDatabase = _healthAppDatabase;
        klantToken = _klantToken;
    }
    private void NoodButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NoodKnopPage());
    }

    private void SettingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OptiePage(healthAppDatabase, klantToken));
    }
}