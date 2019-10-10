using System;
using System.Globalization;

namespace WorkflowProcessingModel.Factory
{
    class TimeUtils
    {
        public const int SecInMinute = 60;
        public const int SecInHour = 60 * SecInMinute;
        public const int SecInShift = 8 * SecInHour;
        public const int SecInDay = 3 * SecInShift; // working day = 24 hours

        public static int SecIn(string charMark)
        {
            switch (charMark)
            {
                case "m":
                    return SecInMinute;
                case "h":
                    return SecInHour;
                case "s":
                    return SecInShift;
                case "d":
                    return SecInDay;
            }
            return 1;
        }

        /// <summary>
        /// Format: dd.MM.yyyy hh:mm:ss
        /// </summary>
        public static DateTime GetDateTime(string dateTime)
        {
            return DateTime.ParseExact(dateTime, "dd.MM.yyyy hh:mm:ss", CultureInfo.InvariantCulture);
        }

    }
}
