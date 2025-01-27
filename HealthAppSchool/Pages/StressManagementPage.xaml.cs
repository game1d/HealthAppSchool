using HealthAppSchool.Data;
using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class StressManagementPage : ContentPage
{
    HealthAppDatabase healthAppDatabase { get; set; }
    KlantToken klantToken { get; set; }
    public StressManagementPage(HealthAppDatabase dataBase, KlantToken _klantToken)
	{
        healthAppDatabase = dataBase;
        InitializeComponent();
        klantToken = _klantToken;
	}
    protected override async void OnNavigatedTo(NavigatedToEventArgs e)
    {
        base.OnNavigatedTo(e);
        var items = await healthAppDatabase.GetStressManagement();

        StressmanagementClipView.ItemsSource = items;

    }

    private void StressmanagementClipView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var gekozenStressmanagementClip = StressmanagementClipView.SelectedItem as StressManagement;
        if (gekozenStressmanagementClip != null) 
        { Navigation.PushAsync(new StressManagementContentPage(gekozenStressmanagementClip, healthAppDatabase, klantToken)); }
        StressmanagementClipView.SelectedItem = null;
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