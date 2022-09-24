using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");

            int difcount = 0; // Tells us how many times the user has been threw the first do-while loop
            string answer = ""; // Declare answer here to make it a global variable
            string[] difficality = { "Välj Svårighetsgrad", "[1] Easy (0-10)", "[2] Medium (0-25)", "[3] Hard (0-50)" };
            string[] difficality2 = { "Du angav ingen svårighetsgrad. Skriv igen!", "[1] Easy (0-10)", "[2] Medium (0-25)", "[3] Hard (0-50)" };

            // Lets the user pick a difficality
            do
            {
                if (difcount == 0)
                {
                    foreach (string df in difficality)
                    {
                        Console.WriteLine(df);
                    }
                    answer = Console.ReadLine().ToUpper();
                }
                else 
                {
                    foreach (string df in difficality2)
                    {
                        Console.WriteLine(df);
                    }
                    answer = Console.ReadLine().ToUpper();
                }
                difcount++;
            } while ((answer != "1") && (answer != "2") && (answer != "3") && (answer != "EASY") && (answer != "MEDIUM") && (answer != "HARD"));

            // Checks the difficality pick, and also runs the game method choice
            if (answer == "1" || answer == "EASY")
            {
                Console.WriteLine("Start Guessing From 0-10!");
                answer = "11"; // The max number on easy mode
                int answer1 = int.Parse(answer); // Convert string of the user difficality choice into int by making a new variable 
                choice(answer1); // Runs the method and include the varuable answer1 witch holds the max number of the difficality
            }
            else if (answer == "2" || answer == "MEDIUM")
            {
                Console.WriteLine("Start Guessing From 0-25!");
                answer = "26";
                int answer1 = int.Parse(answer);
                choice(answer1);
            }
            else 
            {
                Console.WriteLine("Start Guessing From 0-50!");
                answer = "51";
                int answer1 = int.Parse(answer);
                choice(answer1);
            }

        }
        
        public static void choice(int get)
        {
            Random random = new Random();
            int number = random.Next(0, get); // Creates a random number between 0 and the chosen level of difficulty
            int count = 0; // Counts how many times the user has guessed
            int pick = 0; // Saves the user guess
            string[] diffanswers = { "Tyvärr du gissade för lågt!", "Din gissning var för låg", "Bra gissat men det var för lågt", "Haha! Det var för lågt!" };
            string[] diffanswers2 = { "Tyvärr du gissade för högt!", "Din gissning var för hög", "Bra gissat men det var för högt", "Haha! Det var för högt!" };

            // Game loop
            for (int i = 0; i < 4; i++)
            {
                Random random2 = new Random();
                int number2 = random2.Next(0, 4); // Creates a random number to get different answers depending on the guess
                if (pick == 0)
                {
                    pick = int.Parse(Console.ReadLine());
                }
                else if (pick < number)
                {
                    Console.WriteLine(diffanswers[number2]);
                    pick = int.Parse(Console.ReadLine());
                }
                else if (pick > number)
                {
                    Console.WriteLine(diffanswers2[number2]);
                    pick = int.Parse(Console.ReadLine());
                }
                count++;
            }

            if (pick == number)
            {
                Console.WriteLine("Woho! Du gjorde det!");
            }
            else if (count == 4)
            {
                Console.WriteLine("Tyvärr du lyckades inte gissa talet på 5 försök!");
            }
        }


    }
}

