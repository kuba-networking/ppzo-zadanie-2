using System;
using System.Collections.Generic;
using System.Linq;

namespace PlannerPodrozy
{
    public class Activity
    {
        public string Name { get; }
        public string Time { get; }
        public double DurationHours { get; }

        public Activity(string name, string time, double durationHours)
        {
            Name = name;
            Time = time;
            DurationHours = durationHours;
        }

        public override string ToString()
        {
            return $"[{Time}] {Name} ({DurationHours} godz.)";
        }
    }

    public class Destination
    {
        public string City { get; }
        public string Country { get; }
        public List<Activity> Activities { get; } = new List<Activity>();

        public Destination(string city, string country)
        {
            City = city;
            Country = country;
        }

        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }

        public double TotalDuration()
        {
            return Activities.Sum(a => a.DurationHours);
        }

        public void ShowSchedule()
        {
            Console.WriteLine($"Cel: {City}, {Country} (Łączny czas atrakcji: {TotalDuration()} godz.)");
            if (Activities.Count == 0)
            {
                Console.WriteLine("  - Brak zaplanowanych atrakcji.");
                return;
            }

            foreach (var activity in Activities)
            {
                Console.WriteLine($"  - {activity}");
            }
        }
    }

    public class Trip
    {
        public string Title { get; }
        public string StartDate { get; }
        public List<Destination> Destinations { get; } = new List<Destination>();

        public Trip(string title, string startDate)
        {
            Title = title;
            StartDate = startDate;
        }

        public void AddDestination(Destination destination)
        {
            Destinations.Add(destination);
        }

        public double TotalTripHours()
        {
            return Destinations.Sum(d => d.TotalDuration());
        }

        public void ShowItinerary()
        {
            Console.WriteLine($"=== Plan podróży: {Title} | Data startu: {StartDate} ===");
            Console.WriteLine($"Łączny czas zaplanowanych atrakcji: {TotalTripHours()} godz.\n");

            foreach (var destination in Destinations)
            {
                destination.ShowSchedule();
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var trip = new Trip("Wycieczka po Włoszech", "2026-07-10");

            var rome = new Destination("Rzym", "Włochy");
            rome.AddActivity(new Activity("Zwiedzanie Koloseum", "09:00", 2.5));
            rome.AddActivity(new Activity("Fontanna di Trevi i spacer", "13:00", 1.5));

            var florence = new Destination("Florencja", "Włochy");
            florence.AddActivity(new Activity("Galeria Uffizi", "10:00", 3.0));
            florence.AddActivity(new Activity("Ponte Vecchio", "14:30", 1.0));

            trip.AddDestination(rome);
            trip.AddDestination(florence);
            trip.ShowItinerary();
        }
    }
}
