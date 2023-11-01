using System;

public class CardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public CardHolder()
    {

    }

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setCardNum(string cardNum)
    {
        this.cardNum = cardNum;
    }

    public void setPin(int pin)
    {
        this.pin = pin;
    }

    public void setFirstName(string firstName)
    {
        this.firstName = firstName;
    }

    public void setLastName(string lastName)
    {

        this.lastName = lastName;
    }

    public void setBalance(double balance)
    {
        this.balance = balance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please enter one of the following options: ");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine($"Thank you! Your new balance is {currentUser.getBalance()}");
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw");
            double withdraw = Double.Parse(Console.ReadLine());
            if (currentUser.getBalance() < withdraw)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("You're good to go!");
            }
        }

        void balance(CardHolder currentUser)
        {
            Console.WriteLine($"Current Balance: {currentUser.getBalance()}");

        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("4532772818527395", 1234, "John", "Doe", 150.31));
        cardHolders.Add(new CardHolder("4532754118527395", 1264, "Mary", "Lou", 90.10));
        cardHolders.Add(new CardHolder("4535672818527395", 9034, "Loki", "Spin", 57.32));
        cardHolders.Add(new CardHolder("4532772818526295", 3456, "Steve", "Work", 259.11));
        cardHolders.Add(new CardHolder("4532772813697395", 9513, "Colde", "Cshar", 92.30));
        cardHolders.Add(new CardHolder("4532772818527378", 9999, "Joe", "Griffin", 50.31));


        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCard = "";
        CardHolder currentUser;

        while (true)
        {
            try
            {
                debitCard = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.getNum() == debitCard);
                if (currentUser != null) { break; }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");

            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else
                {
                    Console.WriteLine("Incorrect pin, please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect pin, please try again.");

            }
        }

        Console.WriteLine($"Welcome {currentUser.getFirstName()}");

        int option = 0;

        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { balance(currentUser); }
            else if(option == 4) { break; }
            else { option = 0; }

        } while (option != 4);
        Console.WriteLine("Thank you, have a nice day!");
        Console.ReadKey();
    }




}