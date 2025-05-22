namespace RapidApiProject.Models
{
    public class HavaDurumuViewModel
    {

        public class Rootobject
        {
            public string resource { get; set; }
            public Parameters parameters { get; set; }
            public Forecastdaily forecastDaily { get; set; }
        }

        public class Parameters
        {
            public string latitude { get; set; }
            public string longitude { get; set; }
        }

        public class Forecastdaily
        {
            public DateTime reportedTime { get; set; }
            public DateTime readTime { get; set; }
            public Day[] days { get; set; }
        }

         public class Day
        {
            public DateTime forecastStart { get; set; }
            public DateTime forecastEnd { get; set; }
            public string conditionCode { get; set; }
            public int maxUvIndex { get; set; }
            public double temperatureMax { get; set; }
            public double temperatureMin { get; set; }
            public double precipitationChance { get; set; }
            public string precipitationType { get; set; }
            public double precipitationAmount { get; set; }
            //public double snowfallAmount { get; set; }  // Burada değişiklik yaptık
            public Daytimeforecast daytimeForecast { get; set; }
            public Overnightforecast overnightForecast { get; set; }
        }


        public class Daytimeforecast
        {
            public DateTime forecastStart { get; set; }
            public DateTime forecastEnd { get; set; }
            public float cloudCover { get; set; }
            public string conditionCode { get; set; }
            public float humidity { get; set; }
            public float precipitationChance { get; set; }
            public string precipitationType { get; set; }
            public float precipitationAmount { get; set; }
            //public int snowfallAmount { get; set; }
            public int windDirection { get; set; }
            public float windSpeed { get; set; }
        }

        public class Overnightforecast
        {
            public DateTime forecastStart { get; set; }
            public DateTime forecastEnd { get; set; }
            public float cloudCover { get; set; }
            public string conditionCode { get; set; }
            public float humidity { get; set; }
            public float precipitationChance { get; set; }
            public string precipitationType { get; set; }
            public float precipitationAmount { get; set; }
            //public int snowfallAmount { get; set; }
            public int windDirection { get; set; }
            public float windSpeed { get; set; }
        }

    }
}
