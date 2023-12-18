namespace DiamondAuthServer.WebAPI.Extensions
{
    public static class ServiceExtension
    {
        public static bool IsLocal(this IHostEnvironment hostEnvironment)
        {
            return hostEnvironment.EnvironmentName.Equals("Local", StringComparison.OrdinalIgnoreCase);
        }
    }
}
