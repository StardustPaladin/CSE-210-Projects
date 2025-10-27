using System;

namespace Foundation3
{
    class Program
    {
        static void Main(string[] args)
        {
            var hallAddress = new Address("123 University Ave", "College Town", "State", "USA");
            var receptionAddress = new Address("456 Market St", "Cityville", "State", "USA");
            var parkAddress = new Address("789 Lakeside Rd", "Park City", "State", "USA");

            var lecture = new LectureEvent(
                "The Future of AI",
                "A public lecture on the future and ethics of AI",
                "2025-11-15",
                "19:00",
                hallAddress,
                "Dr. Ada Lovelace",
                150);

            var reception = new ReceptionEvent(
                "Community Mixer",
                "Networking and refreshments",
                "2025-12-01",
                "18:00",
                receptionAddress,
                "rsvp@example.org");

            var outdoor = new OutdoorEvent(
                "Summer Concert",
                "An outdoor concert featuring local bands",
                "2026-06-20",
                "17:00",
                parkAddress,
                "Mostly Sunny, chance of light breeze");

            PrintEventMessages(lecture);
            PrintEventMessages(reception);
            PrintEventMessages(outdoor);
        }

        static void PrintEventMessages(Event ev)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("STANDARD DETAILS:\n");
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine("FULL DETAILS:\n");
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine("SHORT DESCRIPTION:\n");
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine();
        }
    }
}