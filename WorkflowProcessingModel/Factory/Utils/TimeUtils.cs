using System;
using System.Globalization;

namespace WorkflowProcessingModel.Factory
{
    class TimeUtils
    {
        public const int SecInMinute = 60;
        public const int SecInHour = 60 * SecInMinute;
        public const int SecInShift = 8 * SecInHour;
        public const int SecInWorkingDay = 2 * SecInShift; // working day = 16 hours

        /// <summary>
        /// Format: dd.MM.yyyy hh:mm:ss
        /// </summary>
        public static DateTime GetDateTime(string dateTime)
        {
            return DateTime.ParseExact(dateTime, "dd.MM.yyyy hh:mm:ss", CultureInfo.InvariantCulture);
        }

    }
}
