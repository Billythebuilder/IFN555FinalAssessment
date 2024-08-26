namespace QueenslandTalent;
using System;

class Program
{
    static void Main(string[] args)
    {
        //PT 1
        //Intro
        Console.WriteLine("*******************************************");
        Console.WriteLine("* Unveilling Queensland's Brightest Stars *");
        Console.WriteLine("* Written By: William Stark, N11947446    *");
        Console.WriteLine("*******************************************");
        int lastYearContestants = 0;
        int thisYearContestants = 0;
        string[] contestants = new string[40];
        int contestantCount = 0;
        //declare talent codes 1-4
        int[] ValidTalentCounts = new int[4];
        

        //PT 2
        //Prompt user for input (last year) must be 0-40.
        //If number is not 0-40 prompt user until they enter a valid input (while loop)
        while (true)
        {
            Console.Write("Enter last years number of contestants (0-40): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out lastYearContestants) && lastYearContestants >= 0 && lastYearContestants <= 40)
                break;
            else
                Console.WriteLine("Invalid input. You must enter an integer between 0 and 40.");
        }

        //Prompt user for input (this year) must be 0-40.
        //If number is not 0-40 prompt user until they enter a valid input (while loop)
        while (true)
        {
            Console.Write("Enter this years number of contestants (0-40): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out thisYearContestants) && thisYearContestants >= 0 && thisYearContestants <= 40)
                break;
            else
                Console.WriteLine("Invalid input. You must enter an integer between 0 and 40.");
        }

        //PT 3
        //Display all input data and compute and display the revenue expected for this year’s competition if each contestant pays a $20.50 entrance fee.
        Console.WriteLine("Last years contestants: " + lastYearContestants);
        Console.WriteLine("This years contestants: " + thisYearContestants);
        double Revenue = thisYearContestants * 20.50;
        Console.WriteLine("Expected revenue for this years competition with a ticket price of $20.50: $" + Revenue);

        //PT 4
        //Display a statement that compares the number of contestants each year.
        if (thisYearContestants > 2 * lastYearContestants)
            Console.WriteLine("This years competition is booming with talent!");
        else if (thisYearContestants > lastYearContestants)
            Console.WriteLine("This years competition has a healthy turnout!");
        else
            Console.WriteLine("This years competition is more intimate but equally exciting!");

        //After the user enters the number of contestants in this year’s competition
        //prompt them to enter the appropriate number of contestant names and a code
        Console.WriteLine("Please use the following talent codes:");
        Console.WriteLine("V: Vocal Performance");
        Console.WriteLine("C: Choreography");
        Console.WriteLine("I: Instrumental");
        Console.WriteLine("T: Miscellaneous or not listed");
        Console.WriteLine("Enter contestant names and talent codes:");
        //Ensure codes are valid, user must enter V/C/I/T
        for (int a = 0; a < thisYearContestants; a++)
        {
            char talentCode = ' ';
            while (!isValidTalentCode(talentCode))
            {
                Console.Write("Contestant " + (a + 1) + " name: ");
                string name = Console.ReadLine();
                Console.Write("Contestant " + (a + 1) + " talent code (V/C/I/T): ");
                string input = Console.ReadLine().ToUpper(); //if user enters lowercase make uppercase
                if (input.Length == 1)
                    talentCode = input[0];
                else
                    Console.WriteLine("Invalid talent code. Please try again.");
            }

            contestants[contestantCount] = " " + talentCode;
            contestantCount++;
            switch (talentCode)
            {
                case 'V':
                    ValidTalentCounts[0]++;
                    break;
                case 'C':
                    ValidTalentCounts[1]++;
                    break;
                case 'I':
                    ValidTalentCounts[2]++;
                    break;
                case 'T':
                    ValidTalentCounts[3]++;
                    break;
            }
        }

        //Output number based on talent code
        Console.WriteLine("Talent Counts:");
        //display output number in array position 0
        Console.WriteLine("Vocal Performers -            " + ValidTalentCounts[0]);
        //display output number in array position 1
        Console.WriteLine("Choreographers -              " + ValidTalentCounts[1]);
        //display output number in array position 2
        Console.WriteLine("Instrumenal -                 " + ValidTalentCounts[2]);
        //display output number in array position 3
        Console.WriteLine("Miscellaneous or not listed - " + ValidTalentCounts[3]);

        //display names based on talent codes
        while (true)
        {
            //Declare Sentinel Value to exit loop
            Console.Write("Enter a talent code (V/C/I/T) or enter x to leave this screen.");


            char searchCode = Convert.ToChar(Console.ReadKey());
            if (searchCode == 'x')
                break;

            if (isValidTalentCode(searchCode))
            {
                Console.WriteLine("Contestants with talent code " + searchCode);
                for (int i = 0; i < contestantCount; i++)
                {
                    if (contestants[i].Contains("(" + searchCode + ")"))
                        Console.WriteLine(contestants[i]);
                }
            }
            else
            {
                Console.WriteLine("Invalid talent code " + searchCode);
            }
        }
    }

    static bool isValidTalentCode(char code)
    {
        return code == 'V' || code == 'C' || code == 'I' || code == 'T';
    }
}
