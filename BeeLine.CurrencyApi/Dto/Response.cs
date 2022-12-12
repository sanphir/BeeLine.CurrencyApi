namespace BeeLine.CurrencyApi.Dto
{
    public record Response<T>
    {
        public bool IsSuccess { get; init; }
        public string? ErrorMessage { get; init; }
        public T? Data { get; init; }
    }
}
