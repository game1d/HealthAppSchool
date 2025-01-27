namespace HealthAppSchool.Pages;

public partial class OptiePage : ContentPage
{
	public OptiePage()
	{
		InitializeComponent();
	}
    private void NoodButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NoodKnopPage());
    }


}