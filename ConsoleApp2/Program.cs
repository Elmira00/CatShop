using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CatShop
{

    public class Cat
    {
        public Cat( string name, string breed, int mass)
        {
            Name = name;
            Breed = breed;
            Mass = mass;
        }

        public string Name { get; set; }
        public string Breed { get; set; }
        public int Mass { get; set; }
        public int Energy { get; set; } = 50;
        public int Consume { get; set; }
       

        

        public void Eat()
        {
            Mass += 1;//he gains 1 kg of weight ,when he eats
            Consume += 1;
            Energy += 10;// he gets energy ,when he eats
        }
        public void Play()
        {
            if (Energy < 20)
            {           
            var randNum = new Random().Next(1, 15);
            if (randNum == 1)
            {
                Eat();
            }
            else if (randNum == 15)
            {
                    Sleep();
            }
         }
            else
            {
                Energy -= 10;//he loses his energy ,when he plays

            }
        }
        public void Sleep()
        {
            Energy += 10;//he gets more energy ,when he sleeps
        }
        public int GetMass()
        {
            return Mass;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine($"Name:    {Name}");
            Console.WriteLine($"Breed:   {Breed}");
            Console.WriteLine($"Mass:    {Mass}kg");
            Console.WriteLine($"Energy:  {Energy}");
            Console.WriteLine($"Consume: {Consume}kg");
            Console.WriteLine();
            Console.ResetColor();
        }
    }

    public class CatShop
    {
        public CatShop(string name, string location)
        {
            Name = name;
            Location = location;
            Id = CatShopId++;
        }

        public string Name { get; set; }
        public string Location { get; set; }
        public static int CatShopId { get; set; } = 1;
        public int Id { get; set; }

        public CatHouse[] CatHouses { get; set; }
        public int CountOfCatHouses { get; set; } = 0;

        public void AddCatHouse(CatHouse newCatHouse)
        {
            CatHouse[] temp = new CatHouse[++CountOfCatHouses];
            if (CatHouses != null)
            {
                CatHouses.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = newCatHouse;
            CatHouses = temp;

        }
        public int GetTotalMass()
        {
            int totalMass = 0;
            if (CatHouses != null)
            {
                foreach (var catHouse in CatHouses)
                {
                    totalMass += catHouse.GetTotalMass();
                }
            }
            return totalMass;
        }

        public int GetTotalConsume()
        {
            int totalConsume = 0;
            if (CatHouses != null)
            {
                foreach (var catHouse in CatHouses)
                {
                    totalConsume += catHouse.GetTotalConsume();
                }
            }
            return totalConsume;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("========== Cat Shop=============");
            Console.WriteLine($"ID : {Id}");
            Console.WriteLine($"Location : {Location}");
            Console.WriteLine($"Toal Mass : {GetTotalMass()}kg");
            Console.WriteLine($"Toal Consume : {GetTotalConsume()}kg");
            Console.WriteLine();
            Console.ResetColor();
        }
        public void ShowCathouses()
        {

            if (CatHouses != null)
                foreach (var catHouse in CatHouses)
                {
                    catHouse.Show();
                    Console.WriteLine();
                }
        }

    }
    public class CatHouse
    {
        public Cat[] Cats { get; set; }
        public int CountOfCats { get; set; } = 0;
        public string Name { get; set; }
        public static int CatHouseId { get; set; } = 1;
        public int Id { get; set; }


        public CatHouse(in string name)
        {
            this.Name = name;
            this.Id = CatHouseId++;
        }
        public void AddCat(Cat newCat)
        {
            Cat[] temp = new Cat[++CountOfCats];
            if (Cats != null)
            {
                Cats.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = newCat;
            Cats = temp;
        }

        public  int GetTotalMass()
        {
            int totalMass = 0;
            if (Cats != null)
            {
                foreach (var  cat in Cats)
                {
                    totalMass += cat.GetMass();
                }
            }
            return totalMass;
        }

        public int GetTotalConsume()
        {
            int totalConsume = 0;
            if (Cats != null)
            {
                foreach (var cat in Cats)
                {
                    totalConsume += cat.Consume;
                 }
            }
            return totalConsume;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("========== Cat House =============");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"Total Mass : {GetTotalMass()}kg");
            Console.WriteLine($"Total Consume : {GetTotalConsume()}kg");
            Console.ResetColor();
            Console.WriteLine();
            ShowCats();
        }
        public void ShowCats()
        {
            if (Cats != null)
                foreach (var cat in Cats)
                {
                    cat.Show();
                    Console.WriteLine();
                }
        }
    }
   
    public class Controller
    {
        public  static void Start()
        {
            Cat cat1 = new Cat("Bambi", "Ragdoll", 7);
            Cat cat2 = new Cat("Alaska", "Persian", 6);
            Cat cat3 = new Cat("Cinnamon", "Sphynx", 5);
            Cat cat4 = new Cat("Dizzy", "Siamese", 2);
            Cat cat5 = new Cat("Kiwi", "Bengal", 6);
            Cat cat6 = new Cat("Enigma", "Siberian",9);
            Cat cat7 = new Cat("Giggles", "Birman", 5);

            CatHouse catHouse1 = new CatHouse("Cutties");
            CatHouse catHouse2 = new CatHouse("Little Paws");
            CatHouse catHouse3 = new CatHouse("Sweet Roar");

            catHouse1.AddCat(cat1);
            catHouse1.AddCat(cat2);
            catHouse1.AddCat(cat3);

            catHouse2.AddCat(cat4);
            catHouse2.AddCat(cat5);

            catHouse3.AddCat(cat6);
            catHouse3.AddCat(cat7);

            CatShop myCatShop = new CatShop("Happy Home", "Ganjlik");
            myCatShop.AddCatHouse(catHouse1);
            myCatShop.AddCatHouse(catHouse2);
            myCatShop.AddCatHouse(catHouse3);

            do
            {
                myCatShop.Show();
                myCatShop.ShowCathouses();
                cat1.Play();
                cat2.Play();
                cat3.Play();
                cat4.Play();
                cat5.Play();
                cat6.Play();
                cat7.Play();
                Thread.Sleep(500);
                Console.Clear();
            } while (cat1.Energy != 0 || cat2.Energy != 0 || cat3.Energy != 0|| cat4.Energy != 0|| cat5.Energy != 0|| cat6.Energy != 0|| cat7.Energy != 0);
            myCatShop.Show();
            myCatShop.ShowCathouses();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Controller.Start();
        }
    }
}
