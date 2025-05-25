using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models;
using System.Net.Http.Headers;

namespace RapidApiProject.Controllers
{
    public class RapidApiController : Controller
    {
        private readonly HttpClient _client;

        public RapidApiController()
        {
            // HttpClient'ı controller seviyesinde tek örnek oluşturuyoruz.
            _client = new HttpClient();
            // İstersen buraya ortak header vs. ekleyebilirsin.
        }

        private async Task<string> SendRapidApiRequestAsync(string url, string apiKey, string apiHost)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("x-rapidapi-key", apiKey);
            request.Headers.Add("x-rapidapi-host", apiHost);

            var response = await _client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                // 429 ise null dönebilir veya özel hata fırlatabilirsin.
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<IActionResult> Index()
        {
            string apiKey = "20f4234472msh6f1aa5d52c53782p16454fjsnf3b656456ff4";
            string apiKey2 = "eed6237973msh2839233a7017623p1ad329jsn370334d60c3e";

        //    1) EUR - TRY
            var body = await SendRapidApiRequestAsync(
                "https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&to_symbol=TRY&language=en",
                apiKey2, "real-time-finance-data.p.rapidapi.com");

            if (body != null)
            {
                var value = JsonConvert.DeserializeObject<ExchangeEUR_TRYViewModel.Rootobject>(body);
                ViewBag.ExchangeRate = value?.data?.exchange_rate;
            }
            else
            {
                ViewBag.ExchangeRateError = "EUR-TRY API istek limiti aşıldı.";
            }

            await Task.Delay(1000); // 1 sn bekle

            // 2) USD-TRY
            body = await SendRapidApiRequestAsync(
                "https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en",
                apiKey2, "real-time-finance-data.p.rapidapi.com");

            if (body != null)
            {
                var value = JsonConvert.DeserializeObject<ExchangeUSD_TRYViewModel.Rootobject>(body);
                ViewBag.USD = value?.data?.exchange_rate;
            }
            else
            {
                ViewBag.USDError = "USD-TRY API istek limiti aşıldı.";
            }

            await Task.Delay(1000);

            // 3) GBP-TRY
            body = await SendRapidApiRequestAsync(
                "https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=GBP&to_symbol=TRY&language=en",
                apiKey2, "real-time-finance-data.p.rapidapi.com");

            if (body != null)
            {
                var value = JsonConvert.DeserializeObject<ExchangeGBP_TRYViewModel.Rootobject>(body);
                ViewBag.GBP = value?.data?.exchange_rate;
            }
            else
            {
                ViewBag.GBPError = "GBP-TRY API istek limiti aşıldı.";
            }

            await Task.Delay(1000);

            // 4) Akaryakıt İstanbul
            body = await SendRapidApiRequestAsync(
                "https://akaryakit-fiyatlari.p.rapidapi.com/fuel/istanbul",
                apiKey2, "akaryakit-fiyatlari.p.rapidapi.com");

            if (body != null)
            {
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
            else
            {
                ViewBag.FuelError = "Akaryakıt API istek limiti aşıldı.";
            }

            await Task.Delay(1000);

            // 5) Hava Durumu
            body = await SendRapidApiRequestAsync(
                "https://easy-weather1.p.rapidapi.com/daily/5?latitude=40.879326&longitude=29.258135",
                apiKey2, "easy-weather1.p.rapidapi.com");

            if (body != null)
            {
                var havaDurumu = JsonConvert.DeserializeObject<HavaDurumuViewModel.Rootobject>(body);
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
            else
            {
                ViewBag.WeatherError = "Hava durumu API istek limiti aşıldı.";
            }

            await Task.Delay(1000);

            // 6) Kripto Para
            body = await SendRapidApiRequestAsync(
                "https://coinranking1.p.rapidapi.com/coins?referenceCurrencyUuid=yhjMzLPhuIDl&timePeriod=24h&orderBy=marketCap&orderDirection=desc&limit=5&offset=0",
                apiKey, "coinranking1.p.rapidapi.com");

            if (body != null)
            {
                var result = JsonConvert.DeserializeObject<KriptoViewModel.Rootobject>(body);
                ViewBag.CoinList = result?.data?.coins;
            }
            else
            {
                ViewBag.CryptoError = "Kripto para API istek limiti aşıldı.";
            }



            // Yemek tarifi
            await Task.Delay(1000);

            body = await SendRapidApiRequestAsync(
              "https://recipes-api3.p.rapidapi.com/rapidapi/recipes/?type=get-recipe&id=25",
              apiKey, "recipes-api3.p.rapidapi.com");


            var root2 = JsonConvert.DeserializeObject<TarifViewModel>(body);

            if (root2 != null && root2.data != null)
            {
                var result = root2.data;
                ViewBag.Category = result.category;
                ViewBag.Title = result.title;
                ViewBag.Acıklama = result.description;  // açıklama description alanında
                ViewBag.malzemeler = result.ingredients;
                ViewBag.Tarif = result.instructions;
                ViewBag.hazirlamavakti = result.prep_time_minutes;
                ViewBag.Pisirmevakti = result.cook_time_minutes;
                ViewBag.ToplamSüre = result.total_time_minutes;
                ViewBag.ToplamKalori = result.calories_per_serving;
                ViewBag.KisiSayısı = result.servings;
            }
            else
            {
                ViewBag.TarifError = "Yemek tarifi verisi alınamadı.";
            }



            // Haberler için API çağrısı ve veri işleme
            await Task.Delay(1000);

          body = await SendRapidApiRequestAsync(
                "https://news-api14.p.rapidapi.com/v2/trendings?topic=General&language=en",
                apiKey, "news-api14.p.rapidapi.com");

          
            var news = JsonConvert.DeserializeObject<HaberVievModel>(body);

            if (news?.data != null && news.data.Length > 0)
            {
                
                var firstFive = news.data.Take(5).ToList();

                // ViewBag içinde liste olarak saklayalım (örneğin anonymous tip)
                ViewBag.NewsList = firstFive.Select(h => new
                {
                    h.title,
                    h.url,
                    h.excerpt,
                    h.thumbnail,
                    date = h.date.ToString("g") // tarih formatı isteğe bağlı
                }).ToList();
            }
            else
            {
                ViewBag.NewsList = new List<object>();
                ViewBag.Error = "Haber verisi alınamadı veya boş.";
            }



            //Skor bilgileri


            await Task.Delay(1000);

            body = await SendRapidApiRequestAsync(
                  "https://free-api-live-football-data.p.rapidapi.com/football-current-live",
                  apiKey, "free-api-live-football-data.p.rapidapi.com");


            var score = JsonConvert.DeserializeObject<SkorViewModel.Rootobject>(body);

           // İlk 6 canlı maçı al
                var first6Matches = score.response.live.Take(6).ToList();

                // ViewBag'e maç detaylarını ata
                ViewBag.LiveMatches = first6Matches.Select(match => new
                {
                    MatchId = match.id,
                    LeagueId = match.leagueId,
                    Time = match.time,
                    HomeTeamName = match.home.name,
                    HomeTeamScore = match.home.score,
                 
                    AwayTeamName = match.away.name,
                    AwayTeamScore = match.away.score,
                    Status = match.status.scoreStr,
                    LiveTime = match.status.liveTime?._short,
                    TournamentStage = match.tournamentStage
                }).ToList();



                return View();

        }
    }
}
