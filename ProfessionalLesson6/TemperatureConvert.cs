using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalLesson6
{
    class TemperatureConvert
    {
        public double TemperatureConverter(int temperatureInCelsium)
        {
            double farenheitTemperature = (temperatureInCelsium * 1.8d) + 32;
            return farenheitTemperature;
        }

    }
}
