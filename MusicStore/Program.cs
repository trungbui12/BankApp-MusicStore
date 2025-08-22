using System;
using System.Collections.Generic;

namespace MusicStore
{
    // Base Instrument
    public abstract class Instrument
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public Instrument(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public abstract void Play();
        public abstract void ShowInfo();
    }

    // Guitar
    public class Guitar : Instrument
    {
        public int Strings { get; set; }

        public Guitar(string name, int year, int strings) : base(name, year)
        {
            Strings = strings;
        }

        public override void Play()
        {
            Console.WriteLine($"{Name} is playing with {Strings} strings!");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Instrument: {Name}, Year: {Year}, Strings: {Strings}");
        }
    }

    // Piano
    public class Piano : Instrument
    {
        public int Keys { get; set; }

        public Piano(string name, int year, int keys) : base(name, year)
        {
            Keys = keys;
        }

        public override void Play()
        {
            Console.WriteLine($"{Name} is playing with {Keys} keys!");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Instrument: {Name}, Year: {Year}, Keys: {Keys}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Instrument> instruments = new List<Instrument>()
            {
                new Guitar("Acoustic Guitar", 2020, 6),
                new Guitar("Electric Guitar", 2021, 7),
                new Piano("Grand Piano", 2019, 88),
                new Piano("Digital Piano", 2022, 76),
                new Guitar("Bass Guitar", 2018, 4)
            };

            Console.WriteLine("===== Instrument List =====");
            foreach (var instrument in instruments)
            {
                instrument.ShowInfo();
                instrument.Play();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
