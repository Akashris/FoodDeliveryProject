using System;

namespace FoodDeliveryProject
{
    class MaximumTip
    {
        int[] deliveryBoyOneTips = new int[100];
        int[] deliveryBoyTwoTips = new int[100];
        int[] difference = new int[100];
        int[] sort = new int[100];
        int orders, tempTotalOrder, TotalOrderDeliveryBoy1, TotalOrderDeliveryBoy2, arrayTraverseVariable, sortTraverseVariable, index, arrayLength, temp = 0, maxTip = 0, orderCountForBoy1 = 0, orderCountForBoy2 = 0;
        string tipValueFor1, tipValueFor2;

        public void getValue()
        {
            try
            {
                orders = -1;
                while (orders < 1)
                {
                    Console.Write("\nEnter The orders: ");
                    orders = Convert.ToInt32(Console.ReadLine());
                    if (orders <= 0)
                    {
                        Console.WriteLine("\nEnter a Positive or Non Zero number");
                    }

                }
                tempTotalOrder = orders - 1;
                while (tempTotalOrder < orders)
                {
                    Console.Write("\nNo. Of Orders For Delivery Boy One = ");
                    TotalOrderDeliveryBoy1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\nNo. Of Orders For Delivery Boy Two = ");
                    TotalOrderDeliveryBoy2 = Convert.ToInt32(Console.ReadLine());
                    tempTotalOrder = TotalOrderDeliveryBoy1 + TotalOrderDeliveryBoy2;
                    if (tempTotalOrder < orders)
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
                for (arrayTraverseVariable = 0; arrayTraverseVariable < arrayLength; arrayTraverseVariable++)
                {
                    deliveryBoyOneTips[arrayTraverseVariable] = Int32.Parse(tipValueFor1.Split(' ')[arrayTraverseVariable]);
                    deliveryBoyTwoTips[arrayTraverseVariable] = Int32.Parse(tipValueFor2.Split(' ')[arrayTraverseVariable]);
                }

            }
            catch(FormatException)
            {
                Console.WriteLine("\nEnter a Valid Number");
            }
        }



        public void sorting()
        {
            for (arrayTraverseVariable = 0; arrayTraverseVariable < arrayLength; arrayTraverseVariable++)
            {
                difference[arrayTraverseVariable] = Math.Abs(deliveryBoyOneTips[arrayTraverseVariable] - deliveryBoyTwoTips[arrayTraverseVariable]);
                sort[arrayTraverseVariable] = difference[arrayTraverseVariable];
            }

            for (arrayTraverseVariable = 0; arrayTraverseVariable < arrayLength; arrayTraverseVariable++)
            {
                for (sortTraverseVariable = 0; sortTraverseVariable < arrayLength - 1; sortTraverseVariable++)
                {
                    if (sort[sortTraverseVariable] < sort[sortTraverseVariable + 1])
                    {
                        temp = sort[sortTraverseVariable + 1];
                        sort[sortTraverseVariable + 1] = sort[sortTraverseVariable];
                        sort[sortTraverseVariable] = temp;
                    }
                }
            }
        }




        public void calculation()
        {


            for (arrayTraverseVariable = 0; arrayTraverseVariable < arrayLength; arrayTraverseVariable++)
            {
                index = Array.IndexOf(difference, sort[arrayTraverseVariable]);
                if (deliveryBoyOneTips[index] > deliveryBoyTwoTips[index])
                {
                    orderCountForBoy1 += 1;
                    if (orderCountForBoy1 <= TotalOrderDeliveryBoy1)
                    {
                        maxTip += deliveryBoyOneTips[index];
                        
                        deliveryBoyOneTips[index] = deliveryBoyTwoTips[index] = difference[index] = -1;
                    }
                    else
                    {
                        maxTip += deliveryBoyTwoTips[index];
                        orderCountForBoy2 += 1;
                        orderCountForBoy1 -= 1;
                        
                        deliveryBoyOneTips[index] = deliveryBoyTwoTips[index] = difference[index] = -1;
                    }
                }
                else
                {
                    orderCountForBoy2 += 1;
                    if (orderCountForBoy2 <= TotalOrderDeliveryBoy2)
                    {
                        maxTip += deliveryBoyTwoTips[index];
                      
                        deliveryBoyOneTips[index] = deliveryBoyTwoTips[index] = difference[index] = -1;
                    }
                    else
                    {
                        maxTip += deliveryBoyOneTips[index];
                        orderCountForBoy1 += 1;
                        orderCountForBoy2 -= 1;
                      
                        deliveryBoyOneTips[index] = deliveryBoyTwoTips[index] = difference[index] = -1;
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