using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class December04
    {
        private int lowerLimit = 235741;
        private int upperLimit = 706948;


        public int Answer1()
        {
            int[] lower = {2, 3, 5, 7, 4, 1};
            int[] upper = {7, 0, 6, 9, 4, 8};
            int totalCount = 0;
            var lowerl = lowerLimit;

            while (lowerl <= upperLimit)
            {
                var intArr = lowerl.ToString().Select(x => int.Parse(x.ToString())).ToArray();
                var hasPair = intArr[0] == intArr[1] || intArr[1] == intArr[2] || intArr[2] == intArr[3] || intArr[3] == intArr[4] || intArr[4] == intArr[5];
                var isNotDesc = intArr[0] <= intArr[1] && intArr[1] <= intArr[2] && intArr[2] <= intArr[3] && intArr[3] <= intArr[4] && intArr[4] <= intArr[5];
                if (hasPair && isNotDesc)
                {
                    totalCount++;
                }

                lowerl++;
            }

            return totalCount;
        }

        public int Answer2()
        {
            int[] lower = { 2, 3, 5, 7, 4, 1 };
            int[] upper = { 7, 0, 6, 9, 4, 8 };
            int totalCount = 0;
            var lowerl = lowerLimit;
            List<int> ints = new List<int>();

            while (lowerl <= upperLimit)
            {
                var intArr = lowerl.ToString().Select(x => int.Parse(x.ToString())).ToArray();

                var val = intArr[0];
                var maxRepeat = 0;
                var hasPair = false;

                for (int i = 1; i < intArr.Length; i++)
                {
                    if (val == intArr[i])
                    {
                        maxRepeat += 1;
                    }
                    else
                    {
                        if (maxRepeat >= 2) maxRepeat = 0;
                        else if (maxRepeat == 1) hasPair = true;
                    }

                    val = intArr[i];
                }
                //Im fucking dumb i forgot this .....
                if (maxRepeat == 1) hasPair = true;

                var isNotDesc = intArr[0] <= intArr[1] && intArr[1] <= intArr[2] && intArr[2] <= intArr[3] && intArr[3] <= intArr[4] && intArr[4] <= intArr[5];
                if (hasPair && isNotDesc)
                {
                    totalCount++;
                    ints.Add(lowerl);
                }

                lowerl++;
            }

            return totalCount;

        }
    }
}
