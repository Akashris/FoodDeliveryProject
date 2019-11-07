using System;

namespace FoodDeliveryProject
{
    class MaximumTip
    {
        int[] deliveryBoyOneTips = new int[100];
        int[] deliveryBoyTwoTips = new int[100];
        int[] difference = new int[100];
        int[] sort = new int[100];

        int orders, a, TotalOrderDeliveryBoy1, TotalOrderDeliveryBoy2, i, j, index, arrayLength, temp = 0, maxTip = 0, count1 = 0, count2 = 0;
        string tipValueFor1, tipValueFor2;
        public void getValue()
        {
            orders = -1;
            while(orders < 1)
            {
                Console.Write("\nEnter The orders: ");
                orders = Convert.ToInt32(Console.ReadLine());
                if(orders <= 0)
                {
                    Console.WriteLine("\nEnter a Positive or Non Zero number");
                }
             
            }
            a = orders-1;
            while(a < orders)
            {
                Console.Write("\nNo. Of Orders For Delivery Boy One = ");
                TotalOrderDeliveryBoy1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nNo. Of Orders For Delivery Boy Two = ");
                TotalOrderDeliveryBoy2 = Convert.ToInt32(Console.ReadLine());
                a = TotalOrderDeliveryBoy1 + TotalOrderDeliveryBoy2;
                if (a < orders)
                {
                    Console.WriteLine("\nSum Of Both Delivery Boy's Orders Must Be Equal Or Greater Than total Orders");
                }
            }
           

            Console.WriteLine("\nEnter The Tips For Both Delivery Boys: ");
            Console.Write("\nDelivery Boy One = ");
            tipValueFor1 = Console.ReadLine();
            Console.Write("\nDelivery Boy Two = ");
            tipValueFor2 = Console.ReadLine();
            arrayLength = tipValueFor1.Split(" ").Length;
            for (i = 0; i < arrayLength; i++)
            {
                deliveryBoyOneTips[i] = Int32.Parse(tipValueFor1.Split(' ')[i]);
                deliveryBoyTwoTips[i] = Int32.Parse(tipValueFor2.Split(' ')[i]);
            }
        }




        public void sorting()
        {
            for (i = 0; i < arrayLength; i++)
            {
                difference[i] = Math.Abs(deliveryBoyOneTips[i] - deliveryBoyTwoTips[i]);
                sort[i] = difference[i];
            }

            for (i = 0; i < arrayLength; i++)
            {
                for (j = 0; j < arrayLength - 1; j++)
                {
                    if (sort[j] < sort[j + 1])
                    {
                        temp = sort[j + 1];
                        sort[j + 1] = sort[j];
                        sort[j] = temp;
                    }
                }
            }
        }




        public void calculation()
        {


            for (i = 0; i < arrayLength; i++)
            {
                index = Array.IndexOf(difference, sort[i]);
                if (deliveryBoyOneTips[index] > deliveryBoyTwoTips[index])
                {
                    count1 += 1;
                    if (count1 <= TotalOrderDeliveryBoy1)
                    {
                        maxTip += deliveryBoyOneTips[index];

                    }
                    else
                    {
                        maxTip += deliveryBoyTwoTips[index];
                        count2 += 1;
                        count1 -= 1;

                    }
                }
                else
                {
                    count2 += 1;
                    if (count2 <= TotalOrderDeliveryBoy2)
                    {
                        maxTip += deliveryBoyTwoTips[index];

                    }
                    else
                    {
                        maxTip += deliveryBoyOneTips[index];
                        count1 += 1;
                        count2 -= 1;

                    }

                }
            }
            Console.WriteLine();
            Console.WriteLine("\nThe Maximum Tip Amount Is = " + maxTip);
        }


        static void Main(string[] args)
        {

            MaximumTip max = new MaximumTip();
            max.getValue();
            max.sorting();
            max.calculation();
            Console.ReadKey();
        }
    }
}
