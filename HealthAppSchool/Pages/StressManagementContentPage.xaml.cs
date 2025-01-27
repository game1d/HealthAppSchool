using CommunityToolkit.Maui.Views;
using HealthAppSchool.Models;
using System;

namespace HealthAppSchool.Pages;

public partial class StressManagementContentPage : ContentPage
{
    public string StressmanagementNaam { get; set; }
    public string StressmanagementBeschrijving { get; set; }

    public StressManagementContentPage(StressManagement stressManagement)
	{
		InitializeComponent();
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
        Navigation.PushAsync(new OptiePage());
    }
}