using HealthAppSchool.Data;
using HealthAppSchool.Models;
using System.Collections.Generic;

namespace HealthAppSchool.Pages;

public partial class MedicijnBestellerPage : ContentPage
{
    HealthAppDatabase healthAppDatabase;
    KlantToken klantToken {  get; set; }
    public List<Medicijn> medicijnen { get; set; } = new List<Medicijn>();

    public MedicijnBestellerPage(HealthAppDatabase healtAppDatase, KlantToken _klantToken)
    {
        InitializeComponent();
        healthAppDatabase = healtAppDatase;
        BindingContext = this;

        klantToken = _klantToken;
        //HaalMedicijnen();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        medicijnen = await healthAppDatabase.GetMedicijnsIdAsync();
        LvMedicijn.ItemsSource = medicijnen;
    }
  

    private async void LvMedicijn_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null)
            return;
        var SelectedMedicijn = e.Item as Medicijn;
        if (SelectedMedicijn != null)
        {
            await DisplayAlert("Bevestigen", "wilt u bestellen?", "Ja", "Nee");
            var Bevestigen = await DisplayAlert("Bevestigen", "wilt u bestellen?", "Ja", "Nee");
            if (Bevestigen)
            {
                try
                {
                    //await healthAppDatabase.AddMedicijnAsync(SelectedMedicijn);
                    await DisplayAlert("Goed", $"Het medicijn {SelectedMedicijn.MedicijnNaam} is succesvol besteld", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Fout", $"Het medicijn kan niet besteld worden.{ex}", "OK");
                }
            }
        ((ListView)sender).SelectedItem = null;

        }
    }
    private void NoodButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NoodKnopPage());
    }

    private void SettingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OptiePage(healthAppDatabase, klantToken));
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