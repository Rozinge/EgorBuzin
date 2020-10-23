using System;
namespace LAB1{
    class Biquadratic{

        static void step2(double t1, double t2){
            if (t1 >= 0 && t2 >= 0){
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(Math.Sqrt(t1));
                Console.WriteLine(-Math.Sqrt(t1));
                Console.WriteLine(Math.Sqrt(t2));
                Console.WriteLine(-Math.Sqrt(t2));
                
            }
            if (t1 < 0 && t2 < 0){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Корней нет ");
            }
            if (t1 < 0){
                Console.ForegroundColor = ConsoleColor.Green;
                if (t2 >= 0){
                    Console.WriteLine(Math.Sqrt(t2));
                    Console.WriteLine(-Math.Sqrt(t2));
                }
            }
            if (t2 < 0){
                Console.ForegroundColor = ConsoleColor.Green;
                if (t1 >= 0){
                    Console.WriteLine(Math.Sqrt(t1));
                    Console.WriteLine(-Math.Sqrt(t1));
                }
            }
        }

        static void step1(double a, double b, double c){
            if (a != 0){
                double D = b * b - 4.0 * a * c;
                double t1, t2;
                if (D > 0){
                    t1 = ((-b) + Math.Sqrt(D)) / (2.0 * a);
                    t2 = ((-b) - Math.Sqrt(D)) / (2.0 * a);
                    step2(t1, t2);
                }
                else if (D == 0){
                    t1 = -b / (2.0 * a);
                    if (t1 >= 0){
                        t1 = Math.Sqrt(t1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(t1);
                        Console.WriteLine(-t1);
                    }
                    else{
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Корней нет ");
                    }
                }
                else if (D < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Корней нет ");
                }
            }
            else {
                Console.WriteLine("\nКоэффициент А не может быть равен 0");
                //Console.ReadLine();
            }


        }

        static void Main(string[] args){

            Console.WriteLine("Бузин Егор Максимович ИУ5-34Б");
            Console.WriteLine("\nВведите коэффициенты А, В, С:");
            double a, b, c;
            
                try{
                    a = double.Parse(Console.ReadLine());
                    b = double.Parse(Console.ReadLine());
                    c = double.Parse(Console.ReadLine());
                }

                catch (FormatException){
                    Console.WriteLine("Error, enter again!");
                    a = double.Parse(Console.ReadLine());
                    b = double.Parse(Console.ReadLine());
                    c = double.Parse(Console.ReadLine());
                }
            step1(a, b, c);
            Console.ReadLine();
        }
    }
}

