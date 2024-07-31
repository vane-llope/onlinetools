using onlinetools.Interfaces.UseCase.Tools;
using System.Numerics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace onlinetools.Services.Tools
{
    public class NumberTools : INumberTools
    {
        private string[][] Units = [
                  [" صفر ", " یک ", " دو ", " سه ", " چهار ", " پنج ", " شش ", " هفت ", " هشت ", " نه ", " ده ", " یازده ", " دوازده ", " سیزده ", " چهارده ", " پانزده ", " شانزده ", " هفده ", " هجده ", " نوزده "],
            ["", "", " بیست ", " سی ", " چهل ", " پنجاه ", " شصت ", " هفتاد ", " هشتاد ", " نود "],
            ["", " یکصد ", " دویست ", " سیصد ", " چهارصد ", " پانصد ", " ششصد ", " هفتصد ", " هشتصد ", " نهصد "],
            ["", " هزار ", " میلیون ", " میلیارد ", " بیلیون ", " بیلیارد ", " تریلیون ", " تریلیارد ", " کوآدریلیون ", " کادریلیارد ", " کوینتیلیون ", " کوانتینیارد ", " سکستیلیون ", " سکستیلیارد " , " سپتیلیون ", " سپتیلیارد ", " اکتیلیون ", " اکتیلیارد ", " نانیلیون ", " نانیلیارد ", " دسیلیون ", " دسیلیارد "],
        ];

        public double Percentage(double number, double percent)
        {
            double result = number * percent / 100;
            return result;
        }
        public double PercentageIncrease(double number, double percent)
        {
            double result = number + (number * (percent / 100));
            return result;
        }
        public double PercentageReduction(double number, double percent)
        {
            double result = number - (number * (percent/100));
            return result;
        }

        public double PercentageError(double ActualValue, double EstimatedValue)
        {
            double result = ((ActualValue-EstimatedValue)/ActualValue)*100;
            return result;
        }

        public double PercentageChange(double OldValue, double NewValue)
        {
            double result = ((NewValue - OldValue) / OldValue) * 100;
            return result;
        }


        public int RandomNumber(int min, int max)
        {
            Random rnd = new Random();
            int result = rnd.Next(min, max);
            return result;
        }
        public string ShiftingNumbers(string PersianNumber, int EnglishNumber)
        {
            char[] PersianNumbers = { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };
            StringBuilder result = new StringBuilder();

            if (!string.IsNullOrEmpty(PersianNumber))
            {
                foreach (char c in PersianNumber)
                {
                    int index = PersianToEnglish(c, PersianNumbers);
                    if (index != -1)
                    {
                        result.Append(index);
                    }
                }
            }

            string englishNumberStr = EnglishNumber.ToString();
            if (englishNumberStr.Length > 0)
            {
                foreach (char c in englishNumberStr)
                {
                    int index = (int)char.GetNumericValue(c);
                    result.Append(PersianNumbers[index]);
                }
            }

            return result.ToString();
        }

        private int PersianToEnglish(char number, char[] PersianNumbers)
        {
            for (int i = 0; i < PersianNumbers.Length; i++)
            {
                if (PersianNumbers[i] == number) return i;
            }
            return -1;
        }


        public string NumberToWord(BigInteger number)
        {

            if(number.ToString().Length > 66)
                return "خارج از محدوده";
            else if (number < 20)
                    return LessThanTwenty((int)number);
                else if (number >= 20 && number < 100)
                    return Two((int)number);
                else if (number < 1000)
                    return Three((int)number);
                else if(number >= 1000)
                return LargerNumber(number);
            
            return "not found";
        }

        private string Two(int number)
        {
           if(number != 0)
            {
                if (number % 10 == 0)
                {
                    return Units[1][number / 10];
                }
                else
                    return Units[1][number / 10] + "و" + Units[0][number % 10];
            }
            return "";
        }

        private string LessThanTwenty(int number)
        {
            return Units[0][number];
        }

        private string Three(int number)
        {
           if(number != 0)
            {
                if (number % 100 == 0)
                    return Units[2][number / 100];
                else
                {
                    if (number % 100 >= 20)
                        return Units[2][number / 100] + "و" + Two(number % 100);
                    else
                        return Units[2][number / 100] + "و" + LessThanTwenty(number % 100);
                }
            }
            return "";
                
        }

        private string LargerNumber(BigInteger number)
        {
            string result = "";
            int unitIndex = 0;

            while (number > 0)
            {
                int threeDigits = (int)(number % 1000);
                if (threeDigits != 0)
                {
                    string threeDigitsWord = Three(threeDigits);
                    if (unitIndex > 0)
                        threeDigitsWord += Units[3][unitIndex];
                    if (result.StartsWith("و"))
                        result = result.Substring(1, result.Length - 1);
                    result = threeDigitsWord + "و" + result;
                }
                number /= 1000;
                unitIndex++;
            }

            // Remove the trailing "و"
            if (result.EndsWith("و"))
                result = result.Substring(0, result.Length - 1);
            if (result.StartsWith("و"))
                result = result.Substring(1, result.Length - 1);

            return result.Trim();
        }
    

}
}
