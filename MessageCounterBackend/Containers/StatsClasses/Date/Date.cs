using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageCounterBackend.Containers.StatsClasses.Date
{
    public class Date : IComparable<Date>
    {
        public DateTime DateTime { get; }
        public int Year { get; }
        public int Month { get; }
        public int Day { get; }

        public Date(ulong miliseconds)
        {
            DateTime = new DateTime(1970, 1, 1).AddMilliseconds(miliseconds);
            Year = DateTime.Year;
            Month = DateTime.Month;
            Day = DateTime.Day;
        }

        public override string ToString() => this.DateTime.ToShortDateString();

        public override bool Equals(object obj)
        {
            return obj is Date date &&
                     this.Year == date.Year &&
                     this.Month == date.Month &&
                     this.Day == date.Day;
        }

        public override int GetHashCode()
        {
            var hashCode = 592158470;
            hashCode = hashCode * -1521134295 + this.Year.GetHashCode();
            hashCode = hashCode * -1521134295 + this.Month.GetHashCode();
            hashCode = hashCode * -1521134295 + this.Day.GetHashCode();
            return hashCode;
        }

        public int CompareTo(Date other)
        {
            int result;

            if (( result = this.Year.CompareTo(other.Year) ) != 0)
                return result;

            if (( result = this.Month.CompareTo(other.Month) ) != 0)
                return result;

            if (( result = this.Day.CompareTo(other.Day) ) != 0)
                return result;

            return 0;
        }
    }
}
