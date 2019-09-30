using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _5.DateModifierE
{
    public class DateModifier
    {
        public static double GetDaysBetweenTwoDates(string dateOne, string dateTwo)
        {
            var firstDate = DateTime.ParseExact(dateOne, "yyyy MM dd", CultureInfo.InvariantCulture);
            var secondDate = DateTime.ParseExact(dateTwo, "yyyy MM dd", CultureInfo.InvariantCulture);

            if (firstDate > secondDate)
            {
                return GetDaysBetweenTwoDates(dateTwo, dateOne);
            }

            return (secondDate - firstDate).Days;
        }
    }
}
