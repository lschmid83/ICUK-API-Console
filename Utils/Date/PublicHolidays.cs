using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.Date {

    /// <summary>
    /// Calculates public holidays.
    /// </summary>
    public static class PublicHolidays {

        /// <summary>
        /// Determines all of the public holidays for a given year.
        /// </summary>
        /// <param name="year">The year to query.</param>
        /// <returns>List of all the public holidays for the supplied year.</returns>
        public static Queue<DateTime> AllPublicHolidays(int year) {

            Queue<DateTime> dates = new Queue<DateTime>();

            dates.Enqueue(NewYearsDay(year));
            dates.Enqueue(GoodFriday(year));
            dates.Enqueue(EasterMonday(year));
            dates.Enqueue(MayDay(year));
            dates.Enqueue(Whitsun(year));
            dates.Enqueue(SummerBankHoliday(year));
            dates.Enqueue(Christmas(year));
            dates.Enqueue(BoxingDay(year));

            // Check if a Monarch Appreciation Day exists for the year.
            DateTime mad = MonarchAppreciationDay(year);

            if (mad.Year == year)
            {
                dates.Enqueue(mad);
            }

            return dates;
        }

        /// <summary>
        /// Determines the day that New Years day falls on for a given year.
        /// </summary>
        /// <param name="year">The year to query.</param>
        /// <returns>The date on which New Years day falls.</returns>
        public static DateTime NewYearsDay(int year) {

            DateTime newYearsDay = new DateTime(year, 1, 1);

            while (newYearsDay.DayOfWeek.ToString() == "Saturday" || newYearsDay.DayOfWeek.ToString() == "Sunday")
            {
                newYearsDay = newYearsDay.AddDays(1);
            }

            return newYearsDay;
        }

        /// <summary>
        /// Determines the day that Good Friday falls on for a given year.
        /// </summary>
        /// <param name="year">The year to query.</param>
        /// <returns>The date on which Good Friday falls.</returns>
        public static DateTime GoodFriday(int year) {
            return EasterSunday(year).AddDays(-2);
        }

        /// <summary>
        /// Determines the day that Easter Monday falls on for a given year.
        /// </summary>
        /// <param name="year">The year to query.</param>
        /// <returns>The date on which Easter Monday falls.</returns>
        public static DateTime EasterMonday(int year) {
            return EasterSunday(year).AddDays(1);
        }

        /// <summary>
        /// Determines the day that Easter Sunday falls on for a given year.
        /// </summary>
        /// <param name="year">The year to query.</param>
        /// <returns>The date on which Easter Sunday falls.</returns>
        public static DateTime EasterSunday(int year) {

            int day = 0;
            int month = 0;

            int g = year % 19;
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day);
        }

        /// <summary>
        /// Determines the day that May day falls on for a given year.
        /// </summary>
        /// <param name="year">The year to query.</param>
        /// <returns>The date on which May day falls.</returns>
        public static DateTime MayDay(int year) {

            DateTime mayDay = new DateTime(year, 5, 1);

            // Early may bank holiday -- first monday in may. Take the first
            // day in may and add until monday is reached.
            while (mayDay.DayOfWeek.ToString() != "Monday")
            {
                mayDay = mayDay.AddDays(1);
            }

            return mayDay;
        }

        /// <summary>
        /// Determines the day that whitsun falls on for a given year.
        /// </summary>
        /// <param name="year">The year to query.</param>
        /// <returns>The date on which whitsun falls.</returns>
        public static DateTime Whitsun(int year) {

            DateTime whitsun = new DateTime(year, 5, 31);

            // Added exception for jubilee move of holiday.
            if (year == 2012)
            {
                return DateTime.Parse("2012/06/04");
            }

            while (whitsun.DayOfWeek.ToString() != "Monday")
            {
                whitsun = whitsun.AddDays(-1);
            }

            return whitsun;
        }

        /// <summary>
        /// Determines the day that August bank holiday falls on for a given year.
        /// </summary>
        /// <param name="year">The year to query.</param>
        /// <returns>The date on which Christmas day falls.</returns>
        public static DateTime SummerBankHoliday(int year) {

            DateTime summerBankHoliday = new DateTime(year, 8, 31);

            while (summerBankHoliday.DayOfWeek.ToString() != "Monday")
            {
                summerBankHoliday = summerBankHoliday.AddDays(-1);
            }

            return summerBankHoliday;
        }

        /// <summary>
        /// Determines the day that Christmas day falls on for a given year.
        /// </summary>
        /// <param name="year">The year to query.</param>
        /// <returns>The date on which Christmas day falls.</returns>
        public static DateTime Christmas(int year) {

            DateTime christmas = new DateTime(year, 12, 25);

            while (christmas.DayOfWeek.ToString() == "Saturday" || christmas.DayOfWeek.ToString() == "Sunday")
            {
                christmas = christmas.AddDays(1);
            }

            return christmas;
        }

        /// <summary>
        /// Determines the day that boxing day falls on for a given year.
        /// </summary>
        /// <param name="year">The year to query.</param>
        /// <returns>The date on which boxing day falls.</returns>
        public static DateTime BoxingDay(int year) {

            DateTime boxingDay = new DateTime(year, 12, 26);

            if (boxingDay.DayOfWeek.ToString() == "Saturday" || boxingDay.DayOfWeek.ToString() == "Sunday")
            {
                boxingDay = boxingDay.AddDays(2);
            }

            return boxingDay;
        }

        /// <summary>
        /// Returns the day that a monarch appreciation day falls on the supplied year.
        /// A date containing a year before the supplied year will be returned should
        /// the year not contain a monarch appreciation day.
        /// </summary>
        /// <param name="year">The year to query.</param>
        /// <returns>The date on which the monarch appreciation day falls.</returns>
        public static DateTime MonarchAppreciationDay(int year) {

            if (year == 2012)
            {
                return new DateTime(2012, 6, 5);
            }
            else
            {
                return new DateTime(1970, 1, 1);
            }
        }

    }

}
