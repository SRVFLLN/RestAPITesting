using System;

namespace JSONHolderProject.Utils
{
    public class TextUtils
    {
        public static string GetRandomText(int countOfWords = 7)
        {
            string randomString = string.Empty;
            int countOfLetters;
            Random random = new Random();

            for (int i = 0; i < countOfWords; i++)
            {
                countOfLetters = random.Next(5, 10);
                for (int j = 0; j < countOfLetters; j++)
                {
                    char letter = (char)random.Next(65, 90);
                    randomString += letter;
                }
                if (i != countOfWords - 1)
                {
                    randomString += ' ';
                }
            }
            return randomString;
        }
    }
}
