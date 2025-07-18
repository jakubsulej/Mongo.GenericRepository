namespace Caching.Client.Abstractions;

public interface ICachingClient<TCache> : ICacheClient where TCache : ICacheClient;
