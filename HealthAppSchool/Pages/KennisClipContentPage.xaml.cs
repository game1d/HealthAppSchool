using CommunityToolkit.Maui.Views;
using HealthAppSchool.Data;
using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class KennisClipContentPage : ContentPage
{
    public HealthAppDatabase healthAppDatabase { get; set; }
    public KlantToken klantToken { get; set; }
    public string kennisClipNaam {  get; set; }
	public string KennisClipBeschrijving {  get; set; }

	
	public KennisClipContentPage(KennisClip GekozenKennisClip, HealthAppDatabase _healthAppDatabase, KlantToken _klantToken)
	{
		InitializeComponent();
        healthAppDatabase = _healthAppDatabase;
        klantToken = _klantToken;
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
        Navigation.PushAsync(new OptiePage(healthAppDatabase, klantToken));
    }
}