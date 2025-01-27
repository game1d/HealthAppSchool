using HealthAppSchool.Data;
using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class SlaapPatroonPage : ContentPage
{
    public HealthAppDatabase healthAppDatabase { get; set; }
    public KlantToken klantToken { get; set; }
    public SlaapPatroonPage(HealthAppDatabase _healtAppDataBase, KlantToken _klantToken)
	{
		InitializeComponent();
        healthAppDatabase = _healtAppDataBase;
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