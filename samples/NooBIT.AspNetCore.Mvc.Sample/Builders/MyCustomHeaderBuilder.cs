using NooBIT.AspNetCore.Mvc.Http;

namespace NooBIT.AspNetCore.Mvc.Builders
{
    public class MyCustomHeaderBuilder : IHeaderBuilder
    {
        private string _value;

        public MyCustomHeaderBuilder WithValue(string value)
        {
            _value = value;
            return this;
        }

        public Header Build() => new MyCustomHeader(_value);
    }

    public class MyCustomHeader : Header
    {
        public MyCustomHeader(string value) : base("X-My-Custom-Header")
        {
            Value = value;
        }
    }
}