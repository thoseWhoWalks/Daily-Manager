namespace DM.Modules.Users.Authenctication
{
    internal class JwtOptions
    {
        public string Issuer { get; set; } = null!;
        public int ExpireIn { get; set; }
        public string Secret { get; set; } = null!;
    }
}
