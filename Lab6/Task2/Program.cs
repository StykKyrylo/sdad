using System;

namespace DesignPatterns.Mediator
{
    class Program
    {
        static void Main()
        {
            CommandCentre commandCentre = new CommandCentre();

            Runway runway1 = new Runway(commandCentre, "Runway 1");
            Runway runway2 = new Runway(commandCentre, "Runway 2");

            Aircraft aircraft1 = new Aircraft(commandCentre, "Aircraft 1");
            Aircraft aircraft2 = new Aircraft(commandCentre, "Aircraft 2");

            aircraft1.Land();
            aircraft2.Land();

            aircraft1.TakeOff();
            aircraft2.TakeOff();

            Console.ReadLine();
        }
    }

    // Посередник
    class CommandCentre
    {
        public void NotifyRunwayLanding(Aircraft aircraft, Runway runway)
        {
            Console.WriteLine($"{aircraft.Name} has landed on {runway.Name}.");
        }

        public void NotifyTakeOff(Aircraft aircraft, Runway runway)
        {
            Console.WriteLine($"{aircraft.Name} has taken off from {runway.Name}.");
        }
    }

    // Клас Runway тепер не "знає" про Aircraft і навпаки
    class Runway
    {
        private readonly CommandCentre commandCentre;

        public string Name { get; }
        public Aircraft? IsBusyWithAircraft { get; set; }

        public Runway(CommandCentre commandCentre, string name)
        {
            this.commandCentre = commandCentre;
            this.Name = name;
        }

        public void HighLightRed()
        {
            Console.WriteLine($"Runway {Name} highlighted in red.");
        }

        public void HighLightGreen()
        {
            Console.WriteLine($"Runway {Name} highlighted in green.");
        }

        public void Land(Aircraft aircraft)
        {
            Console.WriteLine($"Checking runway.");
            if (IsBusyWithAircraft == null)
            {
                Console.WriteLine($"{aircraft.Name} has landed on {Name}.");
                IsBusyWithAircraft = aircraft;
                HighLightRed();
                commandCentre.NotifyRunwayLanding(aircraft, this);
            }
            else
            {
                Console.WriteLine($"Could not land, the runway {Name} is busy.");
            }
        }

        public void TakeOff(Aircraft aircraft)
        {
            Console.WriteLine($"{aircraft.Name} is taking off from {Name}.");
            IsBusyWithAircraft = null;
            HighLightGreen();
            commandCentre.NotifyTakeOff(aircraft, this);
        }
    }

    // Клас Aircraft тепер не "знає" про Runway
    class Aircraft
    {
        private readonly CommandCentre commandCentre;

        public string Name { get; }

        public Aircraft(CommandCentre commandCentre, string name)
        {
            this.commandCentre = commandCentre;
            this.Name = name;
        }

        public void Land()
        {
            commandCentre.NotifyRunwayLanding(this, null!);
        }

        public void TakeOff()
        {
            commandCentre.NotifyTakeOff(this, null!);
        }
    }
}
