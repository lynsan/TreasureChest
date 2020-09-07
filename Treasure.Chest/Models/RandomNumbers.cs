using System;
using System.Collections.Generic;
using System.Text;

namespace Treasure.Chest.Models
{
   public class RandomNumbers
    {
        public int[] Numbers { get; set; }
        public RandomNumbers()
        {
            Numbers = new int[4];
            Random random = new Random();

            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = random.Next(0, 10);
            }
        }


        //public static int[] GenerateRandomNumbers()
        //{
        //    int[] numbers = new int[4];
        //    Random random = new Random();

        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        numbers[i]= random.Next(0,10);
        //    }
        //    return numbers;
        //}
    }
}
