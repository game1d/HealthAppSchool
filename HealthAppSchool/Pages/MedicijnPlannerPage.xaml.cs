using HealthAppSchool.Data;
using HealthAppSchool.Models;
namespace HealthAppSchool.Pages;

public partial class MedicijnPlannerPage : ContentPage
{
    HealthAppDatabase healthAppDatabase;
    public MedicijnPlannerPage(HealthAppDatabase healtAppDatase)
	{
		InitializeComponent();
        healthAppDatabase = healtAppDatase;
        BindingContext = this;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
       
    }

    private async void Herinneringbtn_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(MedicijnNaamEntry.Text))
        {
            await DisplayAlert("Fout", "voer een medicijn naam in", "OK");
            return;
        }
        TimeOnly gekozenTijd = TimeOnly.FromTimeSpan(HerinneringTimePicker.Time);

        var medicijnHerinnering = new MedicijnHerinnering()
        {
            PatientId = 1,
           // MedicijnNaam = MedicijnNaamEntry.Text,
            Tijdstip = gekozenTijd
        };
        await DisplayAlert("Succes", "Herinnering ingesteld", "OK");

    }
}