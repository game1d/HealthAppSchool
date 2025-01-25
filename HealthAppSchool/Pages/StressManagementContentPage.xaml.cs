using HealthAppSchool.Models;
using System;

namespace HealthAppSchool.Pages;

public partial class StressManagementContentPage : ContentPage
{
    public string StressmanagementNaam { get; set; }
    public string StressmanagementBeschrijving { get; set; }
    public string Url { get; set; }
    public StressManagementContentPage(StressManagement stressManagement)
	{
		InitializeComponent();
        StressmanagementNaam = stressManagement.Name;
        StressmanagementBeschrijving = stressManagement.Description;
        Url = stressManagement.Url;
        BindingContext = this;
    }
}