using System;
using System.Collections.Generic;
using System.Security.Principal;

class Money
{
    static void Main()
    {
        // Δημιουργία λίστας λογαριασμών
        List<Account> accounts = new List<Account>
        {
            new Account("123456789", 1234, 500),
            new Account("987654321", 5678, 1200),
            new Account("555666777", 4321, 300),
            new Account("111222333", 8765, 50),
            new Account("999888777", 9999, 700)
        };

        while (true)
        {
            Console.WriteLine("\nWelcome to Zeta Bank! Please put your AFM:");
            string inputAfm = Console.ReadLine();

            Console.WriteLine("Put your PIN:");
            if (!int.TryParse(Console.ReadLine(), out int inputPin))
            {
                Console.WriteLine("Wrong form of PIN!");
                continue;
            }

            // Εύρεση λογαριασμού
            Account userAccount = accounts.Find(a => a.GetAfm() == inputAfm && a.ValidatePin(inputPin));

            if (userAccount == null)
            {
                Console.WriteLine("Wrong AFM or PIN! Please try again.");
                continue;
            }

            while (true)
            {
                // Εμφάνιση μενού
                Console.WriteLine("\nPlease choose an action:");
                Console.WriteLine("1. Withdraw");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Balance");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Withdraw amount:");
                        if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                        {
                            userAccount.Withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount!");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Deposit amount:");
                        if (double.TryParse(Console.ReadLine(), out double depositAmount))
                        {
                            userAccount.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount!");
                        }
                        break;

                    case "3":
                        Console.WriteLine($"Your balance is: {userAccount.GetBalance()}€");
                        break;

                    case "4":
                        Console.WriteLine("Thnaks for using our services!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
}