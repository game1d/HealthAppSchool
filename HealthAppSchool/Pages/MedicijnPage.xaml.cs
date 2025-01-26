using HealthAppSchool.Models;
using HealthAppSchool.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace HealthAppSchool.Pages;

public partial class MedicijnPage : ContentPage
{
   
    HealthAppDatabase healthAppDatabase;
  
    public MedicijnPage(HealthAppDatabase healtAppDatase)
	{
		InitializeComponent();
        healthAppDatabase = healtAppDatase;
        BindingContext = this;
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
        await Navigation.PushAsync(new MedicijnBestellerPage(healthAppDatabase));
       
    }

    private async void Medicijnplannerbtn_Clicked(object sender, EventArgs e)
    {
       // await Navigation.PushAsync(new MedicijnPlannerPage(healthAppDatabase));
    }




    //private async void LvMedicijn_ItemTapped(object sender, ItemTappedEventArgs e)
    //{
    //    if (e.Item == null)
    //        return;

    //    var selectedMedicijn = e.Item as Medicijn;
    //    if (selectedMedicijn != null)
    //    {
    //       // await Navigation.PushAsync(new MedicijnBestellerPage(Database, selectedMedicijn));
    //    }
    //    ((ListView)sender).SelectedItem = null;
    //}
}