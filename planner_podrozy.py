class Activity:
    def __init__(self, name: str, time: str, duration_hours: float):
        self.name = name
        self.time = time
        self.duration_hours = duration_hours

    def __str__(self) -> str:
        return f"[{self.time}] {self.name} ({self.duration_hours} godz.)"


class Destination:
    def __init__(self, city: str, country: str):
        self.city = city
        self.country = country
        self.activities: list[Activity] = []

    def add_activity(self, activity: Activity) -> None:
        self.activities.append(activity)

    def total_duration(self) -> float:
        return sum(activity.duration_hours for activity in self.activities)

    def show_schedule(self) -> None:
        print(f"Cel: {self.city}, {self.country} (Łączny czas atrakcji: {self.total_duration()} godz.)")
        if not self.activities:
            print("  - Brak zaplanowanych atrakcji.")
            return
        for activity in self.activities:
            print(f"  - {activity}")


class Trip:
    def __init__(self, title: str, start_date: str):
        self.title = title
        self.start_date = start_date
        self.destinations: list[Destination] = []

    def add_destination(self, destination: Destination) -> None:
        self.destinations.append(destination)

    def total_trip_hours(self) -> float:
        return sum(dest.total_duration() for dest in self.destinations)

    def show_itinerary(self) -> None:
        print(f"=== Plan podróży: {self.title} | Data startu: {self.start_date} ===")
        print(f"Łączny czas zaplanowanych atrakcji: {self.total_trip_hours()} godz.\n")
        for destination in self.destinations:
            destination.show_schedule()
            print()


if __name__ == "__main__":
    trip = Trip("Wycieczka po Włoszech", "2026-07-10")

    rome = Destination("Rzym", "Włochy")
    rome.add_activity(Activity("Zwiedzanie Koloseum", "09:00", 2.5))
    rome.add_activity(Activity("Fontanna di Trevi i spacer", "13:00", 1.5))

    florence = Destination("Florencja", "Włochy")
    florence.add_activity(Activity("Galeria Uffizi", "10:00", 3.0))
    florence.add_activity(Activity("Ponte Vecchio", "14:30", 1.0))

    trip.add_destination(rome)
    trip.add_destination(florence)
    trip.show_itinerary()
