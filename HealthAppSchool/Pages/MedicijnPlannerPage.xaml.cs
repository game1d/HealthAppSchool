namespace HealthAppSchool.Pages;

public partial class MedicijnPlannerPage : ContentPage
{
	public MedicijnPlannerPage()
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