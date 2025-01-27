using HealthAppSchool.Data;
using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class KennisClipPage : ContentPage
{
    
    
    HealthAppDatabase healthAppDatabase { get; set; }
    KlantToken klantToken {  get; set; }
    public KennisClipPage(HealthAppDatabase dataBase, KlantToken _klantToken)
	{
        healthAppDatabase = dataBase;
        InitializeComponent();
        klantToken = _klantToken;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs e)
    {
        base.OnNavigatedTo(e);
        var items = await healthAppDatabase.GetKennisClips();

        KennisClipView.ItemsSource = items;
    }

    private void KennisClipView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var gekozenKennisClip = KennisClipView.SelectedItem as KennisClip;
        if (gekozenKennisClip != null)
        {
            Navigation.PushAsync(new KennisClipContentPage(gekozenKennisClip, healthAppDatabase, klantToken));
        }
        KennisClipView.SelectedItem = null;
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