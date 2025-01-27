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

	
    private void NoodButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NoodKnopPage());
    }

    private void SettingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OptiePage(healthAppDatabase, klantToken));
    }
}