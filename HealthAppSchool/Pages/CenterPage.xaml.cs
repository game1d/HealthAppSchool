namespace HealthAppSchool.Pages;
using HealthAppSchool.Data;
using HealthAppSchool.Models;


public partial class CenterPage : ContentPage
{
    HealthAppDatabase healthAppDatabase;
    KlantToken KlantToken;

    public CenterPage(HealthAppDatabase dataBase, KlantToken klantToken)
	{
		InitializeComponent();
        healthAppDatabase = dataBase;
        KlantToken = klantToken;
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
}