﻿namespace RapidApiProject.Models
{
    public class KriptoViewModel
    {

        public class Rootobject
        {
            public string status { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public Stats stats { get; set; }
            public Coin[] coins { get; set; }
        }

        public class Stats
        {
            public int total { get; set; }
            public int totalCoins { get; set; }
            public int totalMarkets { get; set; }
            public int totalExchanges { get; set; }
            public string totalMarketCap { get; set; }
            public string total24hVolume { get; set; }
        }

        public class Coin
        {
            public string uuid { get; set; }
            public string symbol { get; set; }
            public string name { get; set; }
            public string color { get; set; }
            public string iconUrl { get; set; }
            public string marketCap { get; set; }
            public string price { get; set; }
            public int listedAt { get; set; }
            public int tier { get; set; }
            public string change { get; set; }
            public int rank { get; set; }
            public string[] sparkline { get; set; }
            public bool lowVolume { get; set; }
            public string coinrankingUrl { get; set; }
            public string _24hVolume { get; set; }
            public string btcPrice { get; set; }
            public string[] contractAddresses { get; set; }
        }

    }
}
