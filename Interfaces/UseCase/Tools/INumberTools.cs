using System.Numerics;
using System.Text;

namespace onlinetools.Interfaces.UseCase.Tools
{
    public interface INumberTools
    {
        public double Percentage(double number, double percent);
        public double PercentageIncrease(double number, double percent);
        public double PercentageReduction(double number, double percent);
        public double PercentageError(double ActualValue, double EstimatedValue);
        public double PercentageChange(double OldValue, double NewValue);
        public int RandomNumber(int min, int max);
        public string ShiftingNumbers(string PersianNumber, int EnglishNumber = 0);
        public string NumberToWord(BigInteger number);

    }
}
