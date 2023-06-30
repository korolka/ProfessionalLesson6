//Завдання 3

//Створіть програму, в якій надайте користувачеві доступ до збірки із завдання 2.
//Реалізуйте використання методу конвертації значення температури зі шкали Цельсія
//в шкалу Фаренгейта. Виконуючи завдання використовуйте лише рефлексію.
using System.Dynamic;
using System.Reflection;

namespace ProfessionalEx3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.Load("ProfessionalLesson6");

            Type type = assembly.GetType("ProfessionalLesson6.TemperatureConvert");

            object instance = Activator.CreateInstance(type);

            MethodInfo method = type.GetMethod("TemperatureConverter");
            object[] par = { 20 };

            Console.WriteLine(method.Invoke(instance, par));

        }
    }
}