using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Reflection;namespace Lab6_1{
    
    class Program    {

        delegate object Operation(int i, double d);

        static object Sum(int i, double d)
        {
            object result = (double)i + d;
            return result;
        }


        static void Act(int i, double d)
        {
            double result = (double)i + d;
            Console.WriteLine(result.ToString());
        }

        static object MethodSum(int i, double d, Operation par)
        {
            object result = par(i, d);
            return result;
        }       

        /// Метод, использующий Func
        /// 
        static object MethodFunc(int i, double d, Func<int, double, object> func)
        {
            object result = func(i, d);
            return result;
        }

        /// Метод, использующий Action
        static void MethodAction(int i, double d, Action<int, double> act)
        {
            act(i, d);
        }


        static void Main(string[] args)        {
            
            Console.WriteLine("Обычный делегат");
            object Result = MethodSum(4, 5.5, Sum);
            Console.WriteLine(Result.ToString());

            Console.WriteLine("Использование лямбда-функции");
            Result = MethodSum(3, 8.65, (int i, double d) =>
            {
                object result = (double)i + d;
                return result;
            }
            );
            Console.WriteLine(Result.ToString());

            Console.WriteLine("Использование обобщенного делегата Func");
            Result = MethodFunc(5, 3.448, (x, y) => (double)x + y);
            Console.WriteLine(Result.ToString());

            Console.WriteLine("Использование обобщенного делегата Action");
            MethodAction(16, 22.668, Act);
            
        }    }}