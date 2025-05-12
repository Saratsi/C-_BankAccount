using System;

public class Account
{
    // Ιδιωτικά πεδία
    private string afm;
    private int pin;
    private double balance;

    // Κατασκευαστής 1: Αρχικοποίηση όλων των πεδίων
    public Account(string afm, int pin, double balance)
    {
        this.afm = afm;
        this.pin = pin;
        this.balance = Math.Max(balance, 0); // Αποφυγή αρνητικού υπολοίπου
    }

    // Κατασκευαστής 2: Ορίζει το υπόλοιπο σε 0 αν δεν δοθεί τιμή
    public Account(string afm, int pin) : this(afm, pin, 0) { }

    // Getter για το ΑΦΜ
    public string GetAfm()
    {
        return afm;
    }

    // Μέθοδος ελέγχου του PIN
    public bool ValidatePin(int inputPin)
    {
        return pin == inputPin;
    }

    // Επιστροφή υπολοίπου
    public double GetBalance()
    {
        return balance;
    }

    // Κατάθεση χρημάτων
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Successful deposit! New balance: {balance}€");
        }
        else
        {
            Console.WriteLine("The amount must be above 0!");
        }
    }

    // Ανάληψη χρημάτων
    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Successful withdraw! New balance: {balance}€");
        }
        else if (amount > balance)
        {
            Console.WriteLine("Insufficient amount!");
        }
        else
        {
            Console.WriteLine("The amount must be above 0!");
        }
    }
}