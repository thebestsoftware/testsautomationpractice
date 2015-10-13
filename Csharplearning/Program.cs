using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharplearning
{
    class Program
    {
        delegate void GetMessage(); // 1. Объявляем делегат
        static void Main(string[] args)
        {
            GetMessage del; // 2. Создаем переменную делегата
            if (DateTime.Now.Hour < 12)
            {
                del = GoodMorning; // 3. Присваиваем этой переменной адрес метода
            }
            else
            {
                del = GoodEvening;
            }
            del.Invoke(); // 4. Вызываем метод
            Console.ReadLine();
        }
        private static void GoodMorning()
        {
            Console.WriteLine("Good Morning");
        }
        private static void GoodEvening()
        {
            Console.WriteLine("Good Evening");
        }
    }
}
