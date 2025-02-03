using HealthAppSchool.Data;
using HealthAppSchool.Models;
using Microcharts;
using Microcharts.Maui;
using System.Collections.ObjectModel;
using SkiaSharp;

namespace HealthAppSchool.Pages;

public partial class FysiekeActiviteitPage : ContentPage
{

    HealthAppDatabase healthAppDatabase;
    KlantToken klantToken { get; set; }
    List<ChartEntry> entries1 { get; set; }
    List<ChartEntry> entries2 { get; set; }
    List<ChartEntry> entries3 { get; set; }
    List<string> activiteitenList { get; set; }
    DateOnly minDate { get; set; }
    DateOnly maxDate { get; set; }
    string activiteitGeslecteerd { get; set; }
    DictionaryMaker dictionaryMaker { get; set; }
    ObservableCollection<FysiekeActiviteit> deleteList {  get; set; }
    public FysiekeActiviteitPage(HealthAppDatabase dataBase, KlantToken _klantToken)
    {
        klantToken = _klantToken;
        healthAppDatabase = dataBase;
        InitializeComponent();

        dictionaryMaker = new DictionaryMaker();

        minDate = new DateOnly();
        minDate = DateOnly.FromDateTime(MinDatePicker.Date);
        maxDate = new DateOnly();
        maxDate = DateOnly.MaxValue;
        activiteitenList = new List<string>() { "geen filter", "Rennen", "Zwemmen", "Fietsen" };
        
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs e)
    {
        base.OnNavigatedTo(e);
        activiteitGeslecteerd = "geen filter";
        ActiviteitPicker.ItemsSource = activiteitenList;
        prepChart1();
        prepChart2();
        prepChart3();
        
    }
    public async void prepChart1()
    {
        try
        {
            deleteList = new ObservableCollection<FysiekeActiviteit>();
            int barCount;
            List<FysiekeActiviteit> activ = await healthAppDatabase.GetFysiekeActiviteitenOnKlant(klantToken.KlantId);
            entries1 = new List<ChartEntry>();// Ik weet dat we geleerd hebben gekregen observable, maar dit werkt?
            foreach (FysiekeActiviteit fys in activ)
            {
                if (fys.Datum <= maxDate && fys.Datum >= minDate)
                {
                    if(activiteitGeslecteerd != "geen filter") //Een hoop ifs. Maar ik heb liever dat er geen null voor problemen zorgt.
                    { if(activiteitGeslecteerd == fys.SoortActiviteit) 
                        {
                            string colorswitcher = "";
                            switch (fys.SoortActiviteit)
                            {
                                case "Rennen":
                                    colorswitcher = "#2c3e50";
                                    break;
                                case "Zwemmen":
                                    colorswitcher = "#3498db";
                                    break;
                                case "Fietsen":
                                    colorswitcher = "#2ecc71";
                                    break;
                                default:
                                    colorswitcher = "#17202a";
                                    break;
                            }
                            deleteList.Add(fys);
                            entries1.Add(new ChartEntry(fys.DuurMinuten)
                            {
                                Label = $"{fys.Datum + " " + fys.SoortActiviteit}",
                                ValueLabel = $"{fys.DuurMinuten} minuten",
                                Color = SKColor.Parse($"{colorswitcher}"),
                                
                            });
                        } 
                    }
                    else 
                    {
                        string colorswitcher = "";
                        switch (fys.SoortActiviteit)
                        {
                            case "Rennen":
                                colorswitcher = "#2c3e50";
                                break;
                            case "Zwemmen":
                                colorswitcher = "#3498db";
                                break;
                            case "Fietsen":
                                colorswitcher = "#2ecc71";
                                break;
                            default:
                                colorswitcher = "#17202a";
                                break;
                        }
                        deleteList.Add(fys);
                        entries1.Add(new ChartEntry(fys.DuurMinuten)
                        {
                            Label = $"{fys.Datum + " " + fys.SoortActiviteit}",
                            ValueLabel = $"{fys.DuurMinuten} minuten",
                            Color = SKColor.Parse($"{colorswitcher}")
                        });
                    }
                }
            }
            var chart = new BarChart()
            {
                Entries = entries1,
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal
            };
            chartView.Chart = chart;
            deleteListView.ItemsSource = deleteList;
            chartView.WidthRequest = (200 * chart.Entries.Count());
            deleteListView.WidthRequest = (200 * chart.Entries.Count());
        }
        catch (Exception ex) { await DisplayAlert("Error", $"er is iets misgegaan.{ex}", "ok"); }
    }


