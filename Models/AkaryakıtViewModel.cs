namespace RapidApiProject.Models
{
    public class AkaryakıtViewModel
    {

        public class Rootobject
        {
            public string status { get; set; }
            public string message { get; set; }
            public Datum[] data { get; set; }
        }

        public class Datum
        {
            public string district { get; set; }
            public Price[] prices { get; set; }
        }

        public class Price
        {
            public string dagitici_firma { get; set; }
            public string benzin { get; set; }
            public string motorin { get; set; }
            public string lpg { get; set; }
            public string guncellenme_tarihi { get; set; }
        }

    }
}
