namespace Fast.Infrastructure.Options
{

    public class PasswordOptionsHash
    {
        public int SaltSize { get; set; }
        public int KeySize { get; set; }
        public int Iterations { get; set; }
    }
}
