using Microsoft.AspNetCore.Mvc;
using onlinetools.Interfaces.RepositoryInterFaces;
using onlinetools.Interfaces.UseCase.Tools;
using System.Numerics;

namespace onlinetools.Controllers
{
    public class NumberToolsController : ControllerBase
    {
        private INumberTools _numberTools { get; }
        public NumberToolsController(INumberTools numberTools)
        {
            _numberTools = numberTools;
        }
        [HttpGet("Percentage")]
        public async Task<IActionResult> Percentage(double number, double percent)
        {
            var result = _numberTools.Percentage(number, percent);
            return Ok( result);
        }
        [HttpGet("PercentageIncrease")]
        public async Task<IActionResult> PercentageIncrease(double number, double percent)
        {
            var result = _numberTools.PercentageIncrease(number, percent);
            return Ok(result);
        }
        [HttpGet("PercentageReduction")]
        public async Task<IActionResult> PercentageReduction(double number, double percent)
        {
            var result = _numberTools.PercentageReduction(number, percent);
            return Ok(result);
        }

        [HttpGet("PercentageError")]
        public async Task<IActionResult> PercentageError(double ActualValue, double EstimatedValue)
        {
            var result = _numberTools.PercentageError(ActualValue, EstimatedValue);
            return Ok(result);
        }
        [HttpGet("PercentageChange")]
        public async Task<IActionResult> PercentageChange(double OldValue, double NewValue)
        {
            var result = _numberTools.PercentageChange(OldValue, NewValue);
            return Ok(result);
        }


        [HttpGet("RandomNumber")]
        public async Task<IActionResult> RandomNumber(int min, int max)
        {
            var result = _numberTools.RandomNumber(min, max);
            return Ok(result);
        }

        [HttpGet("ShiftingNumbers")]
        public async Task<IActionResult> ShiftingNumbers(string PersianNumber, int EnglishNumber)
        {
            var result = _numberTools.ShiftingNumbers( PersianNumber, EnglishNumber);
            return Ok(result);
        }
        [HttpGet("NumberToWord")]
        public async Task<IActionResult> NumberToWord(string Number)
        {

            var result = _numberTools.NumberToWord(BigInteger.Parse(Number));
            return Ok(result);
        }



    }
}
