using HealthAppSchool.Data;
using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class MedicijnPage : ContentPage
{
    private readonly HealthAppDatabase _healthAppDatabase;
    public int PatientId;
    public MedicijnPage(HealthAppDatabase healtAppDatase)
	{
		InitializeComponent();
        _healthAppDatabase = healtAppDatase;
        BindingContext = this;
        PatientId = PatientId;
       
        HaalPatientData();
    }

    public async void HaalPatientData()
    {
       
        //var patient = await _healthAppDatabase.GetPatientByPatientId(PatientId);
        //if (patient != null)
        //{
        //    WelcomeLabel.Text = $"Welkom {Patient.PatientName}";
        //}
        //else
        //{
        //    WelcomeLabel.Text = "Patient niet gevonden.";
        //}
    }

    private async void bestelbtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MedicijnBestellerPage(_healthAppDatabase));
    }

    private void herinneringbtn_Clicked(object sender, EventArgs e)
    {

    }
}