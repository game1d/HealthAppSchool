using HealthAppSchool.Data;
using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class KennisClipPage : ContentPage
{
    HealthAppDatabase healthAppDatabase;
    public KennisClipPage(HealthAppDatabase dataBase)
	{
        healthAppDatabase = dataBase;
        InitializeComponent();
		

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
        Navigation.PushAsync(new KennisClipContentPage(gekozenKennisClip));
    }
}