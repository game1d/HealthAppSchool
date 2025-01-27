using HealthAppSchool.Data;
using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class MedicijnPlannerPage : ContentPage
{
    public HealthAppDatabase healthAppDatabase { get; set; }
    public KlantToken klantToken { get; set; }
    public MedicijnPlannerPage(HealthAppDatabase _healtAppDatabase, KlantToken _klantToken)
	{
		InitializeComponent();
        healthAppDatabase = _healtAppDatabase;
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