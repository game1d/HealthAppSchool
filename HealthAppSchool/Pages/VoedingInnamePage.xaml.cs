namespace HealthAppSchool.Pages;

public partial class VoedingInnamePage : ContentPage
{
	public VoedingInnamePage()
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