namespace DelegatePractic
{
    internal class Program
    {
        delegate void Operation(int x, int y);
        delegate int Operation2(int x, int y);
        static void Main(string[] args)
        {
            //массив анонимных методов
            Operation[] operations = [delegate(int x,int y) { Console.WriteLine(x + y); }, delegate (int x, int y) { Console.WriteLine(x - y); }, delegate (int x, int y) { Console.WriteLine(x * y); }];
            Operation? oper=null;
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                oper += operations[rnd.Next(0, operations.Length)];//добавление методов в делегат
            }
            oper(5, 4);//вызов всех методов, которые были добавлены в делегат
            var mas=oper.GetInvocationList();//список всех методов в делегате
            foreach (Operation op in mas)
            {
                if (op == Sum)
                {
                    Console.WriteLine("Sum");  
                }
                else if (op ==Diff)
                {
                    Console.WriteLine("Diff");
                }
                else if(op==Multi)
                {
                    Console.WriteLine("Multi");
                }
            }
            Operation2 op2 = delegate (int x, int y)
            {
                Console.WriteLine("Hello World");
                oper(3, 3);
                return x + y;
            };
            op2(3, 3);
        }
        static void Sum(int x, int y)
        {
            Console.WriteLine(x + y);   
        }
        static void Multi(int x, int y)
        {
            Console.WriteLine(x * y);
        }
        static void Diff(int x, int y)
        {
            Console.WriteLine(x - y);
        }
    }
}
