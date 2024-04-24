namespace Task3
{
    static class StringsRand
    {
        private static Random random = new();
        private static string? randomString = null;
        private const string? chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string RandomString(int length)
        {
            randomString ??= new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
    }
}
