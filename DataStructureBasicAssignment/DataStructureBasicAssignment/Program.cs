using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 * Li-Kuang Ni      Section 1 Group 4        Sep/19/2016
 * 
 * Data Structures Basics Assignment
 * 
 * The prgramcCreate a variable for a Queue with items of type string
 * and create a variable for a Dictionary with keys of type string and 
 * values of type int. The program then put 100 customers into the queue
 * by randomly generate names. The program then add a random number of 
 * burgers to the total for each customer and print out each customer and 
 * their total burgers eaten.
*/

namespace DataStructureBasicAssignment
{
    class Program
    {

        //add the randomName and randomNumberInRange functions
        public static Random random = new Random();

        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }

        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }

        static void Main(string[] args)
        {

            //Create a variable for a Queue with items of type string
            Queue<string> myQueue = new Queue<string>();

            //Create a variable for a Dictionary with keys of type string and values of type int
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();

            string sName;

            //Put 100 randomly generate customers into the queue
            for (int i = 0; i < 100; i++)
            {
                myQueue.Enqueue(randomName());
            }


            //Store the information into the dicitonary
            while (myQueue.Count > 0)
            {

                sName = myQueue.Dequeue();
                if (myDictionary.ContainsKey(sName))
                {
                    myDictionary[sName] += randomNumberInRange();
                }
                else
                {
                    myDictionary.Add(sName, randomNumberInRange());
                }
            }

            //print out each customer and their total burgers eaten
            foreach (string key in myDictionary.Keys)
            {
                Console.WriteLine(key + '\t' + '\t' + myDictionary[key]);
            }



            Console.Read();


        }
    }
}
