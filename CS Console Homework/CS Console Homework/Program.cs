using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Li-Kuang Ni   Section 1 Group 4    9/9/2016
 * 
 * Olympic Soccer Tournament
 * 
 * This program will prompts the user to enter in the number of teams competing in an olympic soccer tournament. 
 * Then for the number of teams entered, prompt the user to enter the name of the team and the number of points the 
 * team has scored. Finally, the program will display the results of the tournament.
 * 
 */

namespace ConsoleApplication2
{
    //parent class Team
    public class Team
    {
        public String name;
        public int wins;
        public int losses;
    }

    //child class SoccerTeam
    public class SoccerTeam : Team
    {
        public int draw;
        public int goalsfor;
        public int goalsagainst;
        public int differential;
        public int points;

        //constructor
        public SoccerTeam(string sName, int iPoints)
        {
            this.name = sName;
            this.points = iPoints;
        }

        //default constructor
        public SoccerTeam() { }

    }



    class Program
    {
        static string UppercaseFirst(string s)
        {

            //Return char and concat substring
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        static void Main(string[] args)
        {
            //variables
            int iTeamNum;
            int iTeamPoints;
            String sTeamName;
            List<SoccerTeam> lTeam = new List<SoccerTeam>();

            //while loop and try catch to check if user input is an integer
            while (true)
            {
                Console.Write("How many teams? ");
                try
                {
                    iTeamNum = Convert.ToInt32(Console.ReadLine());

                    //while loop to check if input is a negative integer
                    while (true)
                    {
                        if (iTeamNum < 0)
                        {
                            Console.WriteLine('\n' + "You must enter an integer that is greater than 0! ");
                            Console.Write("How many teams? ");
                            iTeamNum = Convert.ToInt32(Console.ReadLine());
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                }

                catch (Exception ex)
                {
                    Console.WriteLine('\n' + "You must enter an integer that is greater than 0!");
                }

            }

            //for loop let user input team info
            for (int iCount = 0; iCount < iTeamNum; iCount++)
            {

                Console.WriteLine();

                //while loop to check if user input is null or empty
                while (true)
                {
                    Console.Write("Enter Team " + (iCount + 1) + "'s name: ");
                    sTeamName = Console.ReadLine();

                    try
                    {
                        sTeamName = UppercaseFirst(sTeamName);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine('\n' + "You must enter a team name! ");
                    }
                }

                //while loop and try catch to check if user input is an integer
                while (true)
                {
                    Console.Write("Enter " + sTeamName + "'s points: ");

                    try
                    {
                        iTeamPoints = Convert.ToInt32(Console.ReadLine());

                        //while loop to check if input is a negative integer
                        while (true)
                        {
                            if (iTeamPoints < 0)
                            {
                                Console.WriteLine('\n' + "You must enter an integer that is greater than 0!");
                                Console.Write("Enter " + sTeamName + "'s points: ");
                                iTeamPoints = Convert.ToInt32(Console.ReadLine());
                            }
                            else { break; }
                        }
                        break;
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine('\n' + "You must enter an integer that is greater than 0!");
                    }

                }

                //create a list and store each team's information
                lTeam.Add(new SoccerTeam(sTeamName, iTeamPoints));
            }

            Console.WriteLine('\n' + "Here is the sorted list: " + '\n');

            //sorted the list by the team's points in descending order
            List<SoccerTeam> sortedTeams = lTeam.OrderByDescending(team => team.points).ToList();

            // Create result table's column headers and separators for Position, Name, and Points
            Console.Write("Position".PadRight(30, ' '));
            Console.Write("Name".PadRight(30, ' '));
            Console.WriteLine("Points".PadRight(30, ' '));
            Console.Write("--------".PadRight(30, ' '));
            Console.Write("-----".PadRight(30, ' '));
            Console.WriteLine("------".PadRight(30, ' '));

            //foreach loop to print out sorted result
            int position = 1;
            foreach (SoccerTeam myTeam in sortedTeams)
            {

                Console.WriteLine(position.ToString().PadRight(30, ' ') + myTeam.name.PadRight(30, ' ') + myTeam.points.ToString().PadRight(30, ' '));
                position++;
            }

            Console.Read();
        }
    }
}