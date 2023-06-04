using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal_project
{
    internal class ProcessCard : PaymentMethods
    {
        // Use cc# 4417 1234 5678 9113 as a test that passes Luhn algorithm!

        public static bool IsCreditCardValid(string ccNumber)
        {
            string sanitizedNummber = new string(ccNumber.Where(char.IsDigit).ToArray());
            if (string.IsNullOrWhiteSpace(sanitizedNummber) ) 
            {
                return false; 
            }

            int checkSum = 0;
            bool isEvenDigit = false;

            for(int i = sanitizedNummber.Length - 1; i >= 0; i--)
            {
                int digit = sanitizedNummber[i] - '0';
                if (isEvenDigit)
                {
                    digit *= 2;

                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                checkSum += digit;
                isEvenDigit = !isEvenDigit;
            }

            return checkSum % 10 == 0;
        }
         
        public static bool IsExpirationDateValid(string expirationDate)
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year % 100;
            int expirationMonth = 0;
            int expirationYear = 0;
              
            if (expirationDate.Length == 5 &&
                int.TryParse(expirationDate.Substring(0,2), out expirationMonth) &&
                int.TryParse(expirationDate.Substring(3,2), out expirationYear) &&
                expirationMonth >= 1 && expirationMonth <= 12)
            {
                if(expirationYear > currentYear || (expirationYear == currentYear && expirationMonth >= currentMonth)) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public static bool IsValidCVV(string cvv)
        {
            int cvvLength = 0;
            if(cvv.Length >= 3 && cvv.Length <= 4 && cvv.All(char.IsDigit)) 
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        public override string GetPayment(double grandTotal)
        {
            string ccNumber = "";
            string expDate = "";            
            string cvvNumber = "";

            Console.WriteLine("Please enter the credit card number:");
            ccNumber = Console.ReadLine();

            while (!IsCreditCardValid(ccNumber))
            {                
                Console.WriteLine("That is not a valid credit card number, please check your card and try again.");
                ccNumber = Console.ReadLine();
            }

            string trimmedCC = ccNumber.Substring(Math.Max(0, ccNumber.Length - 4)); 
            

            Console.WriteLine("Please enter the credit card expiration date (MM/YY) :");
            expDate = Console.ReadLine();
            while (!IsCreditCardValid(expDate))
            {
                Console.WriteLine("That is not a valid expiration date, please make sure your card is not expired and you entered the date using (MM/YY) format.");
                expDate = Console.ReadLine();
            }
            

            Console.WriteLine("Please enter the 3 or 4 digit CVV number on the card:");
            cvvNumber = Console.ReadLine();
            while (!IsValidCVV(cvvNumber))
            {
                Console.WriteLine("That is not a valid entry. The CVV number should be between 3 and 4 digits of numeric character only! Please check and try again:");
                cvvNumber = Console.ReadLine();
            }

            return $"Thank you, {grandTotal} has been charged to the credit card ending in: {trimmedCC}, Expiration: {expDate}. CCV: {cvvNumber}.";
        }







    }
}
