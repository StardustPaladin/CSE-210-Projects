using System;

namespace Foundation4
{
    public class Activity
    {
        private string _date;
        private int _lengthInMinutes;

        protected string DateString => _date;
        protected int LengthInMinutes => _lengthInMinutes;

        public Activity(string date, int lengthInMinutes)
        {
            _date = date;
            _lengthInMinutes = lengthInMinutes;
        }

        public virtual double GetDistance()
        {
            // Default: 0 distance for unknown activity
            return 0.0;
        }

        public virtual double GetSpeed()
        {
            // Default: 0 speed
            return 0.0;
        }

        public virtual double GetPace()
        {
            // Pace = minutes per mile (or per km depending on units). Default 0.
            return 0.0;
        }

        public virtual string GetSummary()
        {
            double distance = GetDistance();
            double speed = GetSpeed();
            double pace = GetPace();

            return $"{DateString} {this.GetType().Name} ({LengthInMinutes} min) - Distance {distance:F1} miles, Speed {speed:F1} mph, Pace: {pace:F2} min per mile";
        }
    }
}
