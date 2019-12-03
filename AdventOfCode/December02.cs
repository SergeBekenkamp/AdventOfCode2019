using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class December02
    {
        public int[] inputEasy = new[]
        {
            1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,13,1,19,1,10,19,23,1,6,23,27,1,5,27,31,1,10,31,35,2,10,35,39,1,39,5,43,2,43,6,47,2,9,47,51,1,51,5,55,1,5,55,59,2,10,59,63,1,5,63,67,1,67,10,71,2,6,71,75,2,6,75,79,1,5,79,83,2,6,83,87,2,13,87,91,1,91,6,95,2,13,95,99,1,99,5,103,2,103,10,107,1,9,107,111,1,111,6,115,1,115,2,119,1,119,10,0,99,2,14,0,0
        };

        public int GetAnswer1()
        {
            return Solve(inputEasy);
        }

        public int GetAnswer2()
        {
            var output = 0;
            var input1 = 0;
            var input2 = 0;
            while (true)
            {
                var inp = new[]
                {
                    1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,13,1,19,1,10,19,23,1,6,23,27,1,5,27,31,1,10,31,35,2,10,35,39,1,39,5,43,2,43,6,47,2,9,47,51,1,51,5,55,1,5,55,59,2,10,59,63,1,5,63,67,1,67,10,71,2,6,71,75,2,6,75,79,1,5,79,83,2,6,83,87,2,13,87,91,1,91,6,95,2,13,95,99,1,99,5,103,2,103,10,107,1,9,107,111,1,111,6,115,1,115,2,119,1,119,10,0,99,2,14,0,0
                };
                inp[1] = input1;
                inp[2] = input2;

                output = this.Solve(inp);
           
                
                if (output == 19690720) return 100 * input1 + input2;

                input2 += 1;
                if (input2 == 100)
                {
                    input1 += 1;
                    input2 = 0;
                }

                if (input1 >= 100) throw new Exception();

            }



        }

        public int Solve(int[] input)
        {
            int currentPos = 0;
            

            while (true)
            {
                int opCode = input[currentPos];
                int input1 = input[currentPos + 1];
                int input2 = input[currentPos + 2];
                int saveAt = input[currentPos + 3];

                switch (opCode)
                {
                    case 1:
                        input[saveAt] = input[input1] + input[input2];
                        break;
                    case 2:
                        input[saveAt] = input[input1] * input[input2];
                        break;
                    case 99:
                        return input[0];
                        break;
                    default:
                        return 0;
                        break;
                }

                currentPos += 4;
            }

        }


    }
}
