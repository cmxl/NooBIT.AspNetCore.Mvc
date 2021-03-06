﻿namespace NooBIT.AspNetCore.Mvc.Http.Headers
{
    public sealed class FrameOptionsHeader : Header
    {
        public static readonly string Deny = "DENY";
        public static readonly string SameOrigin = "SAMEORIGIN";
        public static readonly string AllowFrom = "ALLOW-FROM";

        internal FrameOptionsHeader() : base("X-Frame-Options")
        {
        }
    }
}