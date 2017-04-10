using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog_milestone3_10003472
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomePage();

            Client client = new Client();
            ClientDetails(client);

            PizzaMenu();

            List<Pizza> userOrders = new List<Pizza>();
            PizzaOdering(userOrders);

            List<Drinks> drinks = new List<Drinks>();
            DrinkOdering(drinks);

            CheckingClientDetails(client);

            OrderConfirmation(userOrders, client, drinks);            

            Payment(drinks, userOrders);
        }
         
        static void WelcomePage()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("*                              *");
            Console.WriteLine("*     WELCOME to PizzaRino     *");
            Console.WriteLine("*                              *");
            Console.WriteLine("*   Press <enter> to continue  *");
            Console.WriteLine("*                              *");
            Console.WriteLine("********************************");
            Console.ReadLine();
            Console.Clear();
        }

        static Client ClientDetails(Client client)
        {
            Console.Clear();
            Console.WriteLine("****************************************************\n");
            Console.WriteLine("Type in the info or press <enter> to do it letter.\n\n");
            Console.Write("Your name:  ");
            client.ClientName = Console.ReadLine();

            Console.Write("\nDo you Dine-in or Take away:  ");
            client.OrderType = Console.ReadLine();

            return client;
        }

        static void CheckingClientDetails(Client client)
        {
            if (client.ClientName == "" || client.OrderType == "")
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Please type in your details.\n");
                    ClientDetails(client);
                } while (client.ClientName == "" || client.OrderType == "");
            }
        }

        static void PizzaOdering(List<Pizza> userOrders)
        {

            Pizza a = AskForUserInput();
            userOrders.Add(a);

            Console.Write("\nWould you like to make another order (<y> or <n>)?\t");
            var ans = char.Parse(Console.ReadLine());

            if (ans == 'y')
            {
                do
                {
                    Console.Clear();
                    PizzaMenu();
                    Pizza b = AskForUserInput();
                    userOrders.Add(b);

                    Console.Write("\nWould you like to make another order (<y> or <n>)?\t");
                    ans = char.Parse(Console.ReadLine());

                } while (ans == 'y');
            }
        }

        static void DrinkOdering(List<Drinks> drinks)
        {
            Drinks c = AskForDrink();
            drinks.Add(c);

            Console.Write("\n\nIs your order completed (<y> or <n>)?\t");
            var ans = char.Parse(Console.ReadLine());

            if (ans == 'n')
            {
                do
                {
                    Drinks d = AskForDrink();
                    drinks.Add(d);

                    Console.Write("\nWould you like to add a drink (<y> or <n>)?\t");
                    ans = char.Parse(Console.ReadLine());

                } while (ans == 'y');
            }
        }

        static Pizza AskForUserInput()
        {
            Pizza pizza = new Pizza();
                  
            Console.Write("\nYour chose (word only):\t");
            pizza.Name = Console.ReadLine();

            Console.Write("\nWould you like Standard or Large(+$5) size?\n\nYour chose (word only):\t");            
            pizza.Size = Console.ReadLine();

            if (pizza.Size == "standard" || pizza.Size == "Standard")
            {
                pizza.Price = 15;
            }
            else
            {
                pizza.Price = 20;
            }

            return pizza;
        }

        static Drinks AskForDrink()
        {
            Console.Clear();
            Drinks drink = new Drinks();
            DrinksMenu();

            Console.Write("\nYour chose (word only):\t");
            drink.Name = Console.ReadLine();

            if (drink.Name == "none")
            {
                drink.Price = 0;

            }
            else
            {
                drink.Price = 3;
            }

            return drink;
        }

        static void PizzaMenu()
        {
            int price = 15;

            Console.Clear();
            Console.WriteLine("**************************************************\n");
            Console.WriteLine("\tPizza Name\t\tPrice\n");
            Console.WriteLine($"\tMexican Style\t\t${price}");
            Console.WriteLine($"\tVegy Pizza\t\t${price}");
            Console.WriteLine($"\tCountry Style\t\t${price}");
            Console.WriteLine($"\tCallifornia\t\t${price}");
            Console.WriteLine($"\tHollywood\t\t${price}\n");
        }

        static void DrinksMenu()
        {
            int price = 3;

            Console.WriteLine("**************************************************\n");
            Console.WriteLine("\tDrinks Name\tPrice\n");
            Console.WriteLine($"\tCoke\t\t${price}");
            Console.WriteLine($"\tSprite\t\t${price}");
            Console.WriteLine($"\tFanta\t\t${price}");
            Console.WriteLine($"\tJuice\t\t${price}");
            Console.WriteLine($"\tTea\t\t${price}");
            Console.WriteLine($"\tCoffee\t\t${price}\n");
            Console.WriteLine($"\tNone\n");
        }

        static void OrderConfirmation(List<Pizza> userOrders, Client client, List<Drinks> drinks)
        {
            Console.Clear();
            Console.WriteLine("**************************************************\n");
            Console.WriteLine($"Your name: {client.ClientName} \nOrder type: {client.OrderType}");

            Console.WriteLine("\n\nYour pizza order is: ");
            foreach (var item in userOrders)
            {
                Console.WriteLine($"{item.Size} {item.Name} \t${item.Price}");
            }

            Console.WriteLine("\n\nYour drinks are: ");
            foreach (var item in drinks)
            {
                Console.WriteLine($"{item.Name} \t\t${item.Price}");
            }

            Console.WriteLine("\n\nPress <enter> to see your Bill.");
            Console.WriteLine("\n**************************************************");
            Console.ReadLine();
        }

        static int PriceCalculation(List<Pizza> userOrders, List<Drinks> drinks,int total)
        {
            int totalFood = 0;
            int totalDrinks = 0;            

            foreach (var item in userOrders)
            {
                totalFood += item.Price;
            }
            
            foreach (var item in drinks)
            {
                totalDrinks += item.Price;
            }

            total = totalFood + totalDrinks;
            Console.WriteLine($"\nBill: ${total}");

            return total;
        }

        static void Payment(List<Drinks> drinks, List<Pizza> userOrders)
        {
            int total = 0;

            Console.Clear();

            int userPayment = PriceCalculation(userOrders, drinks, total);

            Console.WriteLine("**************************************************\n");
            Console.WriteLine("Please make a payment.");
            Console.WriteLine("\nType in the amount of money you are going to pay:");
            int payment = int.Parse(Console.ReadLine());

            int balance = userPayment - payment;

            if (payment < userPayment)
            {
                Console.WriteLine($"\nYour payment is not complete! \n${balance} must be paid");
            }
            else
            {
                Console.WriteLine($"\nYour change:  ${payment - userPayment}");
                Console.WriteLine("\nPress <enter> to continue...");
                Console.WriteLine("\n**************************************************");
                Console.ReadLine();
                Console.Clear();
                ThankuMessage();
                return;
            }

            int secondPayment = int.Parse(Console.ReadLine());

            if (secondPayment > balance || secondPayment > (secondPayment - balance))
            {
                Console.WriteLine($"\nYour change:   ${secondPayment - balance}\n\n Press <enter> to continue...");
                Console.WriteLine("\n**************************************************");
                Console.ReadLine();
                Console.Clear();
                ThankuMessage();
            }
        

        }

        static void ThankuMessage()
        {
            Console.Clear();
            Console.WriteLine("*******************************");
            Console.WriteLine("*                             *");
            Console.WriteLine("*          Thank you          *");
            Console.WriteLine("*    for Using Our App        *\n");
            Console.WriteLine("*    Enjoy Your Meal!         *\n");
            Console.WriteLine("*   Press <enter> to Exit     *");
            Console.WriteLine("*                             *");
            Console.WriteLine("*******************************");
            Console.ReadLine();
            
        }
    }

    public class Pizza
    {
        public string Name;
        public string Size;
        public int Price;
    }

    public class Drinks
    {
        public string Name;
        public int Price;
    }

    public class Client
    {
        public string ClientName;
        public string OrderType;

    }
}
