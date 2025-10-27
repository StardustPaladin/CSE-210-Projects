using System;

namespace Foundation4
{
    public class RunningActivity : Activity
    {
        private double _distance; // miles

        public RunningActivity(string date, int lengthInMinutes, double distance)
            : base(date, lengthInMinutes)
        {
            _distance = distance;
        }

        public override double GetDistance()
        {
            return _distance;
        }

        public override double GetSpeed()
        {
            // mph = (distance / minutes) * 60
            return (_distance / LengthInMinutes) * 60.0;
        }

        public override double GetPace()
        {
            // minutes per mile
            return (double)LengthInMinutes / _distance;
        }

        public override string GetSummary()
        {
            return $"{DateString} Running ({LengthInMinutes} min) - Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
        }
    }
}
