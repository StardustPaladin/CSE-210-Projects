using System;

namespace Foundation3
{
    public class Event
    {
        private string _title;
        private string _description;
        private string _date;
        private string _time;
        private Address _address;

        public Event(string title, string description, string date, string time, Address address)
        {
            _title = title;
            _description = description;
            _date = date;
            _time = time;
            _address = address;
        }

        public string GetStandardDetails()
        {
            return $"Title: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress:\n{_address.GetFullAddress()}";
        }

        public virtual string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: General Event";
        }

        public string GetShortDescription()
        {
            return $"Type: {this.GetType().Name}\nTitle: {_title}\nDate: {_date}";
        }
    }
}
