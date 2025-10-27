using System;

namespace Foundation3
{
    public class LectureEvent : Event
    {
        private string _speaker;
        private int _capacity;

        public LectureEvent(string title, string description, string date, string time, Address address, string speaker, int capacity)
            : base(title, description, date, time, address)
        {
            _speaker = speaker;
            _capacity = capacity;
        }

        public override string GetFullDetails()
        {
            return $"{base.GetStandardDetails()}\nType: Lecture\nSpeaker: {_speaker}\nCapacity: {_capacity}";
        }
    }
}
