using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianDoll2
{
    class Program
    {

        /**
         * Leetcode #354 Russian Doll
         * You have a number of envelopes with widths and heights given as a pair of integers (w, h). One envelope can fit into another if and only if both the width and height of one envelope is greater than the width and height of the other envelope.
         *What is the maximum number of envelopes can you Russian doll?
        */
        static void Main(string[] args)
        {
            int[][] envelopes = new int[][] {new int[]{ 5, 4}, new int[]{ 6, 4}, new int[]{ 6, 7}, new int[]{ 2, 3} };
            for (int i = 0; i < envelopes.Length; i++)
            {
                Console.WriteLine(envelopes[i][0] + "," + envelopes[i][1]);
            }
            Array.Sort(envelopes, new Comparison<int[]>(
                (x,y) => {
                    if (x[0] > y[0])
                    {
                        return 1;
                    }

                    if (x[0] == y[0])
                    {
                        return x[1] > y[1] ? -1 : (x[1] < y[1] ? 1 : 0);
                    }

                    return -1;  }
            ));

            //int CompareByRule(int[] x, int[] y)
            //{
            //    if (x[0] > y[0])
            //    {
            //        return 1;
            //    }

            //    if (x[0] == y[0])
            //    {
            //        return x[1] > y[1] ? -1 : (x[1] < y[1] ? 1 : 0);
            //    }

            //    return -1;

            //}
            //Array.Sort(envelopes, CompareByRule);


            for (int i = 0; i < envelopes.Length; i++)
            {
                Console.WriteLine(envelopes[i][0] + "," + envelopes[i][1]);
            }


            int max = 1;

            int[] dp = new int[envelopes.Length];
            dp[0] = 1;

            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (envelopes[i][1] > envelopes[j][1])
                    {
                        dp[i] = Math.Max(dp[i], 1 + dp[j]);
                    }

                    
                }
                if (dp[i] > max)
                {
                    max = dp[i];
                }
            }

            Console.ReadKey();

        }




    }
}
