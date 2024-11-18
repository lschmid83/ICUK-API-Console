using API.Controllers.Broadband.Types;
using API.Core;
using API.Core.Broadband;
using API.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Utils.Text;

namespace API.Controllers.Broadband {

    /// <description>Methods for retrieving the daily data transfer usage of broadband users.</description>
    public class BroadbandDataTransferController : IcukApiController {

        #region Daily Data Transfer

        /// <name>Gets daily broadband transfer usage for current month</name>
        /// <description>Retrieves the daily data transfer usage for a broadband user for the current month.</description>
        /// <type>Get</type>
        /// <url>/broadband/data_transfer/daily/{user@realm}</url>
        /// <group>Broadband Data Transfer</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_data_transfer_daily_result</type>
        ///     <field>data_transfer</field>
        ///     <description>Represents broadband data transfer usage of a specific user.</description>
        /// </success>
        /// <error>
        ///     <type>InvalidParameterException</type>   
        /// </error>
        /// <error>
        ///     <type>NonExistentUserException</type>   
        /// </error>
        /// <error>
        ///     <type>NotLiveException</type>   
        /// </error>
        /// <error>
        ///     <type>DataUsageException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "username": %username%,
        ///     "year": %year%,
        ///     "month": %month%,
        ///     "days": [
        ///         {
        ///             "off_peak": {
        ///                 "download": 0,
        ///                 "upload": 0
        ///             },
        ///             "peak": {
        ///                 "download": 0,
        ///                 "upload": 0
        ///             },
        ///             "day": %day%
        ///         }
        ///     ]    
        /// }
        ///     </content>
        /// </example> 
        [HttpGet]
        [ActionName("Daily")]
        public broadband_data_transfer_daily_result GetDaily(string username) {
            return GetDailyDataUsageForUserCurrentMonth(username);
        }

        /// <name>Gets daily broadband transfer usage for month and year</name>
        /// <description>Retrieves the daily data transfer usage for a broadband user for the specified month and year.</description>
        /// <type>Get</type>
        /// <url>/broadband/data_transfer/daily/{user@realm}/{year}/{month}</url>
        /// <group>Broadband Data Transfer</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <parameter>
        ///     <type>Integer</type>
        ///     <field>year</field>
        ///     <description>Year.</description>
        /// </parameter>
        /// <parameter>
        ///     <type>Integer</type>
        ///     <field>month</field>
        ///     <description>Month.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_data_transfer_daily_result</type>
        ///     <field>data_transfer</field>
        ///     <description>Represents broadband data transfer usage of a specific user.</description>
        /// </success>
        /// <error>
        ///     <type>InvalidParameterException</type>   
        /// </error>
        /// <error>
        ///     <type>NonExistentUserException</type>   
        /// </error>
        /// <error>
        ///     <type>NotLiveException</type>   
        /// </error>
        /// <error>
        ///     <type>DataUsageException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "username": %username%,
        ///     "year": %year%,
        ///     "month": %month%,
        ///     "days": [
        ///         {
        ///             "off_peak": {
        ///                 "download": 0,
        ///                 "upload": 0
        ///             },
        ///             "peak": {
        ///                 "download": 0,
        ///                 "upload": 0
        ///             },
        ///             "day": %day%
        ///         }
        ///     ]    
        /// }
        ///     </content>
        /// </example> 
        /// 
        [HttpGet]
        [ActionName("Daily")]
        public broadband_data_transfer_daily_result GetDaily(string username, int year, int month) {
            return GetDailyDataTransferUsage(year, month, username);
        }

        #endregion Daily Data Transfer

        #region Hourly Data Transfer

        /// <name>Gets hourly broadband transfer usage for current day</name>
        /// <description>Retrieves the hourly data transfer usage for a broadband user for the current day.</description>
        /// <type>Get</type>
        /// <url>/broadband/data_transfer/hourly/{user@realm}</url>
        /// <group>Broadband Data Transfer</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_data_transfer_hourly_result</type>
        ///     <field>data_transfer</field>
        ///     <description>Represents broadband data transfer usage of a specific user.</description>
        /// </success>
        /// <error>
        ///     <type>InvalidParameterException</type>   
        /// </error>
        /// <error>
        ///     <type>NonExistentUserException</type>   
        /// </error>
        /// <error>
        ///     <type>NotLiveException</type>   
        /// </error>
        /// <error>
        ///     <type>DataUsageException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "username": %username%,
        ///     "year": %year%,
        ///     "month": %month%,
        ///     "day": %day%,
        ///     "hours": [
        ///         {
        ///             "download": 0,
        ///             "upload": 0,
        ///             "hour": %hour%
        ///         }
        ///     ]
        /// }
        ///     </content>
        /// </example> 
        [HttpGet]
        [ActionName("Hourly")]
        public broadband_data_transfer_hourly_result GetHourly(string username) {
            return GetHourlyDataUsageForUserCurrentDay(username);
        }

