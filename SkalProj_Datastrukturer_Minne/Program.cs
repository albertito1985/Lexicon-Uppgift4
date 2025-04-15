using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        //Frågor
        //1- Stacken är en del/typ av minne som lagrar data utifrån premissen last in först out och fungerar parallellt med heapen.
            //Heapen är en annan del/typ av minne som, till skillnad från stacken, lagrar data men hjälp av pointers och på detta visset
            //är all data direkt tillgänglig.

        //2- Value types är data types som direkt hanterar ett värde.
            //
            //T.ex.
            //int v = 180;
            //int x = v;
            //
            //när man initierar x med värdet av v då kopierar x värdet av v.
            //
            //Reference types är data types som hanterar istället en pekare till deras värde. På detta sättet om man kopierar en reference type
            //kan man direkt manipulera dess värde.
            //Skillnaden mellan reference och value types är att reference types har en class som constructor och value types har en struct.
        
        //3- Den första metod returnerar 3 eftersom int är en value type och när programmet exekverar y=x skapar den en kopia av x:s värde och tilldelar den till y. Därav x behåller sitt värde.
        //I den andra metod returnerar 4 eftersom MyInt är en class, eller rättare sagt en reference type, och när programmet exekverar y=x skapar den två referenser till samma data. Därmed den ändrar y.MyValue ändrar den också x.MyValue.


        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }

            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*Frågor
             * 2- När kapaciteten på Listan nås.
             * 3- Capaciteten fördubblas varje gång arrayen blir full.
             * 4- För isf skulle kapaciteten ändras till varje input och det skulle vara slösseri med processorens kapacitet.
             * 5- Nej, kapaciteten minskas inte.
             * 6- När man vet exakt hur stor den ska vara och kapaciteten ska inte förändras.
             */


            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            List<string> theList = new();
            bool exit = false;
            string input=" ";
            string value = "";
            char nav=' ';

            do
            {
                Console.WriteLine("ADD or REMOVE persons from the list"
                   + "\nType \"+NAME\"  to add a new name to the list."
                   + "\nType \"-NAME\" to remove a name from the list."
                   + "\nType \"b\" to go back to the previous men");

            
                try
                {
                    input = Console.ReadLine();
                    if (String.IsNullOrEmpty(input))
                    {
                        throw new IndexOutOfRangeException();
                    }
                    else
                    {
                        nav = (char)input[0];
                        value = input.Substring(1).ToUpper();
                    }

                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                switch (nav)
                {
                    case '+':
                        AddToList(theList, value);
                        break;
                    case '-':
                        RemoveFromList(theList, value);
                        break;
                    case 'b':
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter either +NAME, -NAME or b!");
                        break;
                }
            } while (!exit);
        }

        static void AddToList(List<string> theList, string stringToAdd)
        {
            
            theList.Add(stringToAdd);
            CheckCapacityAndCount(theList);
        }

        static void RemoveFromList(List<string> theList, string stringToRemove)
        {
            
            theList.Remove(stringToRemove);
            CheckCapacityAndCount(theList);
        }



        static void CheckCapacityAndCount(List<string> theList)
        {
            Console.WriteLine($"List capacity: {theList.Capacity}\n" +
                            $"List count: {theList.Count}");
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

