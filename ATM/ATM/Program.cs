using System;

namespace ATM
{
    public class Program
    {
        static void Main(string[] args)
        {
            int balance = 10000;
            Console.WriteLine("Hello World!");
            Greeting(balance);


        }
        /// <summary>
        /// The greeting menu for ATM users. It will continuously bug the user to choose an option until they selected "Exit". 
        /// </summary>
        /// <param name="balance">Default starting balance</param>
        static void Greeting(int balance)
        {
            //Outer while loop for users to come back to everytime they finish a transaction.
            bool restart = true;
            while (restart)
            {
                restart = false;
                Console.WriteLine("Welcome to the ATM! What would you like to do today?");
                Console.WriteLine("[1]. View Balance");
                Console.WriteLine("[2]. Deposit Money");
                Console.WriteLine("[3]. Withdraw Money");

                try
                {
                    int userInput = int.Parse(Console.ReadLine());
                    switch (userInput)
                    {
                        case 1:
                            break;
                        case 2:
                            bool error = true;
                            Console.WriteLine($"You currently have ${balance}");
                            Console.WriteLine("How much would you like to deposit?");
                            while (error)
                            {
                                error = false;
                                try
                                {
                                    balance = Deposit(Console.ReadLine(), balance);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("That was not a number. Please try again: ");
                                    error = true;
                                }
                            }


                            break;
                        case 3:
                            error = true;
                            Console.WriteLine($"You currently have ${balance}");
                            Console.WriteLine("How much would you like to withdraw?");
                            while (error)
                            {
                                error = false;
                                try
                                {
                                    balance = Withdraw(Console.ReadLine(), balance);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("That was not a number. Please try again.");
                                    error = true;
                                }

                                catch (ArgumentException e)
                                {
                                    Console.WriteLine(e.Message);
                                    error = true;
                                }
                            }

                            break;
                        default:
                            Console.WriteLine("Please input 1, 2, or 3 for operations");
                            restart = true;
                            break;

                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please input 1, 2, or 3 for operations");
                    restart = true;
                }
                finally
                {
                    Console.WriteLine($"Your current balance is now {balance}");
                    Console.WriteLine("Would you like to perform another transaction? [Yes] / [No]");
                    string userAction = Console.ReadLine();
                    switch (userAction.ToLower())
                    {
                        case "yes":
                            restart = true;
                            break;
                        case "no":
                            break;
                        default:
                            Console.WriteLine("Did not understand. Redirecting you back to menu...");
                            restart = true;
                            break;
                    }
                }
            }
           
        }

        /// <summary>
        /// Handles the deposit action of ATM. Will add to balance if format is valid. Otherwise, throw Exception to parent block.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public static int Deposit(string input, int balance)
        {
            try
            {
                balance += int.Parse(input);
            }
            catch (FormatException)
            {
                throw;
            }
            return balance;
        }

        /// <summary>
        /// Performs the withdraw method of an ATM. Throws exception if format is incorrect. Also throws exception if withdrawal amount is greater than balance.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public static int Withdraw(string input, int balance)
        {
            try
            {
                if (balance > int.Parse(input))
                {
                    balance -= int.Parse(input);
                }
                else
                {
                    throw new ArgumentException("You have insufficient funds for that amount. Please try again: ");
                }
            }
            catch (FormatException)
            {
                throw;
            }
            return balance;
        }

    }
}
