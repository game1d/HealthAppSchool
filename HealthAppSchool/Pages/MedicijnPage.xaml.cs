using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class MedicijnPage : ContentPage
{
	public KlantToken klantToken { get; set; }
    public MedicijnPage(KlantToken _klantToken)
	{
		InitializeComponent();
        klantToken = _klantToken;
	}

    private void LvMedicijn_ItemTapped(object sender, ItemTappedEventArgs e)
    {

    }

    private void bestelbtn_Clicked(object sender, EventArgs e)
    {

    }
}