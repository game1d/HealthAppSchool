namespace HealthAppSchool.Pages;

public partial class NoodKnopPage : ContentPage
{
    public NoodKnopPage()
    {
        InitializeComponent();
    }

    private async void Noodknop_Clicked(object sender, EventArgs e)
    {

        try
        {
            if (PhoneDialer.Default.IsSupported)
                PhoneDialer.Default.Open("11");
        }
        catch (ArgumentNullException)
        {
            await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
        }
        catch (Exception)
        {
            // Other error has occurred.
            await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
        }

    }
}