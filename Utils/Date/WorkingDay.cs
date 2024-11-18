using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.Date {

    /// <summary>
    /// Date calculations for working week.
    /// </summary>
    public class WorkingDay {

        /// <summary>
        /// Checks if the given day is a working day.
        /// </summary>
        /// <param name="inputDate">Date to check</param>
        /// <returns>whether the date is a working day or not.</returns>
        public static bool IsWorkingDay(DateTime inputDate) {

            // The current year being checked. This allows the 8 UK bank holidays to be
            // initialised correctly.
            int year = inputDate.Year;

            // Check if the input date falls on the weekend
            if (inputDate.DayOfWeek == DayOfWeek.Sunday || inputDate.DayOfWeek == DayOfWeek.Saturday)
            {
                return false;
            }

            // Check if the day falls on a public holiday
            foreach (DateTime publicHoliday in PublicHolidays.AllPublicHolidays(inputDate.Year))
            {
                if (inputDate.Month == publicHoliday.Month && inputDate.Day == publicHoliday.Day)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// AddWorkingDays (Adds a working number of days to a given date, i.e. ten working days)
        /// </summary>
        /// <param name="inputDate"></param>
        /// <param name="daysToAdd"></param>
        /// <returns></returns>
        public static DateTime AddWorkingDays(DateTime inputDate, int daysToAdd) {

            int daysAdded = 0;
            DateTime current = inputDate;

            if (daysToAdd > 0)
            {
                do
                {
                    current = current.AddDays(1);
                    if (IsWorkingDay(current))
                    {
                        daysAdded++;
                    }
                }
                while (daysAdded != daysToAdd);
            }
            else if (daysToAdd != 0)
            {

                do
                {
                    current = current.AddDays(-1);
                    if (IsWorkingDay(current))
                    {
                        daysAdded--;
                    }
                }
                while (daysAdded != daysToAdd);
            }


            return current;
        }
    }
}
