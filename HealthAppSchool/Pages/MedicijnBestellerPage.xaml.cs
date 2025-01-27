using HealthAppSchool.Data;
using HealthAppSchool.Models;
using System.Collections.Generic;

namespace HealthAppSchool.Pages;

public partial class MedicijnBestellerPage : ContentPage
{
    HealthAppDatabase healthAppDatabase;
    public List<Medicijn> medicijnen { get; set; } = new List<Medicijn>();
  
    public MedicijnBestellerPage(HealthAppDatabase healtAppDatase)
	{
		InitializeComponent();
    
        BindingContext = this;
        HaalMedicijnen();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        HaalMedicijnen();
    }
    private async void HaalMedicijnen()
    {
        try
        {
            var medicijnen = await healthAppDatabase.GetMedicijnByIdAsync();
            LvMedicijn.ItemsSource = null; 
            LvMedicijn.ItemsSource = medicijnen;
        }

        catch (Exception ex)
        {
            await DisplayAlert("Fout", $"Fout bij ophalen van medicijn: {ex.Message}", "OK");
        }
       
      
    }

    private void LvMedicijn_ItemTapped(object sender, ItemTappedEventArgs e)
    {

    }



    //private async void LvMedicijn_ItemTapped(object sender, ItemTappedEventArgs e)
    //{
    //    if (e.Item == null)
    //        return;
    //    var SelectedMedicijn = e.Item as Medicijn;
    //    if (SelectedMedicijn != null)
    //    {
    //        await DisplayAlert("ok", "Ok", "Ok");
    //    }
    //    ((ListView)sender).SelectedItem = null;

    //}
}