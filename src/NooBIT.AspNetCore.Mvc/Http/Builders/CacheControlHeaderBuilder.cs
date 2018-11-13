using NooBIT.AspNetCore.Mvc.Http.Headers;
using System.Collections.Generic;

namespace NooBIT.AspNetCore.Mvc.Http.Builders
{
    public class CacheControlHeaderBuilder : IHeaderBuilder
    {
        private readonly HashSet<string> _values = new HashSet<string>();

        public Header Build()
        {
            var header = Header.CacheControl;
            header.Value = string.Join(", ", _values);
            return header;
        }

        public IHeaderBuilder Public() => Add(CacheControlHeader.Public);

        public IHeaderBuilder Private() => Add(CacheControlHeader.Private);

        public IHeaderBuilder NoCache() => Add(CacheControlHeader.NoCache);

        public IHeaderBuilder OnlyIfCached() => Add(CacheControlHeader.OnlyIfCached);

        public IHeaderBuilder MustRevalidate() => Add(CacheControlHeader.MustRevalidate);

        public IHeaderBuilder ProxyRevalidate() => Add(CacheControlHeader.ProxyRevalidate);

        public IHeaderBuilder Immutable() => Add(CacheControlHeader.Immutable);

        public IHeaderBuilder NoStore() => Add(CacheControlHeader.NoStore);

        public IHeaderBuilder NoTransform() => Add(CacheControlHeader.NoTransform);

        public IHeaderBuilder MaxAge(int seconds) => Add(string.Format(CacheControlHeader.MaxAge, seconds));

        public IHeaderBuilder SMaxAge(int seconds) => Add(string.Format(CacheControlHeader.SMaxAge, seconds));

        public IHeaderBuilder MaxStale(int? seconds) => Add(string.Format(CacheControlHeader.MaxStale, seconds.HasValue ? seconds.Value.ToString() : ""));

        public IHeaderBuilder MinFresh(int seconds) => Add(string.Format(CacheControlHeader.MinFresh, seconds));

        public IHeaderBuilder StaleWhileRevalidate(int seconds) => Add(string.Format(CacheControlHeader.StaleWhileRevalidate, seconds));

        public IHeaderBuilder StaleIfError(int seconds) => Add(string.Format(CacheControlHeader.StaleIfError, seconds));

        private IHeaderBuilder Add(string value)
        {
            if (!_values.Contains(value))
                _values.Add(value);

            return this;
        }
    }
}