using System;

namespace MassTransitTutorial.Domain
{
    public static class Check
    {
        public static void NotNull(Guid value, string errorMessage)
        {
            if (value == default)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        public static void NotNull(string value, string errorMessage)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(errorMessage);
            }
        }

        public static void NotEqual(object a, object b, string errorMessage)
        {
            if (a.Equals(b))
            {
                throw new ArgumentException(errorMessage);
            }
        }

        public static void IsNotMinor(DateTime birthDate, string errorMessage)
        {
            var eighteenYearsPeriod = TimeSpan.FromDays(365 * 18);

            if (DateTime.Today.Subtract(eighteenYearsPeriod).Date <= birthDate.Date)
            {
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
