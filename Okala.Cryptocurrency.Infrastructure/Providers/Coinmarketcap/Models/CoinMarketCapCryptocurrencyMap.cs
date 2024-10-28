namespace Okala.Cryptocurrency.Infrastructure.Providers.Coinmarketcap.Models
{
    public class CoinMarketCapCryptocurrencyMap
    {
        public Status status { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public CryptoType USD { get; set; }
        public CryptoType BTC { get; set; }
        public CryptoType EUR { get; set; }
    }

    public class Status
    {
        public DateTime timestamp { get; set; }
        public int error_code { get; set; }
        public object error_message { get; set; }
        public int elapsed { get; set; }
        public int credit_count { get; set; }
        public object notice { get; set; }
    }


    public class CryptoType
    {
        public DateTime open_timestamp { get; set; }
        public DateTime high_timestamp { get; set; }
        public DateTime low_timestamp { get; set; }
        public DateTime close_timestamp { get; set; }
        public Quote quote { get; set; }
    }

    public class Quote
    {
        public CurrencyType USD { get; set; }
        public CurrencyType EUR { get; set; }
        public CurrencyType BRL { get; set; }
        public CurrencyType GBP { get; set; }
        public CurrencyType AUD { get; set; }
    }

    public class CurrencyType
    {
        public float open { get; set; }
        public DateTime open_timestamp { get; set; }
        public float high { get; set; }
        public DateTime high_timestamp { get; set; }
        public float low { get; set; }
        public DateTime low_timestamp { get; set; }
        public float close { get; set; }
        public DateTime close_timestamp { get; set; }
        public float percent_change { get; set; }
        public float price_change { get; set; }
    }
}
