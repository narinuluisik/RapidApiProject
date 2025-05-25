namespace RapidApiProject.Models
{
    public class HaberVievModel
    {

                  

          public class Rootobject
        {

        }
            public Datum[] data { get; set; }
      

        public class Datum
        {
            public string title { get; set; }
            public string url { get; set; }
            public string excerpt { get; set; }
            public string thumbnail { get; set; }
            public string language { get; set; }
            public bool paywall { get; set; }
            public int contentLength { get; set; }
            public DateTime date { get; set; }
            public string[] authors { get; set; }
            public string[] keywords { get; set; }
            public Publisher publisher { get; set; }
        }

        public class Publisher
        {
            public string name { get; set; }
            public string url { get; set; }
            public string favicon { get; set; }
        }


    }
}
