using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public class Computer
    {
        private int[] inp;
        private int instructionPtr = 0;

        public Computer(int[] input)
        {
            inp = input;
        }


        public List<int> Solve()
        {
            var output = new List<int>();
            var exit = false;
            while (!exit)
            {
                int opCode = GetOpCode();

                switch (opCode)
                {
                    case 1:
                        inp[inp[instructionPtr + 3]] = GetParameter(1) + GetParameter(2);
                        instructionPtr += 4;
                        break;
                    case 2:
                        inp[inp[instructionPtr + 3]] = GetParameter(1) * GetParameter(2);
                        instructionPtr += 4;
                        break;
                    case 3:
                        inp[inp[instructionPtr + 1]] = GetInput();
                        instructionPtr += 2;
                        break;
                    case 4:
                        output.Add(GetParameter(1));
                        instructionPtr += 2;
                        break;
                    case 5:
                        if (GetParameter(1) != 0) instructionPtr = GetParameter(2);
                        else instructionPtr += 3;
                        break;
                    case 6:
                        if (GetParameter(1) == 0) instructionPtr = GetParameter(2);
                        else instructionPtr += 3;
                        break;
                    case 7:
                        if (GetParameter(1) < GetParameter(2)) inp[inp[instructionPtr + 3]] = 1;
                        else inp[inp[instructionPtr + 3]] = 0;
                        instructionPtr += 4;
                        break;
                    case 8:
                        if (GetParameter(1) == GetParameter(2)) inp[inp[instructionPtr + 3]] = 1;
                        else inp[inp[instructionPtr + 3]] = 0;
                        instructionPtr += 4;
                        break;
                    case 99:
                        exit = true;
                        break;
                    default:
                        throw  new Exception();
                        break;
                }
            }

            return output;
        }

        public int GetInput()
        {
            Console.WriteLine("Enter a value");
            var input = int.Parse("" + Console.ReadLine());
            Console.WriteLine("Value entered was: {0}", input);

            return input;
        }

        public int GetParameter(int param, int? mode = null)
        {
            var modeC = mode ?? GetMode(param);

            switch (modeC)
            {
                case 0:
                    return inp[inp[instructionPtr + param]];
                    break;
                case 1:
                    return inp[instructionPtr + param];
                    break;
                default:
                    break;
            }

            throw new Exception();
        }

        public int GetMode(int param)
        {
            var instruction = inp[instructionPtr];
            return (int)((instruction / Math.Pow(10, 1+param)) % 10);

        }

        public int GetOpCode()
        {
            return inp[instructionPtr] % 100;

        }
    }


}
