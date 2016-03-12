using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MizaniaServeur.Models
{
    /*rassemble les fonctions qui sont utiles mais qui n'apparatiennent pas forcement à une class en particulier */
    public class Utilitaire
    {
        public static DateTime setYear(DateTime t, int year)
        {
            return new DateTime(year, t.Month, t.Day, t.Hour, t.Minute, t.Second);
        }
        public static DateTime setMonth(DateTime t, int month)
        {
            return new DateTime(t.Year, month, t.Day, t.Hour, t.Minute, t.Second);
        }
        public static DateTime setDay(DateTime t, int day)
        {
            return new DateTime(t.Year, t.Month, day, t.Hour, t.Minute, t.Second);
        }
        public static DateTime setHour(DateTime t, int hour)
        {
            return new DateTime(t.Year, t.Month, t.Day, hour, t.Minute, t.Second);
        }
        public static DateTime setMinute(DateTime t, int minute)
        {
            return new DateTime(t.Year, t.Month, t.Day, t.Hour, minute, t.Second);
        }
        public static DateTime setSecond(DateTime t, int second)
        {
            return new DateTime(t.Year, t.Month, t.Day, t.Hour, t.Minute, second);
        }


    }
}