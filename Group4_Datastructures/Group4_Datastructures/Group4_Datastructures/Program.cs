//Authors: Group 4 - Jonathan Woodbrey, Grant Dexter, Li-Kuang Ni, John Lim
//Description: This program demonstrates various functions that can be performed with a stack, queue, and dictionary.
//Date: 09/23/16

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4_Datastructures
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bExit = true;
            int input = 0;
            while (bExit)
            {
                try
                {
                    //Display menu for datastructures.
                    Console.WriteLine("Main Menu");
                    Console.WriteLine("---------");
                    Console.WriteLine("1. Stack");
                    Console.WriteLine("2. Queue");
                    Console.WriteLine("3. Dictionary");
                    Console.WriteLine("4. Exit");
                    input = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    while (input > 4 || input <= 0)
                    {

                        //keep menu in loop while program runs
                        Console.WriteLine("Enter a number within the menu range.\n");
                        Console.WriteLine("Main Menu");
                        Console.WriteLine("---------");
                        Console.WriteLine("1. Stack");
                        Console.WriteLine("2. Queue");
                        Console.WriteLine("3. Dictionary");
                        Console.WriteLine("4. Exit");
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("\nPlease enter a valid integer.\n");
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("\nPlease enter a valid integer.\n");
                }


                switch (input)
                {
                    case 1:
                        runStack();
                        break;
                    case 2:
                        runQueue();
                        break;
                    case 3:
                        runDictionary();
                        break;
                    case 4:
                        bExit = false;
                        break;
                }
            }
        }

        public static void runDictionary()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            int iInput = 0;
            Dictionary<string, int> dDictionary = new Dictionary<string, int>();
            string sStuff;

            //loop runs while waiting for user to hit 7
            while (iInput != 7)
            {
                Console.WriteLine("\n1. Add one item to Dictionary\n2. Add Huge List of Items to Dictionary\n3. Display Dictionary\n4. Delete from Dictionary\n5. Clear Dictionary\n6. Search Dictionary\n7. Return to Main Menu\n");
                Console.Write("Enter your selection as numeral: ");
                try
                {
                    iInput = Convert.ToInt32(Console.ReadLine());
                }
                catch { }

                //switch loop to check for input 
                switch (iInput)
                {
                    case 1:
                        Console.Write('\n' + "Enter the item you would like to add: ");
                        sStuff = Console.ReadLine();
                        dDictionary.Add(sStuff, dDictionary.Count + 1);
                        break;
                    case 2:
                        dDictionary.Clear();
                        for (int i = 0; i < 2000; i++)
                        {
                            dDictionary.Add("New Entry" + (i + 1), i + 1);
                        }
                        break;
                    case 3:
                        foreach (string key in dDictionary.Keys)
                        {
                            Console.WriteLine(key + '\t' + dDictionary[key]);
                        }
                        break;
                    case 4:

                        //get user input
                        Console.Write('\n' + "Which item would you like to delete: ");

                        try
                        {
                            string sDeleteItem = Console.ReadLine();
                            if (dDictionary.ContainsKey(sDeleteItem))
                            {
                                dDictionary.Remove(sDeleteItem);
                                Console.Write('\n' + "Item: " + sDeleteItem + " has been deleted.");
                                break;
                            }
                            else { Console.WriteLine('\n' + "Enter Item is not found "); }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine('\n' + "Enter Item is not Found ");
                        }

                        break;
                    case 5:
                        dDictionary.Clear();
                        Console.WriteLine('\n' + "DIctionary has been cleared ");
                        break;
                    case 6:
                        //gets team name
                        Console.Write('\n' + "Enter the item you would like to search: ");
                        string sSearchItem = Console.ReadLine();
                        sw.Start();
                        if (dDictionary.ContainsKey(sSearchItem))
                        {
                            Console.WriteLine('\n' + "Item: " + sSearchItem + " has been found.");
                        }

                        else
                        {
                            Console.WriteLine('\n' + "Item not found.");
                        }

                        //ends stop watch tracking
                        sw.Stop();
                        Console.WriteLine('\n' + "Elapsed Time: " + sw.Elapsed.ToString());
                        break;
                    case 7: break;
                    default:
                        Console.Write("\n Please enter a numeral between 1 and 7: ");
                        break;
                }
            }

        }
        public static void runStack()
        {

            //declare the variable and create the objects
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            Stack<string> sStack = new Stack<string>();
            int iInput = 0;

            while (iInput != 7)
            {
                Console.WriteLine("\n1. Add one item to Stack \n2. Add Huge List of Items to Stack \n3. Display Stack \n4. Delete from Stack \n5. Clear Stack \n6. Search Stack \n7. Return to Main Menu \n");

                //Stack
                Console.Write("Enter your selection as a numeral: ");
                try
                {
                    iInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                }

                switch (iInput)
                {
                    case 1:

                        Console.Write("Enter the item you would like to add: ");
                        sStack.Push(Console.ReadLine());
                        break;
                    case 2:
                        sStack.Clear();
                        for (int i = 0; i < 2000; i++)
                        {
                            sStack.Push("New Entry " + (i + 1));
                        }
                        break;
                    case 3:
                        try
                        {
                            //output stack contents
                            Console.WriteLine("\n - STACK - ");
                            foreach (string item in sStack)
                            {

                                Console.WriteLine(item);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: " + e.ToString() + "\n");
                        }
                        break;
                    case 4:
                        {
                            //get user input
                            Console.Write("Which item would you like to delete: ");
                            string sDeleteItem = Console.ReadLine();
                            Stack<string> tempStack = new Stack<string>();
                            bool bWasDeleted = false;


                            //compare each item, remove matching items, place in temporary stack
                            while (sStack.Count > 0)
                            {
                                if (sStack.Peek() == sDeleteItem)
                                {
                                    sStack.Pop();

                                    bWasDeleted = true;

                                }
                                else
                                {
                                    tempStack.Push(sStack.Pop());
                                }

                            }

                            //check if item was successful
                            if (bWasDeleted)
                            {
                                Console.WriteLine("Item: " + sDeleteItem + " has been deleted. \n");
                            }
                            else
                            {
                                Console.WriteLine("Item not found, nothing deleted \n");
                            }

                            //replace items in original stack (minus the deleted item(s))
                            while (tempStack.Count > 0)
                            {
                                sStack.Push(tempStack.Pop());
                            }

                        }
                        break;
                    case 5:
                        {
                            sStack.Clear();
                            Console.WriteLine("\nStack has been cleared.\n");

                        }
                        break;
                    case 6:
                        {
                            bool bWasFound = false;
                            Stack<string> tempStack = new Stack<string>();

                            Console.Write("Enter the item you would like to search: ");
                            string sSearchItem = Console.ReadLine();

                            //search and record time to search
                            while (sStack.Count > 0)
                            {
                                sw.Start();
                                if (sStack.Peek() == sSearchItem)
                                {
                                    bWasFound = true;
                                }

                                tempStack.Push(sStack.Pop());


                            }
                            sw.Stop();

                            //item was found
                            if (bWasFound)
                            {
                                Console.WriteLine("Item: " + sSearchItem + " has been found. \n");
                            }
                            else
                            {
                                Console.WriteLine("Item not found.");
                            }

                            //display time to search
                            Console.WriteLine("Elapsed Time: " + sw.Elapsed.ToString() + "\n");

                            //replace items in original stack
                            while (tempStack.Count > 0)
                            {
                                sStack.Push(tempStack.Pop());
                            }
                        }
                        break;
                    case 7:
                        Console.WriteLine("Returning to main menu \n");
                        break;
                    default:
                        Console.Write("\n Please enter a numeral between 1 and 7: ");
                        break;
                }
            }
        }

        public static void runQueue()
        {

            //intitiate variables
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            Queue<string> sQueue = new Queue<string>();
            int iInput = 0;

            while (iInput != 7)
            {
                Console.WriteLine("\n1. Add one item to Queue\n2. Add Huge List of Items to Queue\n3. Display Queue\n4. Delete from Queue\n5. Clear Queue\n6. Search Queue\n7. Return to Main Menu\n");

                //Stack
                Console.Write("Enter your selection as a numeral: ");
                try
                {
                    iInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                }
                switch (iInput)
                {
                    case 1:
                        Console.Write("Enter the item you would like to add: ");
                        sQueue.Enqueue(Console.ReadLine());
                        break;
                    case 2:
                        sQueue.Clear();
                        for (int i = 0; i < 2000; i++)
                        {
                            sQueue.Enqueue("New Entry " + (i + 1));
                        }
                        break;
                    case 3:
                        try
                        {
                            Console.WriteLine("\n - QUEUE - ");
                            foreach (string item in sQueue)
                            {

                                Console.WriteLine(item);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: " + e.ToString() + "\n");
                        }
                        break;
                    case 4:
                        {
                            //get user input
                            Console.Write("Which item would you like to delete: ");
                            string sDeleteItem = Console.ReadLine();
                            Queue<string> tempQueue = new Queue<string>();
                            bool bWasDeleted = false;


                            //compare each item, remove matching items, place in temporary stack
                            while (sQueue.Count > 0)
                            {
                                if (sQueue.Peek() == sDeleteItem)
                                {
                                    sQueue.Dequeue();
                                    bWasDeleted = true;

                                }
                                else
                                {
                                    tempQueue.Enqueue(sQueue.Dequeue());
                                }

                            }
                            if (bWasDeleted)
                            {
                                Console.WriteLine("Item: " + sDeleteItem + " has been deleted. \n");
                            }
                            else
                            {
                                Console.WriteLine("Item not found, nothing deleted \n");
                            }

                            //replace items in original stack (minus the deleted item(s))
                            while (tempQueue.Count > 0)
                            {
                                sQueue.Enqueue(tempQueue.Dequeue());
                            }
                        }
                        break;
                    case 5:
                        {
                            sQueue.Clear();
                            Console.WriteLine("\nQueue has been cleared.\n");

                        }
                        break;
                    case 6:
                        {
                            bool bWasFound = false;
                            Queue<string> tempQueue = new Queue<string>();

                            Console.Write("Enter the item you would like to search: ");
                            string sSearchItem = Console.ReadLine();

                            //search and record time to search
                            while (sQueue.Count > 0)
                            {
                                sw.Start();
                                if (sQueue.Peek() == sSearchItem)
                                {
                                    bWasFound = true;
                                }

                                tempQueue.Enqueue(sQueue.Dequeue());

                            }
                            sw.Stop();

                            if (bWasFound)
                            {
                                Console.WriteLine("Item: " + sSearchItem + " has been found. \n");
                            }
                            else
                            {
                                Console.WriteLine("Item not found.");
                            }

                            //display time to search
                            Console.WriteLine("Elapsed Time: " + sw.Elapsed.ToString() + "\n");

                            //replace items in original stack
                            while (tempQueue.Count > 0)
                            {
                                sQueue.Enqueue(tempQueue.Dequeue());
                            }
                        }
                        break;
                    case 7:
                        Console.WriteLine("Returning to main menu \n");
                        break;
                    default:
                        Console.Write("\n Please enter a numeral between 1 and 7: ");
                        break;
                }
            }
        }

    }
}
