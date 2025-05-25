namespace RapidApiProject.Models
{
    public class SkorViewModel
    {

        public class Rootobject
        {
            public string status { get; set; }
            public Response response { get; set; }
        }

        public class Response
        {
            public Live[] live { get; set; }
        }

        public class Live
        {
            public int id { get; set; }
            public int leagueId { get; set; }
            public string time { get; set; }
            public Home home { get; set; }
            public Away away { get; set; }
            public object eliminatedTeamId { get; set; }
            public int statusId { get; set; }
            public string tournamentStage { get; set; }
            public Status status { get; set; }
            public long timeTS { get; set; }
        }

        public class Home
        {
            public int id { get; set; }
            public int score { get; set; }
            public string name { get; set; }
            public string longName { get; set; }
            public int redCards { get; set; }
        }

        public class Away
        {
            public int id { get; set; }
            public int score { get; set; }
            public string name { get; set; }
            public string longName { get; set; }
        }

        public class Status
        {
            public DateTime utcTime { get; set; }
            public Halfs halfs { get; set; }
            public int periodLength { get; set; }
            public bool finished { get; set; }
            public bool started { get; set; }
            public bool cancelled { get; set; }
            public bool ongoing { get; set; }
            public string scoreStr { get; set; }
            public Livetime liveTime { get; set; }
            public int numberOfHomeRedCards { get; set; }
            public string aggregatedStr { get; set; }
        }

        public class Halfs
        {
            public string firstHalfStarted { get; set; }
            public string secondHalfStarted { get; set; }
        }

        public class Livetime
        {
            public string _short { get; set; }
            public string shortKey { get; set; }
            public string _long { get; set; }
            public string longKey { get; set; }
            public int maxTime { get; set; }
            public int addedTime { get; set; }
        }


    }
}
