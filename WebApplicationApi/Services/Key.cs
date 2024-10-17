namespace WebApplicationApi.Services
{
    public class Key
    {
        public static string Secret { get { return generateKey(); } }

        public static string generateKey()
        {
            string secret = string.Empty;
            for (int j = 1; j < 2; j++)
                for (int i = 1; i < 128; i++)
                    secret += Convert.ToString(j);
            return secret;
        }
    }
}
