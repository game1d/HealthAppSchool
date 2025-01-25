using HealthAppSchool.Data;
using HealthAppSchool.Models;

namespace HealthAppSchool.Pages;

public partial class StressManagementPage : ContentPage
{
    HealthAppDatabase healthAppDatabase;
    public StressManagementPage(HealthAppDatabase dataBase)
	{
        healthAppDatabase = dataBase;
        InitializeComponent();
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
        Navigation.PushAsync(new StressManagementContentPage(gekozenStressmanagementClip));
    }
}