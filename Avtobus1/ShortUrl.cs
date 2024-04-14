namespace Avtobus1
{
    public class ShortUrl
    {
        public static string ShortenUrl(string longUrl)
        {
            longUrl = Guid.NewGuid().ToString().Substring(0, 8);

            return longUrl;
        }
    }
}
