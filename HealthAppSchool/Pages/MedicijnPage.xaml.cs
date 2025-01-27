using HealthAppSchool.Models;
using HealthAppSchool.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace HealthAppSchool.Pages;

public partial class MedicijnPage: ContentPage
{
	public KlantToken klantToken { get; set; }
    HealthAppDatabase healthAppDatabase;
    // public MedicijnPage(KlantToken _klantToken);

    public MedicijnPage(HealthAppDatabase healtAppDatase)
	{
		InitializeComponent();
        healthAppDatabase = healtAppDatase;
        BindingContext = this;
       
        klantToken = klantToken;
    }

   

    private async void bestelbtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MedicijnBestellerPage(healthAppDatabase));
       
    }

    private async void Medicijnplannerbtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MedicijnPlannerPage(healthAppDatabase));
    }
}