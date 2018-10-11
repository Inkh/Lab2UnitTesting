using System;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            int balance = 10000;
            Console.WriteLine("Hello World!");
            Greeting(balance);


        }

        static void Greeting(int balance)
        {
            bool restart = true;
            while (restart)
            {
                restart = false;
                Console.WriteLine("Welcome to the ATM! What would you like to do today?");
                Console.WriteLine("[1] View Balance");
                Console.WriteLine("[2]. Deposit Money");
                Console.WriteLine("[3]. Withdraw Money");
                Console.WriteLine("[4]. Exit");
                bool flag = true;
                while (flag)
                {
                    flag = false;
                    try
                    {
                        int userInput = int.Parse(Console.ReadLine());
                        switch (userInput)
                        {
                            case 1:
                                Console.WriteLine($"You currently have ${balance}");
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
                                        Console.WriteLine("That was not a number. Please try again.");
                                        error = true;
                                    }
                                }

                                Console.WriteLine($"Your current balance is now {balance}");
                                Console.WriteLine("Would you like to perform another transaction?");
                                userAction = Console.ReadLine();
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
                                Console.WriteLine($"Your current balance is now {balance}");
                                Console.WriteLine("Would you like to perform another transaction? [Yes] / [No]");
                                userAction = Console.ReadLine();
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
                                break;
                            case 4:
                                break;
                            default:
                                Console.WriteLine("Please input 1, 2, 3, or 4 for operations");
                                flag = true;
                                break;

                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please input 1, 2, 3, or 4 for operations");
                        flag = true;
                    }
                }
            }
           
        }

        static int Deposit(string input, int balance)
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

        static int Withdraw(string input, int balance)
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
