using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePractic
{
    public static class Calc
    {
        //таблица диспетчеризации
        private static Dictionary<char, Func<double, double, double>> operations;

        //статический конструктор вызовется 1 раз, только перед первым обращением, чтобы инициализировать объект
        static Calc() { operations = new Dictionary<char, Func<double, double, double>>(); }
        public static void Add_Operation(char sym, Func<double, double, double> newOp)
        {
            if (!operations.ContainsKey(sym))
                operations.Add(sym, newOp);
            else
                throw new Exception($"Повторное добавление операции {sym}");
        }

        public static double Calculation(double a, double b, char symOp)
        {
            if (operations.ContainsKey(symOp))
            {
                return operations[symOp].Invoke(a, b);
            }
            else
                throw new Exception($"Операция {symOp} еще не была добавлена");
        }
        public static string ListOperation()
        {
            string list="\n";
            foreach (char sym in operations.Keys)
            { 
                list+= sym+"\n";
            }
            return list;
        }

    }
}
