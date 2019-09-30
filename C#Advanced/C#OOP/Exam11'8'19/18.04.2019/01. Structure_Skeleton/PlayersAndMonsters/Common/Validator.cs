namespace PlayersAndMonsters.Common
{
    using System;

    public static class Validator
    {
        public static void ThrowIfSttringIsNullOrEmpty(string str, string message = null)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfNumberIsNegative(int number, string message = null)
        {
            if (number < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
