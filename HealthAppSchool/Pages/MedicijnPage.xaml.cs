using HealthAppSchool.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace HealthAppSchool.Pages;

public partial class MedicijnPage : ContentPage
{
    public List<Medicijn> medicijnen { get; set; } = new List<Medicijn>();
    
    public MedicijnPage()
	{
		InitializeComponent();
	}

    private async void LvMedicijn_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null)
            return;

        var selectedMedicijn = e.Item as Medicijn;
        if (selectedMedicijn != null)
        {
           // await Navigation.PushAsync(new MedicijnBestellerPage(Database, selectedMedicijn));
        }
        ((ListView)sender).SelectedItem = null;
    }
}