namespace BeeLine.CurrencyApi.Dto
{
    public record CurrencyInfo
    {
        public string ID { get; init; }
        public string NumCode { get; init; }
        public string CharCode { get; init; }
        public int Nominal { get; init; }
        public string Name { get; init; }
        public double Value { get; init; }
        public double Previous { get; init; }
    }
}
