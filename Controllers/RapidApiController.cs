using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using RapidApiProject.Models;
using RapidApiProject.Views;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using ExchangeEUR_TRYViewModel = RapidApiProject.Models.ExchangeEUR_TRYViewModel;

namespace RapidApiProject.Controllers
{
    public class RapidApiController : Controller
    {
        public async Task<IActionResult> Index()
        {

         
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&to_symbol=TRY&language=en"),
                Headers =
    {
        { "x-rapidapi-key", "20f4234472msh6f1aa5d52c53782p16454fjsnf3b656456ff4" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ExchangeEUR_TRYViewModel.Rootobject>(body);
                ViewBag.ExchangeRate = value.data.exchange_rate;



            }

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en"),
                Headers =
    {
        { "x-rapidapi-key", "20f4234472msh6f1aa5d52c53782p16454fjsnf3b656456ff4" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client2.SendAsync(request2))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ExchangeUSD_TRYViewModel.Rootobject>(body);
                ViewBag.USD = value.data.exchange_rate;
            }


            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=GBP&to_symbol=TRY&language=en"),
                Headers =
    {
        { "x-rapidapi-key", "20f4234472msh6f1aa5d52c53782p16454fjsnf3b656456ff4" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client3.SendAsync(request3))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ExchangeGBP_TRYViewModel.Rootobject>(body);
                ViewBag.GBP = value.data.exchange_rate;
            }


            var client4 = new HttpClient();
            var request4 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://akaryakit-fiyatlari.p.rapidapi.com/fuel/istanbul"),
                Headers =
    {
        { "x-rapidapi-key", "20f4234472msh6f1aa5d52c53782p16454fjsnf3b656456ff4" },
        { "x-rapidapi-host", "akaryakit-fiyatlari.p.rapidapi.com" },
    },
            };
            using (var response = await client4.SendAsync(request4))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<AkaryakıtViewModel.Rootobject>(body);

                var firstTwoPrices = root?.data?.FirstOrDefault()?.prices?.Take(2).ToList();

                if (firstTwoPrices != null && firstTwoPrices.Count >= 2)
                {
                    var firma1 = firstTwoPrices[0];
                    var firma2 = firstTwoPrices[1];

                    ViewBag.Firma1 = firma1.dagitici_firma;
                    ViewBag.Benzin1 = firma1.benzin;
                    ViewBag.Motorin1 = firma1.motorin;
                    ViewBag.LPG1 = firma1.lpg;

                    ViewBag.Firma2 = firma2.dagitici_firma;
                    ViewBag.Benzin2 = firma2.benzin;
                    ViewBag.Motorin2 = firma2.motorin;
                    ViewBag.LPG2 = firma2.lpg;
                }



            }


            var client5 = new HttpClient();
            var request5 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://easy-weather1.p.rapidapi.com/daily/5?latitude=40.879326&longitude=29.258135"),
                Headers =
    {
        { "x-rapidapi-key", "20f4234472msh6f1aa5d52c53782p16454fjsnf3b656456ff4" },
        { "x-rapidapi-host", "easy-weather1.p.rapidapi.com" },
    },
            };
            using (var response = await client5.SendAsync(request5))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // JSON'u modeli deserialize et
                var havaDurumu = JsonConvert.DeserializeObject<HavaDurumuViewModel.Rootobject>(body);

                // İlk günün hava durumu bilgilerini ViewBag'e at
                if (havaDurumu?.forecastDaily?.days != null && havaDurumu.forecastDaily.days.Length > 0)
                {
                    var bugun = havaDurumu.forecastDaily.days[0];

                    ViewBag.Tarih = bugun.forecastStart.ToString("dd.MM.yyyy");
                  
                    ViewBag.EnYuksekSicaklik = bugun.temperatureMax;
                    ViewBag.EnDusukSicaklik = bugun.temperatureMin;
                    ViewBag.YagisIhtimali = bugun.precipitationChance;
                    ViewBag.RuzgarHizi = bugun.daytimeForecast.windSpeed;
                    ViewBag.Nem = bugun.daytimeForecast.humidity;
                }
                else
                {
                    ViewBag.Mesaj = "Hava durumu verisi alınamadı.";
                }
            }


            return View();
        }
    }
}
