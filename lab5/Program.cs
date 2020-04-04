using System;
using System.Collections.Generic;

namespace lab5
{
    /// <summary>
    /// класс основной программы
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                Handler h1 = new ConcreteHandler1_FaQ();
                Handler h2 = new ConcreteHandler2_Oper();
                Handler h3 = new ConcreteHandler3_eng();
                h1.Successor = h2;
                h2.Successor = h3;
                int k;
                //у пользователя должна быть возможность обратиться сразу к нужному обработчику
                Console.WriteLine("Выберете с чего начать поиск ответа на вопрос:\n" +
                    "1). Раздел: Часто задаваемемые вопросы\n" +
                    "2). Связаться с оператором\n" +
                    "3). Связаться с инженером");
                k = Convert.ToInt32(Console.ReadLine());
                while (1>k || k>3)
                {
                    Console.WriteLine("Ошибка. Введите число от 1 до 3");
                    k = Convert.ToInt32(Console.ReadLine());
                }
                h1.HandleRequest(k);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
    /// <summary>
    /// абстрактный класс для всех обработчиков
    /// </summary>
    abstract class Handler
    {
        /// <summary>
        /// следующий в цепи обработчиков
        /// </summary>
        public Handler Successor { get; set; }
        /// <summary>
        /// обращение к обработчику
        /// </summary>
        /// <param name="condition">номер обработчика</param>
        public abstract void HandleRequest(int condition);
    }
    /// <summary>
    /// класс первой ситуации, вывод к FaQ
    /// </summary>
    class ConcreteHandler1_FaQ : Handler
    {
        public override void HandleRequest(int condition)
        {
            string s="";
            if (condition == 1)
            {
                Console.WriteLine("--------------------обработка запроса к FaQ--------------------");
                Console.WriteLine("Запрос к FaQ помог?(да/нет)");
                s = Console.ReadLine();
                while (s!="да" && s != "нет")
                {
                    Console.WriteLine("Ошибка. Введите да или нет");
                    s = Console.ReadLine();
                }
                if (s=="нет")
                {
                    Successor.HandleRequest(condition+1);
                }
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(condition);
            }
        }
    }
    /// <summary>
    /// класс второй ситуации, обращение к оператору
    /// </summary>
    class ConcreteHandler2_Oper : Handler
    {
        public override void HandleRequest(int condition)
        {
            string s = "";
            if (condition == 2)
            {
                Console.WriteLine("--------------------обработка запроса к оператору--------------------");
                Console.WriteLine("Вызов оператора помог?(да/нет)");
                s = Console.ReadLine();
                while (s !=  "да" && s != "нет")
                {
                    Console.WriteLine("Ошибка. Введите да или нет");
                    s = Console.ReadLine();
                }
                if (s == "нет")
                {
                    Successor.HandleRequest(condition + 1);
                }
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(condition);
            }
        }
    }
    /// <summary>
    /// класс обработки третей ситуации, обращение к инженеру
    /// </summary>
    class ConcreteHandler3_eng : Handler
    {
        public override void HandleRequest(int condition)
        {
            if (condition == 3)
            {
                Console.WriteLine("Вызов инженера");
            }
            
        }
    }
}