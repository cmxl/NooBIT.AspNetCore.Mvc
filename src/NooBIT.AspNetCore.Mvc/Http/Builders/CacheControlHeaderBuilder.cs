using System.Collections.Generic;
using NooBIT.AspNetCore.Mvc.Http.Headers;

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

        public IHeaderBuilder Public()
        {
            return Add(CacheControlHeader.Public);
        }

        public IHeaderBuilder Private()
        {
            return Add(CacheControlHeader.Private);
        }

        public IHeaderBuilder NoCache()
        {
            return Add(CacheControlHeader.NoCache);
        }

        public IHeaderBuilder OnlyIfCached()
        {
            return Add(CacheControlHeader.OnlyIfCached);
        }

        public IHeaderBuilder MustRevalidate()
        {
            return Add(CacheControlHeader.MustRevalidate);
        }

        public IHeaderBuilder ProxyRevalidate()
        {
            return Add(CacheControlHeader.ProxyRevalidate);
        }

        public IHeaderBuilder Immutable()
        {
            return Add(CacheControlHeader.Immutable);
        }

        public IHeaderBuilder NoStore()
        {
            return Add(CacheControlHeader.NoStore);
        }

        public IHeaderBuilder NoTransform()
        {
            return Add(CacheControlHeader.NoTransform);
        }

        public IHeaderBuilder MaxAge(int seconds)
        {
            return Add(string.Format(CacheControlHeader.MaxAge, seconds));
        }

        public IHeaderBuilder SMaxAge(int seconds)
        {
            return Add(string.Format(CacheControlHeader.SMaxAge, seconds));
        }

        public IHeaderBuilder MaxStale(int? seconds)
        {
            return Add(string.Format(CacheControlHeader.MaxStale, seconds.HasValue ? seconds.Value.ToString() : ""));
        }

        public IHeaderBuilder MinFresh(int seconds)
        {
            return Add(string.Format(CacheControlHeader.MinFresh, seconds));
        }

        public IHeaderBuilder StaleWhileRevalidate(int seconds)
        {
            return Add(string.Format(CacheControlHeader.StaleWhileRevalidate, seconds));
        }

        public IHeaderBuilder StaleIfError(int seconds)
        {
            return Add(string.Format(CacheControlHeader.StaleIfError, seconds));
        }

        private IHeaderBuilder Add(string value)
        {
            if (!_values.Contains(value))
                _values.Add(value);

            return this;
        }
    }
}