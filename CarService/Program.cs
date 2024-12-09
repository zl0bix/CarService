using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    internal class Program
    {
        public static Random _Rnd = new Random();  
        static void Main(string[] args)
        {

            /*   У вас есть автосервис, в который приезжают люди, чтобы починить свои автомобили.
            У вашего автосервиса есть баланс денег и склад деталей.
            Когда приезжает автомобиль, у него сразу ясна его поломка, и эта поломка отображается у вас в консоли вместе с ценой за
            починку(цена за починку складывается из цены детали + цена за работу).
            Поломка всегда чинится заменой детали, но количество деталей ограничено тем, что находится на вашем складе деталей.
            Если у вас нет нужной детали на складе, то вы можете отказать клиенту, и в этом случае вам придется выплатить штраф.
            Если вы замените не ту деталь, то вам придется возместить ущерб клиенту.
            За каждую удачную починку вы получаете выплату за ремонт, которая указана в чек-листе починки.
            Класс Деталь не может содержать значение “количество”. Деталь всего одна, за количество отвечает тот, кто хранит детали. 
            При необходимости можно создать дополнительный класс для конкретной детали и работе с количеством.*/
           
            Sklad sklad = new Sklad();
            BMW bmw = new BMW();
            Servis servis = new Servis();
            servis.GetWork(bmw.GetQueueCars());
            
        }
    }

    abstract class Cars 
    {
        public Cars(string name)
        {
            this.name = name;
        }

        string[] _detals = new string[] { "Колесо", "Капот", "Крыло", "Стекло", "Крыша", "Дверь", "Молдинг" };

        string name;
        public List<string> GetQueueCars()
        {
            List<string> _queueCars = new List<string>();
            int numTmp = Program._Rnd.Next(1,5);

            while(numTmp != 0)
            {
                _queueCars.Add(_detals[Program._Rnd.Next(1, 7)]);
                numTmp--;
            }
            return _queueCars;
        }

        public void ShowQueueCars(List<string> strings)
        {
            foreach(string iterator in strings)
            {
                Console.Write(iterator + " ");
            }
        }
    }

    class Servis
    {
        public static int money = 1000;
        
        public List<string> GetWork(List<string>cars)
        {   Sklad sklad = new Sklad();
            List<string> detals = sklad.GetDetalsToSklad();

            while (cars.Count > 0 && detals.Count > 0 && money > 0)
            {
                Console.WriteLine("Ваши деньги - " + money);
                Console.Write("Машина приехала с такими дефектами -> ");
                ShowListLine(cars);
                Console.WriteLine("Товары на складе:");
                ShowListRow(detals);
                Console.WriteLine("Нажмите любую клавишу для запуска сервиса!!!");

                if (detals.Count > 0 && cars.Count > 0)
                {
                    detals.RemoveAt(detals.IndexOf(cars.First()));

                    cars.RemoveAt(cars.IndexOf(cars.First()));

                }
                else
                {
                    Console.WriteLine("Переходим к следующей машине!!!");

                }
                Console.ReadKey();
                Console.Clear();

                

            }

            return detals;

        }

        public void ShowListLine(List<string> values)
        {
           foreach (string iterator in values)

                Console.Write(iterator + " ");
        }
        public void ShowListRow(List<string> values)
        {
            foreach (string iterator in values)

                Console.WriteLine(iterator);
        }

    }

    class Sklad
    {
        string[] _detals = new string[] { "Колесо", "Капот", "Крыло", "Стекло", "Крыша", "Дверь", "Молдинг" };
        public List<string> GetDetalsToSklad()
        {
            List<string> _servisDetals = new List<string>();
            int numTmp = Program._Rnd.Next(11,21);

            while(numTmp != 0)
            {
                _servisDetals.Add(_detals[Program._Rnd.Next(0, 7)]);
                numTmp--;
            }
            return _servisDetals;
        }

        public void ShowDetalsToSklad(List<string> strings)
        {
            foreach (string iterator in strings)
            {
                Console.WriteLine(iterator);
            }
        }    
    }

    class BMW : Cars
    {
        public BMW() : base("BMW") { }
    }

    class Mercedes : Cars
    {
        public Mercedes() : base("Mercedes") { }
    }

    class Volkswagen : Cars
    {
        public Volkswagen() : base("Volkswagen") { }
    }



}