        /// <name>Gets hourly broadband transfer usage for day, month and year</name>
        /// <description>Retrieves the hourly data transfer usage for a broadband user for the specified day, month and year.</description>
        /// <type>Get</type>
        /// <url>/broadband/data_transfer/hourly/{user@realm}/{year}/{month}/{day}</url>
        /// <group>Broadband Data Transfer</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <parameter>
        ///     <type>Integer</type>
        ///     <field>year</field>
        ///     <description>Year.</description>
        /// </parameter>
        /// <parameter>
        ///     <type>Integer</type>
        ///     <field>month</field>
        ///     <description>Month.</description>
        /// </parameter>
        /// <parameter>
        ///     <type>Integer</type>
        ///     <field>day</field>
        ///     <description>Day.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_data_transfer_hourly_result</type>
        ///     <field>data_transfer</field>
        ///     <description>Represents broadband data transfer usage of a specific user.</description>
        /// </success>
        /// <error>
        ///     <type>InvalidParameterException</type>   
        /// </error>
        /// <error>
        ///     <type>NonExistentUserException</type>   
        /// </error>
        /// <error>
        ///     <type>NotLiveException</type>   
        /// </error>
        /// <error>
        ///     <type>DataUsageException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "username": %username%,
        ///     "year": %year%,
        ///     "month": %month%,
        ///     "day": %day%,
        ///     "hours": [
        ///         {
        ///             "download": 0,
        ///             "upload": 0,
        ///             "hour": %hour%
        ///         }
        ///     ]
        /// }
        ///     </content>
        /// </example> 
        [HttpGet]
        [ActionName("Hourly")]
        public broadband_data_transfer_hourly_result GetHourly(string username, int year, int month, int day) {
            return GetHourlyDataUsageForUserDayMonthYear(username, year, month, day);
        }

        #endregion Hourly Data Transfer

        #region Monthly Data Transfer

        /// <name>Gets monthly broadband transfer usage for all users for the current month</name>
        /// <description>Retrieves the monthly data transfer usage for all users for the current month.</description>
        /// <type>Get</type>
        /// <url>/broadband/data_transfer/monthly</url>
        /// <group>Broadband Data Transfer</group>
        /// <success>
        ///     <type>broadband_data_transfer_monthly_results</type>
        ///     <field>data_transfer</field>
        ///     <description>Represents broadband data transfer usage for all users.</description>
        /// </success>
        /// <error>
        ///     <type>DataUsageException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "data_transfers": [
        ///         {
        ///             "username": %username%,
        ///             "year": %year%,
        ///             "month": %month%,
        ///             "peak_hours": {
        ///                 "start": %peak_start%,
        ///                 "end": %peak_end%
        ///             },
        ///             "off_peak": {
        ///                 "download": {
        ///                     "quota": 0,
        ///                     "usage": 0,
        ///                     "overuse": 0,
        ///                     "projected": 0,
        ///                     "projected_overuse": 0
        ///                 },
        ///                 "upload": {
        ///                     "usage": 0,
        ///                     "projected": 0
        ///                 }
        ///             },
        ///             "peak": {...},
        ///             "total": {...}
        ///         }
        ///     ] 
        /// }
        ///     </content>
        /// </example> 
        [HttpGet]
        [ActionName("Monthly")]
        public broadband_data_transfer_monthly_results GetMonthly() {
            return GetMonthlyDataUsageForAllCurrentMonth();
        }