    public async void prepChart2()
    {
        try
        {
            var fysiekdictionary = await dictionaryMaker.FysiekeActiviteitenDictionary(healthAppDatabase, klantToken.KlantId);
            entries2 = new List<ChartEntry>();
            List<DateOnly> outerKeys = fysiekdictionary.Keys.ToList();
            foreach (DateOnly outerKey in outerKeys)
            {
                string colorswitcher = "";
                var innerKeys = fysiekdictionary[outerKey].Keys.ToList();
                foreach (string innerKey in innerKeys)
                {
                    {
                        switch (innerKey)
                        {
                            case "Rennen":
                                colorswitcher = "#2c3e50";
                                break;
                            case "Zwemmen":
                                colorswitcher = "#3498db";
                                break;
                            case "Fietsen":
                                colorswitcher = "#2ecc71";
                                break;
                            default:
                                colorswitcher = "#17202a";
                                break;
                        }
                        entries2.Add(new ChartEntry(fysiekdictionary[outerKey][innerKey])
                        {
                            Label = $"{outerKey + " " + innerKey}",
                            ValueLabel = $"{fysiekdictionary[outerKey][innerKey]} minuten",
                            Color = SKColor.Parse($"{colorswitcher}"),
                        }
                        );
                    }
                }
            }
            var chart2 = new BarChart()
            {
                Entries = entries2,
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal
            };
            chartDictView.Chart = chart2;
        }
        catch (Exception ex) { await DisplayAlert("Error", $"er is iets misgegaan.{ex}", "ok"); }
    }
    public async void prepChart3()
    {
        try
        {
            var fysiekdictionary = await dictionaryMaker.FysiekeActiviteitenDictionary(healthAppDatabase, klantToken.KlantId);
            entries3 = new List<ChartEntry>();
            List<DateOnly> outerKeys = fysiekdictionary.Keys.ToList();
            foreach (DateOnly outerKey in outerKeys)
            {
                string colorswitcher = "";
                var innerKeys = fysiekdictionary[outerKey].Keys.ToList();
                foreach (string innerKey in innerKeys)
                {
                    if (fysiekdictionary[outerKey][innerKey] != 0)
                    {
                        switch (innerKey)
                        {
                            case "Rennen":
                                colorswitcher = "#2c3e50";
                                break;
                            case "Zwemmen":
                                colorswitcher = "#3498db";
                                break;
                            case "Fietsen":
                                colorswitcher = "#2ecc71";
                                break;
                            default:
                                colorswitcher = "#17202a";
                                break;
                        }

                        entries3.Add(new ChartEntry(fysiekdictionary[outerKey][innerKey])
                        {
                            Label = $"{outerKey + " " + innerKey}",
                            ValueLabel = $"{fysiekdictionary[outerKey][innerKey]} minuten",
                            Color = SKColor.Parse($"{colorswitcher}"),
                        }
                        );
                    }
                }
            }
            var chart3 = new BarChart()
            {
                Entries = entries3,
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal
            };
            chartDict2View.Chart = chart3;
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

    private void MaxDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        
        maxDate = DateOnly.FromDateTime(MaxDatePicker.Date);
        prepChart1();
    }

    private void MinDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        minDate = DateOnly.FromDateTime(MinDatePicker.Date);
        prepChart1();
    }

    private void ActiviteitPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        activiteitGeslecteerd = ActiviteitPicker.SelectedItem.ToString();
        prepChart1();
    }

    private async void deleteListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        FysiekeActiviteit deleteActiviteit = deleteListView.SelectedItem as FysiekeActiviteit;
        if (await DisplayAlert("delete gegeven","Weet u zeker dat u deze gegeven wilt deleten", "yes", "no")) 
        {
            try
            {
                healthAppDatabase.DeleteFysiekeActiviteit(deleteActiviteit);
                prepChart1();
            }
            catch (Exception ex) { await DisplayAlert("error", $"er is iets misgegaan.{ex}", "ok"); }
        }
        
    }
}