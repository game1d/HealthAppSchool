using HealthAppSchool.Data;
using HealthAppSchool.Models;
using Microcharts;
using Microcharts.Maui;
using SkiaSharp;

namespace HealthAppSchool.Pages;

public partial class FysiekeActiviteitPage : ContentPage
{
    HealthAppDatabase healthAppDatabase;
    List<ChartEntry> entries1 { get; set; }
    List<ChartEntry> entries2 { get; set; }
    List<ChartEntry> entries3 { get; set; }
    DictionaryMaker dictionaryMaker { get; set; }
    public FysiekeActiviteitPage(HealthAppDatabase dataBase)
    {
        InitializeComponent();
        healthAppDatabase = dataBase;
        dictionaryMaker = new DictionaryMaker();

    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs e)
    {
        base.OnNavigatedTo(e);

        prepChart1();
        prepChart2();
        prepChart3();
    }
    public async void prepChart1()
    {
        List<FysiekeActiviteit> activ = await healthAppDatabase.GetFysiekeActiviteiten();
        entries1 = new List<ChartEntry>();
        foreach (FysiekeActiviteit fys in activ)
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

            entries1.Add(new ChartEntry(fys.DuurMinuten)
            {
                Label = $"{fys.Datum + " " + fys.SoortActiviteit}",
                ValueLabel = $"{fys.DuurMinuten} minuten",
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


    public async void prepChart2() 
    {
        var fysiekdictionary = await dictionaryMaker.FysiekeActiviteitenDictionary(healthAppDatabase);
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
    public async void prepChart3() 
    {
        var fysiekdictionary = await dictionaryMaker.FysiekeActiviteitenDictionary(healthAppDatabase);
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
}