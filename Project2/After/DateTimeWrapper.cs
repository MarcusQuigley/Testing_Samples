using System;

namespace TestableCodeDemos.Project2.After
{
    public interface IDateTimeWrapper
    {
        DateTime GetNow();
    }
    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTime GetNow()
        {
            return DateTime.Now;
        }
    }
}
