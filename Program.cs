namespace DelegatePractic
{
    class Program
    {
        static void Main(string[] args)
        {
            //массив операций
            KeyValuePair<char, Func<double, double, double>>[] opers =
                [
                    new KeyValuePair<char, Func<double, double, double>>('+',(x,y)=>x+y),
                    new KeyValuePair<char, Func<double, double, double>>('+',(x,y)=>x+y),
                    new KeyValuePair<char, Func<double, double, double>>('-',(x,y)=>x-y),
                    new KeyValuePair<char, Func<double, double, double>>('*',(x,y)=>x*y),
                    new KeyValuePair<char, Func<double, double, double>>('*',(x,y)=>x*y),
                    new KeyValuePair<char, Func<double, double, double>>('/',delegate(double x, double y)
                    {
                        if(y==0)
                            throw new DivideByZeroException(message:"Деление на ноль запрещено");
                        else
                            return x/y;
                    }),
                ];
            //добавление математических операций калькулятору:
            foreach (var op in opers)
            {
                try
                {
                    Calc.Add_Operation(op.Key, op.Value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.Write($"Список доступных операций: {Calc.ListOperation()}");
            do
            {
                Console.WriteLine("Введите выражение, которое надо посчитать, разделяя все элементы пробелами или Q для выхода из программы: ");
                Console.Write("Ввод: ");
                string[] buffer = Console.ReadLine().Split();
                try
                {
                    if (buffer.Length == 1)
                    {
                        if (buffer[0] == "Q" || buffer[0] == "q")
                            break;
                        else
                            throw new Exception("Невозможный ввод");
                    }
                    //будем считать, если ввели 3 параметра, то 2 из них числа и знак операции в правильном порядке
                    else if (buffer.Length == 3)
                    {
                        try
                        {
                            double res = Calc.Calculation(Convert.ToDouble(buffer[0]), Convert.ToDouble(buffer[2]), Convert.ToChar(buffer[1]));
                            Console.WriteLine($"Ответ: {res}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        throw new Exception("Невозможный ввод");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }
    }
}