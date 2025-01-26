using HealthAppSchool.Data;
using HealthAppSchool.Models;
using System.Collections.Generic;


namespace HealthAppSchool.Pages;

public partial class MedicijnBestellerPage : ContentPage
{
    private readonly HealthAppDatabase _healthAppDatabase;
    public MedicijnBestellerPage(HealthAppDatabase healtAppDatase)
	{
		InitializeComponent();
        _healthAppDatabase = healtAppDatase;
        BindingContext = this;
        HaalMedicijnen();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
      
        HaalMedicijnen();
    }

    public async void HaalMedicijnen()
    {
        try
        {
            var medicijnen = await _healthAppDatabase.GetMedicijnByIdAsync();
            LvMedicijn.ItemsSource = medicijnen;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fout", $"Fout bij ophalen van medicijn: {ex.Message}", "OK");
        }
    }

    private async void LvMedicijn_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null)
            return;
        var SelectedMedicijn = e.Item as Medicijn;
        if (SelectedMedicijn != null)
        {
            await DisplayAlert("ok", "Ok", "Ok");
        }
        ((ListView)sender).SelectedItem = null;
    }
}