using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Domain.Util
{
    public class ValidateMaximumDateAttribute : ValidationAttribute
    {
        private readonly DateTime _maxValue = DateTime.UtcNow;

        public override bool IsValid(object value)
        {
            DateTime val = (DateTime)value;
            return  val <= _maxValue;
        }
    }
}
