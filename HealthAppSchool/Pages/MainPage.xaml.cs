﻿using HealthAppSchool.Data;
using HealthAppSchool.Models;
using HealthAppSchool.Pages;

namespace HealthAppSchool
{
    public partial class MainPage : ContentPage
    {


        private readonly HealthAppDatabase healthAppDatabase;


        public MainPage(HealthAppDatabase dataBase)
        {
            InitializeComponent();
            healthAppDatabase = dataBase;
            
            KlantToken klantToken = healthAppDatabase.GetKlantToken();
            
            if (klantToken != null) 
            {
                try { InlogProcedureKlantToken(klantToken); }
                catch (Exception ex) 
                {
                    DisplayAlert("Tokeninlogerror", $"Je token klopt niet. {ex.Message}", "ok");
                    healthAppDatabase.DeleteKlantToken(klantToken);
                }
            }
        }

        private async void InlogButton_Clicked(object sender, EventArgs e)
        {
            try 
            {
                if (EmailInput.Text != null && WachtwoordInput.Text != null)
                {
                    Klant inlogKlant = await healthAppDatabase.GetKlantOnEmail(EmailInput.Text);

                    if (inlogKlant.Email == null) { await DisplayAlert("Verkeerd email", "Het email dat is ingevuld bestaat niet.", "ok"); }
                    else if (inlogKlant.WachtWoord == HashMaker.ToSHA512(WachtwoordInput.Text))
                    {
                        healthAppDatabase.CreateKlantToken(inlogKlant, HashMaker.ToSHA512(WachtwoordInput.Text));
                        KlantToken klantToken2 = healthAppDatabase.GetKlantToken();
                        await Navigation.PushAsync(new CenterPage(healthAppDatabase, klantToken2));
                    }
                    else { await DisplayAlert("Verkeerd wachtwoord", "Het wachtwoord dat is ingevuld klopt niet.", "ok"); }
                }
                else { await DisplayAlert("Velden leeg", "Niet alle velden zijn ingevuld.", "ok"); }
            }
            catch (Exception excep) 
            { await DisplayAlert("Inlogerror", $"{excep}", "ok");  }
        }
        protected override void OnNavigatedTo(NavigatedToEventArgs e)
        {
            base.OnNavigatedTo(e);
            WachtwoordInput.Text = string.Empty;
            EmailInput.Text = string.Empty;
        }

        private async void RegistreerButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AanmeldPage(healthAppDatabase));
        }
        private async void InlogProcedureKlantToken(KlantToken klantToken)
        {
            Klant inlogKlant = await healthAppDatabase.GetKlantOnEmail(klantToken.KlantEmail);

            if (inlogKlant.Email == null) { await DisplayAlert("Verkeerd email", "Het email dat is ingevuld bestaat niet.", "ok"); }
            else if (inlogKlant.WachtWoord == klantToken.KlantWachtwoord)
            {

                await Navigation.PushAsync(new CenterPage(healthAppDatabase, klantToken));
            }
            else { await DisplayAlert("Verkeerd wachtwoord", "Het wachtwoord dat is ingevuld klopt niet.", "ok"); }
        }
    }
}
