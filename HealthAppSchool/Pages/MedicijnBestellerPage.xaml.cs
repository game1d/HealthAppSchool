using HealthAppSchool.Data;
using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class MedicijnBestellerPage : ContentPage
{
    HealthAppDatabase healthAppDatabase;
    public List<Medicijn> medicijnen { get; set; } = new List<Medicijn>();
    public MedicijnBestellerPage(HealthAppDatabase dataBase)
	{
		InitializeComponent();
        healthAppDatabase = dataBase;
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
            var medicijnen = await healthAppDatabase.ge
        }
        catch 
        { 

        }
       LvMedicijn.ItemsSource = medicijnen;
    }

    private void LvMedicijn_ItemTapped(object sender, ItemTappedEventArgs e)
    {

    }
}