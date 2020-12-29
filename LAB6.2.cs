using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;



namespace Lab6_2
{ 
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class NewAttribute : Attribute
    {
        public NewAttribute() { }
        public NewAttribute(string DescriptionParam)
        {
            Description = DescriptionParam;
        }

        public string Description { get; set; }
    }




    public class ForInspection : IComparable
    {
        public ForInspection() { }
        public ForInspection(int i) { }
        public ForInspection(string str) { }

        public int Sum(int x, int y) { return x + y; }
        public int Mult(int x, int y) { return x * y; }

        [NewAttribute("Атрибут назначен свойству property1")]
        public string property1
        {
            get { return _property1; }
            set { _property1 = value; }
        }
        private string _property1;

        public int property2 { get; set; }

        [NewAttribute(Description = "Описание для property3")]
        public double property3 { get; private set; }

        
        /// <summary>
        /// Реализация интерфейса IComparable
        /// </summary>
        public int CompareTo(object obj)
        {
            return 0;
        }
    }

    class Program
    {
        /// <summary>
        /// Проверка, что у свойства есть атрибут заданного типа
        /// </summary>
        /// <returns>Значение атрибута</returns>
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;

            //Поиск атрибутов с заданным типом
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }

            return Result;
        }

        /// <summary>
        /// Получение информации о текущей сборке
        /// </summary>
        static void AssemblyInfo()
        {
            Console.WriteLine("Вывод информации о сборке:");
            Assembly i = Assembly.GetExecutingAssembly();
            Console.WriteLine("Полное имя:" + i.FullName);
            Console.WriteLine("Исполняемый файл:" + i.Location);
        }

        /// <summary>
        /// Получение информации о типе
        /// </summary>
        static void TypeInfo()
        {
            ForInspection obj = new ForInspection();
            Type t = obj.GetType();

            Console.WriteLine("\nКонструкторы:");
            foreach (var x in t.GetConstructors())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nСвойства:");
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }


        }

        /// <summary>
        /// Пример использования метода InvokeMember
        /// </summary>Атрибут назначен свойству
        static void InvokeMemberInfo()
        {
            Type t = typeof(ForInspection);
            Console.WriteLine("\nВызов метода:");

            //Создание объекта
            //Можно создать объект через рефлексию
            ForInspection fi = (ForInspection)t.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });

            //Параметры вызова метода
            object[] parameters = new object[] { 5, 6 };
            //Вызов метода
            object Result = t.InvokeMember("Mult", BindingFlags.InvokeMethod, null, fi, parameters);
            Console.WriteLine("Mult(5,6)={0}", Result);
        }

        /// <summary>
        /// Работа с атрибутами
        /// </summary>
        static void AttributeInfo()
        {
            Type t = typeof(ForInspection);
            Console.WriteLine("\nСвойства, помеченные атрибутом:");
            foreach (var x in t.GetProperties())
            {
                object attrobj;
                if (GetPropertyAttribute(x, typeof(NewAttribute), out attrobj))
                {
                    NewAttribute attr = attrobj as NewAttribute;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }
        }

        static void Main(string[] args)
        {
            AssemblyInfo();
            TypeInfo();
            AttributeInfo();
            InvokeMemberInfo();
            Console.ReadLine();
        }
        
    }

}
