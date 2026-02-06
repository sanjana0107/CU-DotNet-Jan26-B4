namespace ApplicationConfigurationTracker
{
    class ApplicationConfig
    {
        public static string ApplicationName { get; set; }

        public static string Environment { get; set; }

        public static int AccessCount { get; set; }

        public static bool IsInitialized { get; set; }

        static ApplicationConfig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;
        }

        public static void Initialize(string appName, string environment)
        {
            ApplicationName = appName;
            Environment = environment;
            IsInitialized = true;
            AccessCount++;
        }

        public static string GetConfigurationSummary()
        {
            AccessCount++;
            return $"Application Name- {ApplicationName}\nEnvironment- {Environment}\n" +
                $"Access Count- {AccessCount}\nInitialization Status- {IsInitialized}";
        }

        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            IsInitialized = false;
            AccessCount++;

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationConfig.ApplicationName = "NewApp";
            ApplicationConfig.Initialize("WhatsApp", "Prod");
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());



        }
    }
}
