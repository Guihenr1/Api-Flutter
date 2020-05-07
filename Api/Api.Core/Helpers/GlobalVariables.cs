namespace Api.Core.Helpers
{
    public class GlobalVariables
    {
        private static string _postgresqlConnection;
        
        public static string PostresqlConnection {
            get {
                if (string.IsNullOrWhiteSpace (_postgresqlConnection)) {
                    _postgresqlConnection = GetSecretsManager.GetSecretValue ("FLUTTER-API-POSTGRESQL-CONNECTION");
                }

                return _postgresqlConnection;
            }

            private set {
                _postgresqlConnection = value;
            }
        }
    }
}