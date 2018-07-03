namespace NooBIT.Web.Security.ContentSecurityPolicy.Sources
{
    public class Source
    {
        public static Source None => new Source("'none'");
        public static Source Self => new Source("'self'");
        public static Source UnsafeInline => new Source("'unsafe-inline'");
        public static Source UnsafeEval => new Source("'unsafe-eval'");
        public static Source StrictDynamic => new Source("'strict-dynamic'");
        public static Source UnsafeHashedAttributes => new Source("'unsafe-hashed-attributes'");
        
        internal Source()
        {
        }

        internal Source(string value)
        {
            Value = value;
        }

        protected internal string Value { get; }

        public override string ToString()
        {
            return Value;
        }
    }
}