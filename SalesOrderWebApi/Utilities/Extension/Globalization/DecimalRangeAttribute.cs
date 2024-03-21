using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Utilities.Extension.Globalization
{
    public class DecimalRangeAttribute : ValidationAttribute
    {
        private readonly decimal _minValue;
        private readonly decimal _maxValue;


        public DecimalRangeAttribute(decimal minValue, decimal maxValue)
        {
            _maxValue = maxValue;
            _minValue = minValue;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;

            var number = Convert.ToDecimal(value);

            return number >= _minValue && number <= _maxValue;
        }
    }
    
}