        /// <name>Gets monthly broadband transfer usage for the current month</name>
        /// <description>Retrieves the monthly data transfer usage for a broadband user for the current month.</description>
        /// <type>Get</type>
        /// <url>/broadband/data_transfer/monthly/{user@realm}</url>
        /// <group>Broadband Data Transfer</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_data_transfer_monthly_result</type>
        ///     <field>data_transfer</field>
        ///     <description>Represents broadband data transfer usage of a specific user.</description>
        /// </success>
        /// <error>
        ///     <type>InvalidParameterException</type>   
        /// </error>
        /// <error>
        ///     <type>NonExistentUserException</type>   
        /// </error>
        /// <error>
        ///     <type>NotLiveException</type>   
        /// </error>
        /// <error>
        ///     <type>DataUsageException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "username": %username%,
        ///     "year": %year%,
        ///     "month": %month%,
        ///     "peak_hours": {
        ///         "start": %peak_start%,
        ///         "end": %peak_end%
        ///     },
        ///     "off_peak": {
        ///         "download": {
        ///             "quota": 0,
        ///             "usage": 0,
        ///             "overuse": 0,
        ///             "projected": 0,
        ///             "projected_overuse": 0
        ///         },
        ///         "upload": {
        ///             "usage": 0,
        ///             "projected": 0
        ///         }
        ///     },
        ///     "peak": {...},
        ///     "total": {...}
        /// }
        ///     </content>
        /// </example> 
        [HttpGet]
        [ActionName("Monthly")]
        public broadband_data_transfer_monthly_result GetMonthly(string username) {
            return GetMonthlyDataUsageForUserCurrentMonth(username);
        }

        /// <name>Gets monthly broadband transfer usage for all users for specified month and year</name>
        /// <description>Retrieves the monthly data transfer usage for all users for the specified month and year.</description>
        /// <type>Get</type>
        /// <url>/broadband/data_transfer/monthly/{year}/{month}</url>
        /// <group>Broadband Data Transfer</group>
        /// <parameter>
        ///     <type>Integer</type>
        ///     <field>year</field>
        ///     <description>Year.</description>
        /// </parameter>
        /// <parameter>
        ///     <type>Integer</type>
        ///     <field>month</field>
        ///     <description>Month.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_data_transfer_monthly_results</type>
        ///     <field>data_transfer</field>
        ///     <description>Represents broadband data transfer usage for all users.</description>
        /// </success>
        /// <error>
        ///     <type>InvalidParameterException</type>   
        /// </error>
        /// <error>
        ///     <type>DataUsageException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "data_transfers": [
        ///         {
        ///             "username": %username%,
        ///             "year": %year%,
        ///             "month": %month%,
        ///             "peak_hours": {
        ///                 "start": %peak_start%,
        ///                 "end": %peak_end%
        ///             },
        ///             "off_peak": {
        ///                 "download": {
        ///                     "quota": 0,
        ///                     "usage": 0,
        ///                     "overuse": 0,
        ///                     "projected": 0,
        ///                     "projected_overuse": 0
        ///                 },
        ///                 "upload": {
        ///                     "usage": 0,
        ///                     "projected": 0
        ///                 }
        ///             },
        ///             "peak": {...},
        ///             "total": {...}
        ///         }
        ///     ] 
        /// }
        ///     </content>
        /// </example> 
        [HttpGet]
        [ActionName("Monthly")]
        public broadband_data_transfer_monthly_results GetMonthly(int year, int month) {
            return GetMonthlyDataUsageForAllMonthYear(year, month);
        }

        /// <name>Gets monthly broadband transfer usage for specified month and year</name>
        /// <description>Retrieves the monthly data transfer usage for a broadband user for the specified month and year.</description>
        /// <type>Get</type>
        /// <url>/broadband/data_transfer/monthly/{user@realm}/{year}/{month}</url>
        /// <group>Broadband Data Transfer</group>
        /// <parameter>
        ///     <type>String</type>
        ///     <field>username</field>
        ///     <description>Name of the user.</description>
        /// </parameter>
        /// <parameter>
        ///     <type>Integer</type>
        ///     <field>year</field>
        ///     <description>Year.</description>
        /// </parameter>
        /// <parameter>
        ///     <type>Integer</type>
        ///     <field>month</field>
        ///     <description>Month.</description>
        /// </parameter>
        /// <success>
        ///     <type>broadband_data_transfer_monthly_result</type>
        ///     <field>data_transfer</field>
        ///     <description>Represents broadband data transfer usage of a specific user.</description>
        /// </success>
        /// <error>
        ///     <type>InvalidParameterException</type>   
        /// </error>
        /// <error>
        ///     <type>NonExistentUserException</type>   
        /// </error>
        /// <error>
        ///     <type>NotLiveException</type>   
        /// </error>
        /// <error>
        ///     <type>DataUsageException</type>   
        /// </error>
        /// <example>
        ///     <title>Response</title>
        ///     <content>
        /// HTTP/1.1 200 OK
        /// {
        ///     "username": %username%,
        ///     "year": %year%,
        ///     "month": %month%,
        ///     "peak_hours": {
        ///         "start": %peak_start%,
        ///         "end": %peak_end%
        ///     },
        ///     "off_peak": {
        ///         "download": {
        ///             "quota": 0,
        ///             "usage": 0,
        ///             "overuse": 0,
        ///             "projected": 0,
        ///             "projected_overuse": 0
        ///         },
        ///         "upload": {
        ///             "usage": 0,
        ///             "projected": 0
        ///         }
        ///     },
        ///     "peak": {...},
        ///     "total": {...}
        /// }
        ///     </content>
        /// </example> 
        [HttpGet]
        [ActionName("Monthly")]
        public broadband_data_transfer_monthly_result GetMonthly(string username, int year, int month) {
            return GetMonthlyDataUsageForUserMonthYear(username, year, month);
        }

