namespace WebApplicationApi.Services
{
    public class Key
    {
        public static string Secret { get { return generateKey(); } }

        public static string generateKey()
        {
            return @"5+IV)E2glD3xCH2rNTElZ_at9(TbG1N(E=pH)29*";
        }
    }
}
