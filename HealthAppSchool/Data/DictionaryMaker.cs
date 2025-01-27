using HealthAppSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAppSchool.Data
{
    public  class DictionaryMaker
    {
        // Dit zou gebruikt kunnen worden om meerdere geregistreerde activiteiten bij elkaar op te tellen indien gewenst.
        public async Task<Dictionary<DateOnly,Dictionary<string,int>>> FysiekeActiviteitenDictionary(HealthAppDatabase appDatabase, int klantId)
        {
            var result = new Dictionary<DateOnly, Dictionary<string,int>>();
            List<FysiekeActiviteit> fysiekeActiviteitenLijst = await appDatabase.GetFysiekeActiviteitenOnKlant(klantId);
            List<DateOnly> datumlijst = new List<DateOnly>();
            List<string> activiteitenList = new List<string>() {"Rennen", "Zwemmen", "Fietsen" };
            foreach (FysiekeActiviteit activiteit in fysiekeActiviteitenLijst)
            {
                if (datumlijst.Contains(activiteit.Datum)) 
                {
                    result[activiteit.Datum][activiteit.SoortActiviteit] += activiteit.DuurMinuten;
                }
                else 
                {
                    var nieuwDict = new Dictionary<string, int>();
                    datumlijst.Add(activiteit.Datum);
                    foreach(string key in activiteitenList)
                    {
                        nieuwDict.Add(key, 0);
                    }
                    result.Add(activiteit.Datum, nieuwDict);
                    result[activiteit.Datum][activiteit.SoortActiviteit]=activiteit.DuurMinuten;
                }
            }
            return result;
        }

    }
}