        #endregion Monthly Data Transfer
        
        /// <summary>
        /// Initializes array of broadband_data_transfer_daily structs for the current year and month.
        /// </summary>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <returns>Array of broadband_data_transfer_daily.</returns>
        private broadband_data_transfer_daily[] InitializeEmptyMonth(int year, int month) {

            int daysInMonth;
            if (month == DateTime.Now.Month && year == DateTime.Now.Year)
                daysInMonth = DateTime.Now.Day;
            else
                daysInMonth = DateTime.DaysInMonth(year, month);

            broadband_data_transfer_daily[] days = new broadband_data_transfer_daily[daysInMonth];

            // Initialize empty result set.
            for (int i = 0; i < daysInMonth; i++)
            {
                days[i] = new broadband_data_transfer_daily()
                {
                    day = i + 1
                };
            }
            return days;
        }

        /// <summary>
        /// Initializes array of broadband_data_transfer_hourly structs.
        /// </summary>
        /// <returns>Array of broadband_data_transfer_hourly.</returns>
        private broadband_data_transfer_hourly[] InitializeEmptyDay()
        {
            // Initialize empty result set.
            broadband_data_transfer_hourly[] hours = new broadband_data_transfer_hourly[24];
            for (int i = 0; i < 24; i++)
            {
                hours[i] = new broadband_data_transfer_hourly()
                {
                    download = 0,
                    upload = 0,
                    hour = i
                };
            }
            return hours;
        }

        /// <summary>
        /// Retrieves the daily data transfer usage of a broadband user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>broadband_data_transfer_result.</returns>
        private broadband_data_transfer_daily_result GetDailyDataUsageForUserCurrentMonth(string fullUsername)
        {
            broadband_data_transfer_daily_result results = GetResults<broadband_data_transfer_daily_result>("Broadband/broadband_usage_daily_current_month.json");
            results.username = fullUsername;
            results.month = DateTime.Today.Month;
            results.year = DateTime.Today.Year;

            return results;
        }
        /// <summary>
        /// Retrieves the daily data transfer usage of a broadband user.
        /// </summary>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>List of broadband_data_transfer_result objects.</returns>
        private broadband_data_transfer_daily_result GetDailyDataTransferUsage(int year, int month, string fullUsername) {

            if (!Validation.ValidYear(year))
                throw new InvalidParameterException("Invalid year supplied.");

            if (!Validation.ValidMonth(month))
                throw new InvalidParameterException("Invalid month supplied.");

            if (year == DateTime.Now.Year && month > DateTime.Now.Month)
                throw new InvalidParameterException("Invalid month supplied.");

            broadband_data_transfer_daily_result results = GetResults<broadband_data_transfer_daily_result>("Broadband/broadband_usage_daily_month_year.json");
            results.username = fullUsername;
            results.year = year;
            results.month = month;
           
            return results;
        }

        /// <summary>
        /// Retrieves the hourly data transfer usage of a broadband user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>broadband_data_transfer_hourly_result.</returns>
        private broadband_data_transfer_hourly_result GetHourlyDataUsageForUserCurrentDay(string fullUsername)
        {
            broadband_data_transfer_hourly_result results = GetResults<broadband_data_transfer_hourly_result>("Broadband/broadband_usage_hourly_current_day.json");
            results.username = fullUsername;
            results.year = DateTime.Today.Year;
            results.month = DateTime.Today.Month;
            results.day = DateTime.Today.Day;

            return results;
        }

