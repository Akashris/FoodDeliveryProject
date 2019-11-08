using System;

namespace FoodDeliveryProject
{
    class MaximumTip
    {
        int[] deliveryBoyOneTips = new int[100];
        int[] deliveryBoyTwoTips = new int[100];
        int[] difference = new int[100];
        int[] sort = new int[100];
        int validTipFlag=0;
        int orders, tempTotalOrder, TotalOrderDeliveryBoy1, TotalOrderDeliveryBoy2, arrayTraverseVariable, sortTraverseVariable, index, arrayLength, temp = 0, maxTip = 0, orderCountForBoy1 = 0, orderCountForBoy2 = 0;
        string tipValueFor1, tipValueFor2;

        public void getValue()
        {


            orders = -1;
            while (orders < 1)
            {
                try
                {
                    Console.Write("\nEnter The orders: ");
                    orders = Convert.ToInt32(Console.ReadLine());
                    if (orders <= 0)
                    {
                        Console.WriteLine("\nEnter a Positive or Non Zero number");
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("\nEnter a Valid Number");

                }
            }


            tempTotalOrder = orders - 1;
            while (tempTotalOrder < orders)
            {
                //Console.Write("\nNo. Of Orders For Delivery Boy One = ");
                //TotalOrderDeliveryBoy1 = Convert.ToInt32(Console.ReadLine());
                TotalOrderDeliveryBoy1 = -1;
                while (TotalOrderDeliveryBoy1 < 1)
                {
                    try
                    {


                        Console.Write("\nNo. Of Orders For Delivery Boy One = ");
                        TotalOrderDeliveryBoy1 = Convert.ToInt32(Console.ReadLine());
                        if (TotalOrderDeliveryBoy1 <= 0)
                        {
                            Console.WriteLine("\nEnter a Positive or Non Zero number");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nEnter a Valid Number");

                    }
                }
                // Console.Write("\nNo. Of Orders For Delivery Boy Two = ");
                // TotalOrderDeliveryBoy2 = Convert.ToInt32(Console.ReadLine());
                TotalOrderDeliveryBoy2 = -1;
                while (TotalOrderDeliveryBoy2 < 1)
                {
                    try
                    {
                        Console.Write("\nNo. Of Orders For Delivery Boy Two = ");
                        TotalOrderDeliveryBoy2 = Convert.ToInt32(Console.ReadLine());
                        if (TotalOrderDeliveryBoy2 <= 0)
                        {
                            Console.WriteLine("\nEnter a Positive or Non Zero number");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nEnter a Valid Number");

                    }

                }
                tempTotalOrder = TotalOrderDeliveryBoy1 + TotalOrderDeliveryBoy2;
                if (tempTotalOrder < orders)
                {
                    Console.WriteLine("\nSum Of Both Delivery Boy's Orders Must Be Equal Or Greater Than total Orders");
                }
            }

            arrayLength = orders;
            Console.WriteLine("\nEnter The Tips For Both Delivery Boys: ");


            /*for (arrayTraverseVariable = 0; arrayTraverseVariable < orders; arrayTraverseVariable++)
            {
                deliveryBoyOneTips[arrayTraverseVariable] = -1;
                deliveryBoyTwoTips[arrayTraverseVariable] = -1;
            }*/


            while(validTipFlag == 0)
            {

                Console.Write("\nDelivery Boy One = ");
                tipValueFor1 = Console.ReadLine();
                for (arrayTraverseVariable = 0; arrayTraverseVariable < arrayLength; arrayTraverseVariable++)
                {   try
                    {
                        try
                        {
                            deliveryBoyOneTips[arrayTraverseVariable] = Int32.Parse(tipValueFor1.Split(' ')[arrayTraverseVariable]);
                            if(deliveryBoyOneTips[arrayTraverseVariable]<0)
                            {
                                Console.WriteLine("\nEnter a Positive Number or Zero as Tip Amount");
                                validTipFlag = 0;
                                break;
                            }
                            else
                            {
                                validTipFlag = 1;
                            }
                        }
                        catch(IndexOutOfRangeException)
                        {
                            if (deliveryBoyOneTips.Length != orders)
                            {
                                Console.WriteLine("\nEnter {0} Tip Amount For Delivery Boy 1", orders);
                                validTipFlag = 0;
                                break;
                            }
                            /*Console.WriteLine("\nEnter {0} Tip Amount For Each Delivery Boy",orders);
                            validTipFlag = 0;
                            break;*/
                        }
                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nEnter a Valid Number");
                        validTipFlag = 0;
                        break;
                    }
                }
                /*if(deliveryBoyOneTips.Length!=orders)
                {
                    Console.WriteLine("\nEnter {0} Tip Amount For Delivery Boy 1", orders);
                    validTipFlag = 0;
                }
                else
                {
                    
                    validTipFlag = 1;
                }*/
            }


            validTipFlag = 0;
            while(validTipFlag==0)
            {
                Console.Write("\nDelivery Boy Two = ");
                tipValueFor2 = Console.ReadLine();
                for (arrayTraverseVariable = 0; arrayTraverseVariable < arrayLength; arrayTraverseVariable++)
                {   try
                    {
                        try
                        {
                            deliveryBoyTwoTips[arrayTraverseVariable] = Int32.Parse(tipValueFor2.Split(' ')[arrayTraverseVariable]);
                            if (deliveryBoyTwoTips[arrayTraverseVariable] < 0)
                            {
                                Console.WriteLine("\nEnter a Positive Number or Zero as Tip Amount");
                                validTipFlag = 0;
                                break;
                            }
                            else
                            {
                                validTipFlag = 1;
                                
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            if (deliveryBoyTwoTips.Length != orders)
                            {
                                Console.WriteLine("\nEnter {0} Tip Amount For Delivery Boy 2", orders);
                                validTipFlag = 0;
                                break;
                            }

                            /*Console.WriteLine("\nEnter {0} Tip Amount For Each Delivery Boy", orders);
                            validTipFlag = 0;
                            break;*/
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nEnter a Valid Number");
                        validTipFlag = 0;
                        break;
                    }
                }
                /*if ( deliveryBoyTwoTips.Length!= orders)
                {
                     Console.WriteLine("\nEnter {0} Tip Amount For Delivery Boy 2", orders);
                     validTipFlag = 0;
                }
                else
                {
                   
                    validTipFlag = 1;
                }*/

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