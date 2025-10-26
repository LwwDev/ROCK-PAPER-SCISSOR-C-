using System;

// rock paper scissor
namespace MyProgram
{
    class Program
    {
        static bool continue_game = true;
        static int choice = 0;

        static void Main(string[] args)
        {
            while (continue_game)
            {
                Menu();


            }
        }
        
        static void Menu()
        {
            Console.WriteLine("***** Welcome to ROCK, PAPER or SCISSOR *****"
                             + "\nChoose: "
                             + "\n1. ROCK"
                             + "\n2. PAPER"
                             + "\n3. SCISSOR"
                             + "\n4. EXIT");
            bool valid = int.TryParse(Console.ReadLine(), out choice);
            if (!valid)
            {
                Console.WriteLine("THATS NOT AN OPTION");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                return;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("You choose ROCK");
                    choice = 1;
                    break;
                case 2:
                    Console.WriteLine("You choose PAPER");
                    choice = 2;
                    break;
                case 3:
                    Console.WriteLine("You choose SCISSOR");
                    choice = 3;
                    break;
                case 4:
                    Console.WriteLine("Good bye");
                    choice = 4;
                    continue_game = false;
                    Console.ReadKey();
                    Console.Clear();
                    return;

                default:
                    Console.WriteLine("Invalid input xD");
                    break;
            }
            Random random = new Random();
            int pcchoice = random.Next(1, 4);
            Console.WriteLine("The computer chose: " + (pcchoice == 1 ? "ROCK" : pcchoice == 2 ? "PAPER" : "SCISSOR"));
            if (choice == pcchoice)
            {
                Console.WriteLine("ITS A DRAW!!!");
            }
            else if ((choice == 1 && pcchoice == 3) ||  // Rock beats Scissor
                    (choice == 2 && pcchoice == 1) ||  // Paper beats Rock
                    (choice == 3 && pcchoice == 2))
            {
                Console.WriteLine("You WIN!!!!!");
            }
            else
            {
                Console.WriteLine("YOU LOSEEEE!!!!");
            }

            




          
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();

        }
    }
}               
