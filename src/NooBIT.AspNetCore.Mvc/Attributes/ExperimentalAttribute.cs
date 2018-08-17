using System;

namespace NooBIT.AspNetCore.Mvc.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Field)]
    public class ExperimentalAttribute : Attribute
    {
    }
}