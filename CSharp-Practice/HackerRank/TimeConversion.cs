using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Practice.HackerRank {
    /*
Given a time in 12-hour AM/PM format, convert it to military (24-hour) time.
Note:  12:00:00AM on a 12-hour clock is 00:00:00 on a 24-hour clock.
12:00:00PM on a 12-hour clock is 12:00:00 on a 24-hour clock.
Example
    '12:01:00PM'
        Return '12:01:00'.
    '12:01:00AM'
        Return '00:01:00'.

    12:00:00AM --- 01:00:00AM ------ 12:00:00PM --- 01:00:00PM -- 12:00:00AM
    00:00:00-------01:00:00 ---------12:00:00 ------13:00:00 -----00:00:00

    When AM, get the hour by hour % 12
    WHEN PM, get the hour by hour + 12
     */
    public class TimeConversion {
        public TimeConversion() {
            //TweleveHoursTime time12 = (TweleveHoursTime)"01:00:00PM";

            //Twenty4HoursTime time24 = (Twenty4HoursTime)time12;

            //Console.WriteLine(time12.ToString());
            //Console.WriteLine(time24.ToString());

            Console.WriteLine(timeConversion("12:01:00PM"));
        }

        public static string timeConversion(string time) {
            var arr = time.Split(":");
            int hour = int.Parse(arr[0]);
            int minute = int.Parse(arr[1]);
            int seconds = int.Parse(arr[2].Substring(0, 2));
            string meridiem = arr[2].Substring(2);

            hour = meridiem == "AM"
                                ? hour % 12
                                : 12 + (hour % 12);

            return $"{hour:D2}:{minute:D2}:{seconds:D2}";
        }
    }

    public enum Meridiem { AM, PM }

    public abstract class Time {
        public int Hour { get;  }

        public Time(int hour, int minute, int second) {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public  int Minute { get; }
        public int Second { get; }

        public override string ToString() {
            return $"{Hour:D2}:{Minute:D2}:{Second:D2}";
        }
    }

    public class TweleveHoursTime : Time {        
        public TweleveHoursTime(int hour, int minute, int second, Meridiem meridiem) 
            : base(hour, minute, second) {
            Meridiem = meridiem;
        }

        public Meridiem Meridiem { get; }

        public override string ToString() {
            return $"{base.ToString()}{Meridiem}";
        }

        public static explicit operator Twenty4HoursTime(TweleveHoursTime time) {
            int hour = time.Meridiem == Meridiem.AM 
                            ? time.Hour % 12 
                            : 12 + (time.Hour % 12);

            return new Twenty4HoursTime(hour, time.Minute, time.Second);
        }

        public static explicit operator TweleveHoursTime(string time) {
            var arr = time.Split(":");
            int hour = int.Parse(arr[0]);
            int minute = int.Parse(arr[1]);
            int seconds = int.Parse(arr[2].Substring(0,2));
            Meridiem meridiem = (Meridiem)Enum.Parse(typeof(Meridiem), arr[2].Substring(2));

            return new TweleveHoursTime(hour, minute, seconds, meridiem);
        }
    }

    public class Twenty4HoursTime : Time {
        public Twenty4HoursTime(int hour, int minute, int second) 
            : base(hour, minute, second) {
        }
    }
}
