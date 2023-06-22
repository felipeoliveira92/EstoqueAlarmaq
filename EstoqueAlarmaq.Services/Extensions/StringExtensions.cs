namespace EstoqueAlarmaq.Services.Extensions
{
    public static class StringExtensions
    {
        public static string FirstWord(this string text)
        {
            return text.Trim().Substring(0, text.IndexOf(" "));
        }
    }
}