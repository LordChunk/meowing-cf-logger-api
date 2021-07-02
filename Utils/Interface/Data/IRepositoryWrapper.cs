namespace Interface.Data
{
    public interface IRepositoryWrapper
    {
        IHttpHeaderRepository HttpHeader { get; }
        IHttpRequestRepository HttpRequest { get; }
        IRequestUrlRepository RequestUrl { get; }
        IStatisticsRepository Statistics { get; }
    }
}