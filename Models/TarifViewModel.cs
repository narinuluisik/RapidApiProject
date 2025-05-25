namespace RapidApiProject.Models
{
    public class TarifViewModel
    {

        public Data data { get; set; }


        public class Data
        {
            public int id { get; set; }
            public long time_created { get; set; }
            public long last_updated { get; set; }
            public string category { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string ingredients { get; set; }
            public string instructions { get; set; }
            public int prep_time_minutes { get; set; }
            public int cook_time_minutes { get; set; }
            public int total_time_minutes { get; set; }
            public int servings { get; set; }
            public int calories_per_serving { get; set; }
            public string tags { get; set; }
        }

        public class Request
        {
            public int status { get; set; }
            public string endpoint { get; set; }
            public int time { get; set; }
            public float processSpeed { get; set; }
            public object[] note { get; set; }
        }

    }
}
