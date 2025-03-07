namespace RemoteControl.Rest.Processing.Api.config;

public static class MimeTypes
{
    public static class Application
    {
        public const string Json = "application/json";

        public const string Zip = "application/zip";

        public const string Pdf = "application/pdf";

        public const string XWwwFormUrlEncoded = "application/x-www-form-urlencoded";
    }

    public static class Text
    {
        public const string Csv = "text/csv";

        public const string Html = "text/html";
    }

    public static class Image
    {
        public const string Svg = "image/svg+xml";

        public const string Png = "image/png";
    }

    public const string CatchAll = "*/*";
}
