using System;

namespace _4.PasswordValidatorE
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isPasswordLength = CheckPasswordCharacters(password);
            bool isOnlyLettersAndDigits = CheckPasswordForLettersAndDigits(password);
            bool containsMinTwoDigits = CheckPasswordForAtleastTwoDigits(password);

            if (!isPasswordLength)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
           
            if (!isOnlyLettersAndDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
           
            if (!containsMinTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isPasswordLength && isOnlyLettersAndDigits && containsMinTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        public static bool CheckPasswordCharacters(string str)
        {
            if (str.Length >= 6 && str.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }           
        }

        public static bool CheckPasswordForLettersAndDigits(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsLetterOrDigit(str[i]))
                {
                    return false;
                }              
            }
            return true;
        }

        public static bool CheckPasswordForAtleastTwoDigits(string str)
        {
            int count = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    count++;
                }              
            }

            if (count >= 2)
            {
                return true;
            }          
            return false;
        }
    }
}
