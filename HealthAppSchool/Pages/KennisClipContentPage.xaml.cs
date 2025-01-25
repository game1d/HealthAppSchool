using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class KennisClipContentPage : ContentPage
{
	public string kennisClipNaam {  get; set; }
	public string KennisClipBeschrijving {  get; set; }
	public string Url { get; set; }
	
	public KennisClipContentPage(KennisClip GekozenKennisClip)
	{
		InitializeComponent();
		kennisClipNaam = GekozenKennisClip.Name;
		KennisClipBeschrijving = GekozenKennisClip.Description;
		Url = GekozenKennisClip.Url;
		BindingContext=this;
    }
}