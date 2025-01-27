using HealthAppSchool.Data;
using HealthAppSchool.Models;
using Microcharts;
using Microcharts.Maui;
using SkiaSharp;

namespace HealthAppSchool.Pages;

public partial class VerbrandeCalorienPage : ContentPage
{
    HealthAppDatabase healthAppDatabase;
    KlantToken klantToken { get; set; }
    List<ChartEntry> entries1 { get; set; }

    public VerbrandeCalorienPage(HealthAppDatabase dataBase, KlantToken _klantToken)
	{
		InitializeComponent();
        healthAppDatabase = dataBase;
        klantToken = _klantToken;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs e)
    {
        base.OnNavigatedTo(e);

        prepChart1();

    }
    public async void prepChart1()
    {
        try {
            List<FysiekeActiviteit> activ = await healthAppDatabase.GetFysiekeActiviteitenOnKlant(klantToken.KlantId);
            entries1 = new List<ChartEntry>();
            foreach (FysiekeActiviteit fys in activ)
            {
                string colorswitcher = "";
                int caloriënverbrand = 0;
                int gewicht = 75;
                switch (fys.SoortActiviteit)
                {
                    case "Rennen":
                        colorswitcher = "#2c3e50";
                        caloriënverbrand = ((fys.DuurMinuten * gewicht * 7) / 60);
                        break;
                    case "Zwemmen":
                        colorswitcher = "#3498db";
                        caloriënverbrand = ((fys.DuurMinuten * gewicht * 6) / 60);
                        break;
                    case "Fietsen":
                        colorswitcher = "#2ecc71";
                        caloriënverbrand = ((fys.DuurMinuten * gewicht * 4) / 60);
                        break;
                    default:
                        colorswitcher = "#17202a";
                        caloriënverbrand = ((fys.DuurMinuten * gewicht * 1) / 60);
                        break;
                }

                entries1.Add(new ChartEntry(caloriënverbrand)
                {
                    Label = $"{fys.Datum + " " + fys.SoortActiviteit}",
                    ValueLabel = $"{caloriënverbrand} caloriën",
                    Color = SKColor.Parse($"{colorswitcher}")
                }
            );
            }
            var chart = new BarChart()
            {
                Entries = entries1,
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal
            };
            chartView.Chart = chart;
        }
        

        catch (Exception ex) { await DisplayAlert("Error", $"er is iets misgegaan.{ex}", "ok"); }
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