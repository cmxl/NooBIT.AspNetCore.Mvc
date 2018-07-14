namespace NooBIT.AspNetCore.Mvc.Security.ContentSecurityPolicy.Sources
{
    public class SandboxSource : Source
    {
        public static Source AllowForms => new SandboxSource("allow-forms");
        public static Source AllowModals => new SandboxSource("allow-modals");
        public static Source AllowOrientationLock => new SandboxSource("allow-orientation-lock");
        public static Source AllowPointerLock => new SandboxSource("allow-pointer-lock");
        public static Source AllowPopups => new SandboxSource("allow-popups");
        public static Source AllowPopupsToEscapeSandbox => new SandboxSource("allow-popups-to-escape-sandbox");
        public static Source AllowPresentation => new SandboxSource("allow-presentation");
        public static Source AllowSameOrigin => new SandboxSource("allow-same-origin");
        public static Source AllowScripts => new SandboxSource("allow-scripts");
        public static Source AllowTopNavigation => new SandboxSource("allow-top-navigation");

        internal SandboxSource(string name) : base(name)
        {
        }
    }
}