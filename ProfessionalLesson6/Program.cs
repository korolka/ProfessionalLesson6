//Завдання 2

//Створіть власну користувальницьку збірку за прикладом складання CarLibrary з уроку,
//складання буде використовуватися для роботи з конвертером температури.
namespace ProfessionalLesson6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TemperatureConvert temperatureConvert = new TemperatureConvert();

            double farenheitRes = temperatureConvert.TemperatureConverter(20);

            Console.WriteLine(farenheitRes);
        }
    }
}