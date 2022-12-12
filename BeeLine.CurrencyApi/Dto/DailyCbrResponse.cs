namespace BeeLine.CurrencyApi.Dto
{
    public class DailyCbrResponse
    {
        public DateTime Date { get; set; }
        public DateTime PreviousDate { get; set; }
        public string PreviousURL { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, CurrencyInfo> Valute { get; set; }
    }
}
