﻿namespace NooBIT.AspNetCore.Mvc.Http.Headers
{
    public sealed class ReferrerPolicyHeader : Header
    {
        public static readonly string NoReferrer = "no-referrer";
        public static readonly string NoReferrerWhenDowngrade = "no-referrer-when-downgrade";
        public static readonly string Origin = "origin";
        public static readonly string OriginWhenCrossOrigin = "origin-when-cross-origin";
        public static readonly string SameOrigin = "same-origin";
        public static readonly string StrictOrigin = "strict-origin";
        public static readonly string StrictOriginWhenCrossOrigin = "strict-origin-when-cross-origin";
        public static readonly string UnsafeUrl = "unsafe-url";

        internal ReferrerPolicyHeader() : base("Referrer-Policy")
        {
        }
    }
}