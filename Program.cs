using System;

namespace PasswordVerificationProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Password Verification Program for accessing secret databases of US Security Agencies!");
            
            Console.Write("Enter the 6-digit password: ");
            int password = int.Parse(Console.ReadLine());
            
            Console.Write("Enter the agency abbreviation (CIA, FBI, or NSA): ");
            string agency = Console.ReadLine().ToUpper();

            bool isValid = false;

            switch (agency)
            {
                case "CIA":
                    bool isDivisibleBy3 = password % 3 == 0;
                    bool isTensDigitValid = password / 10 % 10 != 1 && password / 10 % 10 != 3 && password / 10 % 10 != 5;
                    bool isThousandsDigitValid = password / 1000 % 10 >= 6 && password / 1000 % 10 != 8;
                    isValid = isDivisibleBy3 && isTensDigitValid && isThousandsDigitValid;
                    break;

                case "FBI":
                    bool isHundredThousandsInRange = password / 100000 >= 4 && password / 100000 <= 7;
                    bool isHundredsDigitValid = password / 100 % 2 == 0 && password / 100 % 10 != 6;
                    bool isTensOfThousandsValid = password / 10000 % 2 == 1;
                    isValid = isHundredThousandsInRange && isHundredsDigitValid && isTensOfThousandsValid;
                    break;

                case "NSA":
                    bool isFactorOf30 = false;
                    int unitDigit = password % 10;
                    if(unitDigit == 1 || unitDigit == 2 || unitDigit == 3 || unitDigit == 5 || unitDigit == 6){
                        isFactorOf30 = true;
                    }
                    
                    bool isHundredsDigitValidNSA = (password / 100 % 10) % 3 == 0 && (password / 100 % 10) % 2 != 0;
                    bool contains7 = false;
                    for (int i = password; i > 0; i /= 10)
                    {
                        if (i % 10 == 7)
                        {
                            contains7 = true;
                            break;
                        }
                    }
                    isValid = isFactorOf30 && isHundredsDigitValidNSA && contains7;
                    break;

                default:
                    Console.WriteLine("Invalid agency abbreviation. Please enter either CIA, FBI, or NSA.");
                    break;
            }

            Console.WriteLine(isValid);

            Console.ReadLine();
        }
    }
}