using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR9
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] mass = new int[rand.Next(5, 20)];

            Task Base = new Task(
                () =>
                {
                    Console.WriteLine("Базовая задача. Старт");
                    for (int i = 0; i < mass.Length; i++)
                    {
                        mass[i] = rand.Next(0, 20);
                    }

                    for (int i = 0; i < mass.Length; i++)
                    {
                        Console.Write(mass[i] + " ");
                    }

                    Console.WriteLine("Базовая задача. Конец");
                });

            Task Cont1 = Base.ContinueWith(
                base_task => {
                    //Console.WriteLine("Задача {0}. Конец", base_task.Id);
                    Console.WriteLine("Продолдение 1. Начало");
                    int summ = 0;
                    for (int i = 0; i < mass.Length; i++)
                    {
                        if (mass[i] % 2 == 0)
                        {
                            summ += mass[i];
                        }
                    }
                    Console.WriteLine("Продолдение 1. Конец. Сумма = {0}", summ);
                }
                );
            Task Cont2 = Base.ContinueWith(
                base_task => {
                    //Console.WriteLine("Задача {0}. Конец", base_task.Id);
                    Console.WriteLine("Продолдение 2. Начало");
                    int summ = 0;
                    for (int i = 0; i < mass.Length; i++)
                    {
                        if (mass[i] % 3 == 0)
                        {
                            summ++;
                        }
                    }
                    Console.WriteLine("Продолдение 2. Конец. Чесел кратных 3 = {0}", summ);
                }
                );

            Base.Start();

            Console.ReadKey();
        }
    }
}

