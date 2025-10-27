using System;

namespace Foundation3
{
    public class ReceptionEvent : Event
    {
        private string _rsvpEmail;

        public ReceptionEvent(string title, string description, string date, string time, Address address, string rsvpEmail)
            : base(title, description, date, time, address)
        {
            _rsvpEmail = rsvpEmail;
        }

        public override string GetFullDetails()
        {
            return $"{base.GetStandardDetails()}\nType: Reception\nRSVP Email: {_rsvpEmail}";
        }
    }
}
