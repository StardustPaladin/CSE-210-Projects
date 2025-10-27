using System;

namespace Foundation4
{
    public class SwimmingActivity : Activity
    {
        private int _laps;

        public SwimmingActivity(string date, int lengthInMinutes, int laps)
            : base(date, lengthInMinutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            // using miles: laps * 50 meters -> km -> miles
            double km = _laps * 50.0 / 1000.0;
            double miles = km * 0.62;
            return miles;
        }

        public override double GetSpeed()
        {
            double distance = GetDistance();
            if (LengthInMinutes <= 0) return 0.0;
            return (distance / LengthInMinutes) * 60.0;
        }

        public override double GetPace()
        {
            double distance = GetDistance();
            if (distance <= 0) return 0.0;
            return (double)LengthInMinutes / distance;
        }

        public override string GetSummary()
        {
            return $"{DateString} Swimming ({LengthInMinutes} min) - Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
        }
    }
}
