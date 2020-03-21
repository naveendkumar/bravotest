using System;
using System.Text;

namespace BAL
{
    /// <summary>
    /// BAL Class
    /// </summary>
    public class RandomNumber : IRandomNumber
    {
        #region Interface Methods

        /// <summary>
        /// This method returns random password.
        /// </summary>
        /// <returns></returns>
        public string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(GenerateRandomString(4, true));
            builder.Append(GenerateRandomNumber(1000, 9999));
            builder.Append(GenerateRandomString(2, false));
            return builder.ToString();
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Generate a random string with a given size 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="lowerCase"></param>
        /// <returns></returns>
        private string GenerateRandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        /// <summary>
        /// Generate a random number between two numbers 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        #endregion
    }
}
