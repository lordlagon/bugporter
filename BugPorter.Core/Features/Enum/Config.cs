namespace BugPorter.Core.Features
{
    public static class Config
    {
        const string EnvironmentNameKey = "environmentName";
        const string ApiUrlKey = "apiUrl";
        const string ApiKeyKey = "apiKey";
        const string GeoApiUrlKey = "geoApiUrl";
        const string GeoApiKeyKey = "geoApiKey";
        const string GoogleMapsApiKeyKey = "googleMapsApiKey";

        readonly static Dictionary<AppEnvironment, Dictionary<string, string>> Configurations
            = new Dictionary<AppEnvironment, Dictionary<string, string>>
            {
                [AppEnvironment.Debug] = new Dictionary<string, string>
                {
                    [EnvironmentNameKey] = "dev",
                    [ApiUrlKey] = "https://fazendaapidev.infra.agrotopus.com.br/api",
                    [ApiKeyKey] = "58A491CF-51D6-469D-AA47-C16A291236F0",
                    [GeoApiUrlKey] = "https://fazendageodev.infra.agrotopus.com.br/api",
                    [GeoApiKeyKey] = "58A491CF-51D6-469D-AA47-C16A291236F0",
                    [GoogleMapsApiKeyKey] = "AIzaSyA6mZi-F3uCJ8HIRKKqYoft8h6PvtTEfIY",
                },
                [AppEnvironment.QA] = new Dictionary<string, string>
                {
                    [EnvironmentNameKey] = "qa",
                    [ApiUrlKey] = "https://fazendaapihml.infra.agrotopus.com.br/api",
                    [ApiKeyKey] = "58A491CF-51D6-469D-AA47-C16A291236F0",
                    [GeoApiUrlKey] = "https://fazendageohml.infra.agrotopus.com.br/api",
                    [GeoApiKeyKey] = "58A491CF-51D6-469D-AA47-C16A291236F0",
                    [GoogleMapsApiKeyKey] = "AIzaSyA6mZi-F3uCJ8HIRKKqYoft8h6PvtTEfIY",
                },
                [AppEnvironment.Production] = new Dictionary<string, string>
                {
                    [EnvironmentNameKey] = "prd",
                    [ApiUrlKey] = "https://fazendadigitalapi.infra.agrotopus.com.br/api",
                    [ApiKeyKey] = "58A491CF-51D6-469D-AA47-C16A291236F0",
                    [GeoApiUrlKey] = "https://fazendadigitalgeo.infra.agrotopus.com.br/api",
                    [GeoApiKeyKey] = "58A491CF-51D6-469D-AA47-C16A291236F0",
                    [GoogleMapsApiKeyKey] = "AIzaSyA6mZi-F3uCJ8HIRKKqYoft8h6PvtTEfIY",
                },
            };
        
        static AppEnvironment selectedEnvironment = AppEnvironment.Debug;
                
        public static void SetEnvironment(AppEnvironment environment) => selectedEnvironment = environment;

        public static string EnvironmentName => Configurations[selectedEnvironment][EnvironmentNameKey];

        public static string ApiUrl => Configurations[selectedEnvironment][ApiUrlKey];

        public static string ApiKey => Configurations[selectedEnvironment][ApiKeyKey];

        public static string GeoApiUrl => Configurations[selectedEnvironment][GeoApiUrlKey];

        public static string GeoApiKey => Configurations[selectedEnvironment][GeoApiKeyKey];

        public static string GoogleMapsApiKey => Configurations[selectedEnvironment][GoogleMapsApiKeyKey];
    }
}