namespace StoreApp.Settings
{
    public static class StoreAppSettings
    {

        public const string DateFormat = "dd/MM/yyyy";
        public const string DisplayDateFormat = $"{{0:{DateFormat}}}";
        public const string ValidNameExpression = @"^[a-zA-Z0-9._\u0600-\u06FF()?//\\@,:!& -]+$";
        public const string ValidGuid = @"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$";
        public const string PhoneNumberExpression = @"^[+\d]+$";
    }
}
