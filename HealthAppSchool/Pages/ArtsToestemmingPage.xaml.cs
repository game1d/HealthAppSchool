using HealthAppSchool.Data;
using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class ArtsToestemmingPage : ContentPage
{
    public HealthAppDatabase healthAppDatabase { get; set; }
    public KlantToken klantToken {  get; set; }

    public ArtsToestemmingPage(HealthAppDatabase _healthAppDatabase, KlantToken _klantToken)
	{
		InitializeComponent();
        klantToken = _klantToken;
        healthAppDatabase = _healthAppDatabase;
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