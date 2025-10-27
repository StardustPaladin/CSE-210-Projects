using System;

namespace Foundation4
{
    public class CyclingActivity : Activity
    {
        private double _speed; // mph

        public CyclingActivity(string date, int lengthInMinutes, double speed)
            : base(date, lengthInMinutes)
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            // distance = speed * hours
            double hours = (double)LengthInMinutes / 60.0;
            return _speed * hours;
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetPace()
        {
            // pace = minutes per mile = 60 / speed
            if (_speed <= 0) return 0.0;
            return 60.0 / _speed;
        }

        public override string GetSummary()
        {
            return $"{DateString} Cycling ({LengthInMinutes} min) - Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
        }
    }
}
