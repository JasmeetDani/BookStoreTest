using System;
using StoreLib.Store;
using StoreLib.Order;

/**
 *  Problem Description:
 *  
 *  An online bookstore currently sells books for 3 different categories: Crime, Romance, Fantasy.
 *  They have future plans to add more categories into their collection. 
 *  
 *  Currently all books within the Crime category are discounted by 5%. 
 *  
 *  The following are the additional charges that would be applied to an order:
 *  10% goods services tax (GST) on the total price
 *  $5.95 delivery fee for orders less than $20
 *  
 *  
 *  Objective:
 *  
 *  Output the total order cost with and without tax for the below purchase
 */

namespace StoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BookStore store = new BookStore(new DefaultDiscountStrategy());

                Cart cart = new Cart();
                cart.AddBook("Unsolved murders", 1);
                cart.AddBook("A Little Love Story", 1);
                cart.AddBook("Heresy", 1);
                cart.AddBook("Jack the Ripper", 1);
                cart.AddBook("The Tolkien Years", 1);

                Console.WriteLine(cart);

                Console.WriteLine();
                Console.WriteLine();


                Order order = new Order(store, cart);
                Console.WriteLine(order);

                /** 
                 * Output the total order cost without tax(including delivery fee) for the below purchase
                 *
                */

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Without Tax(Including delivery fee) " + new OrderDeliveryFee(order, 5.95, 20).Cost());

                /** 
                 * Output the total order cost with tax(including delivery fee) for the below purchase
                 *
                */

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("With Tax(Including delivery fee) " + new OrderDeliveryFee(new OrderGST(order, 10), 5.95, 20).Cost());
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid Input...");
            }
        }
    }
}