using CommunityToolkit.Maui.Views;
using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class KennisClipContentPage : ContentPage
{
	public string kennisClipNaam {  get; set; }
	public string KennisClipBeschrijving {  get; set; }

	
	public KennisClipContentPage(KennisClip GekozenKennisClip)
	{
		InitializeComponent();
		kennisClipNaam = GekozenKennisClip.Name;
		KennisClipBeschrijving = GekozenKennisClip.Description;
        try
        {
            if (GekozenKennisClip.Url != "")
            {
                KennisClipFilmPlayer.Source = MediaSource.FromResource(GekozenKennisClip.Url);
            }
        }
        catch (Exception ex) { DisplayAlert("movierror", $"{ex}", "ok"); }
		BindingContext=this;
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