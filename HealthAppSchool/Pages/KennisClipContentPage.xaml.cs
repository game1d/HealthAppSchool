using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class KennisClipContentPage : ContentPage
{
	KennisClip GebruikteKennisClip { get; set; }
	public KennisClipContentPage(KennisClip GekozenKennisClip)
	{
		InitializeComponent();
		GebruikteKennisClip = GekozenKennisClip;
		

    }
}