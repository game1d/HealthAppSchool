namespace HealthAppSchool.Pages;

public partial class VoedingWaardePage : ContentPage
{
	public VoedingWaardePage()
	{
		InitializeComponent();
	}
    private void NoodButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NoodKnopPage());
    }

    private void SettingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OptiePage());
    }
}