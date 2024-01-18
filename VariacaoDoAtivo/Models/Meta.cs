﻿namespace VariacaoDoAtivo.Models
{
    public class Meta
    {
        public string? currency { get; set; }
        public string? symbol { get; set; }
        public string? exchangeName { get; set; }
        public string? instrumentType { get; set; }
        public int? firstTradeDate { get; set; }
        public int? regularMarketTime { get; set; }
        public int? gmtoffset { get; set; }
        public string? timezone { get; set; }
        public string? exchangeTimezoneName { get; set; }
        public double? regularMarketPrice { get; set; }
        public double? chartPreviousClose { get; set; }
        public double? previousClose { get; set; }
        public int? scale { get; set; }
        public int? priceHint { get; set; }
        public CurrentTradingPeriod? currentTradingPeriod { get; set; }
        //public List<List<string>>? tradingPeriods { get; set; }
        public string? dataGranularity { get; set; }
        public string? range { get; set; }
        public List<string>? validRanges { get; set; }
        public DateTime? Date { get; set; }
    }
}
