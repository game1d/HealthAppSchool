using CommunityToolkit.Maui.Views;
using HealthAppSchool.Data;
using HealthAppSchool.Models;
using System;

namespace HealthAppSchool.Pages;

public partial class StressManagementContentPage : ContentPage
{
    public HealthAppDatabase healthAppDatabase { get; set; }
    public KlantToken klantToken { get; set; }
    public string StressmanagementNaam { get; set; }
    public string StressmanagementBeschrijving { get; set; }

    public StressManagementContentPage(StressManagement stressManagement, HealthAppDatabase _healthAppDatabase, KlantToken _klantToken)
	{
		InitializeComponent();
        healthAppDatabase = _healthAppDatabase;
        klantToken = _klantToken;
        StressmanagementNaam = stressManagement.Name;
        StressmanagementBeschrijving = stressManagement.Description;
        try 
        {
            if (stressManagement.Url != "")
            {
                StressManagementFilmPlayer.Source = MediaSource.FromResource(stressManagement.Url);
            }
        }
        catch (Exception ex) { DisplayAlert("movierror", $"{ex}", "ok"); }
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
}