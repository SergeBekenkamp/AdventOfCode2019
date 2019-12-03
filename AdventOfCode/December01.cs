using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class December01
    {
        public December01()
        {
            
        }

        public async Task<IEnumerable<double>> GetInput()
        {
            var input = File.ReadAllLines("Input01.txt");

            return input.Select(x => double.Parse(x)).ToList();
        }

        public async Task<int> GetAnswer1()
        {
            var input = await this.GetInput();

            return input.Select(x => x / 3).Select(x => Math.Floor(x)).Select(x => (int)(x - 2)).Sum();
        }

        public async Task<int> GetAnswer2()
        {
            var input = await this.GetInput();
            return input.Select(x => this.GetAnswer(x)).Sum();

        }

        public int GetAnswer(double input)
        {
            if (input <= 0) return 0;

            var fuelNeeded = CalculateFuelForWeigth(input);
            var extraFuel = CalculateFuelForWeigth(fuelNeeded);
            while (extraFuel > 0)
            {
                fuelNeeded += extraFuel;
                extraFuel = CalculateFuelForWeigth(extraFuel);
            }

            return (int)fuelNeeded;
        }

        public double CalculateFuelForWeigth(double input)
        {
            if (input <= 0) return 0;

            var div3 = input / 3;
            var floored = Math.Floor(div3);
            var fuelNeeded = floored - 2;
            return fuelNeeded;
        }

//        5830620
//        3399394
    }
}
