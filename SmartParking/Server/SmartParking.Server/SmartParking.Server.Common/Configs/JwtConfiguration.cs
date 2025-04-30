namespace SmartParking.Server.Common.Configs
{
    public interface JwtConfiguration
    {
        static string JwtSecret { get; set; } = "ThisIsMySuperSecretKeyForHS256Algorithm12345";
    }
}