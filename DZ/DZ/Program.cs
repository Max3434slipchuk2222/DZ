using System;
using System.Collections.Generic;
namespace EventTesting
{
    public class Animals
    {
        public string Poroda { get; set; }
        public string Vyd { get; set; }
        public float Vaga { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public Animals()
        {
            Poroda = null;
            Vyd = null;
            Vaga = 0;
            Age = 0;
            Name = null;
        }

        public Animals(string poroda, string vyd, float vaga, int age, string name)
        {
            Poroda = poroda;
            Vyd = vyd;
            Vaga = vaga;
            Age = age;
            Name = name;
        }

        public override string ToString()
        {
            return $"Порода: {Poroda}, Вид: {Vyd}, Вага: {Vaga}, Вік: {Age}, Ім'я: {Name}";
        }
    }

    delegate void CheckedAnimals(string message);

    class VeterynarPrijom
    {
        public event CheckedAnimals Pryjom;

        public void Veterynar(List<Animals> animals)
        {
            var random = new Random();
            int time = 0;

            foreach (var animal in animals)
            {
                int newtime = random.Next(1, 40);
                time += newtime;
                Console.WriteLine($"Тварина {animal.Name} обслуговується {newtime} хвилин.");
            }

            Checked($"Прийом у ветеринара закінчено. Усі тварини були оглянуті за {time} хвилин.");
        }

        protected virtual void Checked(string message)
        {
            if (Pryjom != null)
            {
                Pryjom.Invoke(message);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var veterynar = new VeterynarPrijom();

            int count = 10;

            var animals = new List<Animals>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введіть дані для тварини №{i + 1}:");

                Console.Write("Ім'я: ");
                string name = Console.ReadLine();

                Console.Write("Вид: ");
                string vyd = Console.ReadLine();

                Console.Write("Порода: ");
                string poroda = Console.ReadLine();

                Console.Write("Вага (в кг): ");
                float vaga = float.Parse(Console.ReadLine());

                Console.Write("Вік (у роках): ");
                int age = int.Parse(Console.ReadLine());

                animals.Add(new Animals
                {
                    Poroda = poroda,
                    Vyd = vyd,
                    Vaga = vaga,
                    Age = age,
                    Name = name
                });
            }

            Console.WriteLine("\nТварини на прийом до ветеринара:");
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
            veterynar.Pryjom += (message) => { Console.WriteLine(message); };

            veterynar.Veterynar(animals);
        }

    }
}


