namespace TaPegandoFogoBicho.Shared.Configurations
{
    public class ApplicationConfig
    {
        public static Logging Logging { get; set; }
        public static ConnectionStrings ConnectionStrings { get; set; }
        public static AuthenticationConfiguration AuthenticationConfiguration { get; set; }
        public static MqttConnection MqttConnection { get; set; }
    }

    public class Logging
    {
        public static string TokenLogentries { get; set; }
    }

    public class ConnectionStrings
    {
        public static string DefaultConnection { get; set; }
    }

    public class AuthenticationConfiguration
    {
        public static string Authority { get; set; }
        public static string Audience { get; set; }
    }

    public class MqttConnection
    {
        public static string MqttClient { get; set; }
        public static string MqttUser { get; set; }
        public static string MqttPassword { get; set; }
    }
}
