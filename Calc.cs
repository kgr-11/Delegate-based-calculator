using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePractic
{
    public class Calc
    {
        //таблица диспетчеризации
        private Dictionary<char, Func<double, double, double>> operations;
        public Calc()
        {
            operations = new Dictionary<char, Func<double, double, double>>();
        }
        public void Add_Operation(char sym, Func<double, double, double> newOp)
        {
            if (!operations.ContainsKey(sym))
                operations.Add(sym, newOp);
            else
                throw new Exception("Данная операция уже была добавлена ранее!");
        }

        public double Calculation(double a, double b, char symOp)
        {
            if (operations.ContainsKey(symOp))
            {
                return operations[symOp].Invoke(a, b);
            }
            else
                throw new Exception("Данная операция еще не была добавлена");
        }

    }
}
