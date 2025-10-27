using System;

namespace Foundation3
{
    public class OutdoorEvent : Event
    {
        private string _weather;

        public OutdoorEvent(string title, string description, string date, string time, Address address, string weather)
            : base(title, description, date, time, address)
        {
            _weather = weather;
        }

        public override string GetFullDetails()
        {
            return $"{base.GetStandardDetails()}\nType: Outdoor\nWeather: {_weather}";
        }
    }
}