        /// <summary>
        /// Retrieves the hourly data transfer usage of a broadband user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <param name="day">Day.</param>
        /// <returns>broadband_data_transfer_hourly_result.</returns>
        private broadband_data_transfer_hourly_result GetHourlyDataUsageForUserDayMonthYear(string fullUsername, int year, int month, int day) {

            BroadbandUser broadbandUser = new BroadbandUser(fullUsername, 0, true);

            if (!Validation.ValidYear(year))
                throw new InvalidParameterException("Invalid year supplied.");

            if (!Validation.ValidMonth(month))
                throw new InvalidParameterException("Invalid month supplied.");

            broadband_data_transfer_hourly_result results = GetResults<broadband_data_transfer_hourly_result>("Broadband/broadband_usage_hourly_day_month_year.json");
            results.username = fullUsername;
            results.year = year;
            results.month = month;
            results.day = day;
            
            return results;
        }

        /// <summary>
        /// Retrieves the monthly data transfer usage of a broadband user.
        /// </summary>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>List of broadband_data_transfer_result objects.</returns>
        private List<broadband_data_transfer_monthly_result> GetMonthlyDataTransferUsage(int year, int month, string fullUsername = null) {

            if (!Validation.ValidYear(year))
                throw new InvalidParameterException("Invalid year supplied.");

            if (!Validation.ValidMonth(month))
                throw new InvalidParameterException("Invalid month supplied.");

            if (year == DateTime.Now.Year && month > DateTime.Now.Month)
                throw new InvalidParameterException("Invalid month supplied.");

            List<broadband_data_transfer_monthly_result> results = new List<broadband_data_transfer_monthly_result>();
            
            return results;

        }

        /// <summary>
        /// Retrieves the monthly data transfer usage of all broadband users.
        /// </summary>
        /// <returns>List of broadband_data_transfer_result.</returns>
        private broadband_data_transfer_monthly_results GetMonthlyDataUsageForAllCurrentMonth() {

            broadband_data_transfer_monthly_results results = GetResults<broadband_data_transfer_monthly_results>("Broadband/broadband_usage_monthly_all_users_current_month.json");
            for (int i = 0; i < results.data_transfers.Count; i++)
            {
                broadband_data_transfer_monthly_result transfer = results.data_transfers[i];
                transfer.year = DateTime.Today.Year;
                transfer.month = DateTime.Today.Month;
                results.data_transfers[i] = transfer;
            }
            return results;

        }

        /// <summary>
        /// Retrieves the monthly data transfer usage of all broadband users.
        /// </summary>
        /// <returns>List of broadband_data_transfer_result.</returns>
        private broadband_data_transfer_monthly_results GetMonthlyDataUsageForAllMonthYear(int year, int month) {

            broadband_data_transfer_monthly_results results = GetResults<broadband_data_transfer_monthly_results>("Broadband/broadband_usage_monthly_all_users_month_year.json");
            for (int i = 0; i < results.data_transfers.Count; i++)
            {
                broadband_data_transfer_monthly_result transfer = results.data_transfers[i];
                transfer.year = year;
                transfer.month = month;
                results.data_transfers[i] = transfer;
            }
            return results;

        }

        /// <summary>
        /// Retrieves the monthly data transfer usage of a broadband user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <returns>broadband_data_transfer_result.</returns>
        private broadband_data_transfer_monthly_result GetMonthlyDataUsageForUserCurrentMonth(string fullUsername) {

            broadband_data_transfer_monthly_result results = GetResults<broadband_data_transfer_monthly_result>("Broadband/broadband_usage_monthly_user_current_month.json");
            results.year = DateTime.Today.Year;
            results.month = DateTime.Today.Month;
            
            return results;
        }

        /// <summary>
        /// Retrieves the monthly data transfer usage of a broadband user.
        /// </summary>
        /// <param name="fullUsername">Username with realm.</param>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <returns>broadband_data_transfer_result.</returns>
        private broadband_data_transfer_monthly_result GetMonthlyDataUsageForUserMonthYear(string fullUsername, int year, int month) {

            broadband_data_transfer_monthly_result results = GetResults<broadband_data_transfer_monthly_result>("Broadband/broadband_usage_monthly_user_month_year.json");
            results.year = year;
            results.month = month;

            return results;

        }

    }
}