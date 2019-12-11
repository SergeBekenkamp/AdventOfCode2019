using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class December06
    {
        public IEnumerable<(string, string)> GetInput()
        {
            var input = File.ReadAllLines("Input06.txt");

            return input.Select(x => x.Split(")")).Select(x => (x[0], x[1])).ToList();
        }

        public int GetAnswer1()
        {
            var input = this.GetInput();
            var orbits = new Dictionary<string, List<string>>();

            foreach (var inp in input)
            {
                List<string> list = new List<string>();
                orbits.TryAdd(inp.Item1, list);
                list = orbits[inp.Item1];
                list.Add(inp.Item2);
            }

            return 0;
        }

    }
}
