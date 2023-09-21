namespace GameZone.Validation
{
    public static class AllowedExtensionsAndMaxSize
    {
        public const string allowedExtensions = ".jpg,.png,.jpeg";
        public const int allowedSizeByMB = 2;
        public const int allowedSizeByByte = allowedSizeByMB * 1024 * 1024;

    }
}
