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
                   + "\nType \"b\" to go back to the previous menu.");

            
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
                        ShowList(theList);
                        break;
                    case '-':
                        RemoveFromList(theList, value);
                        ShowList(theList);
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

            static void ShowList(List<string> theList)
            {
                foreach (string item in theList)
                {
                    Console.WriteLine(item);
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Queue<string> theQueue = new();
            bool exit = false;
            string input = " ";
            string value = "";
            char nav = ' ';

            do
            {
                Console.WriteLine("ADD or REMOVE persons from the queue"
                   + "\nType \"+NAME\"  to add a new name to the queue."
                   + "\nType \"-\" to remove the first person from the queue."
                   + "\nType \"b\" to go back to the previous menu.");


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
                        theQueue.Enqueue(value);
                        ShowQueue(theQueue);
                        break;
                    case '-':
                        if (theQueue.Count>0)
                        {
                            theQueue.Dequeue();
                            ShowQueue(theQueue);
                        }
                        else
                        {
                            Console.WriteLine("The queue is empty.");
                        }
                            break;
                    case 'b':
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter either +NAME, - or b!");
                        break;
                }
            } while (!exit);

            static void ShowQueue(Queue<string> theQueue)
            {
                foreach (string item in theQueue)
                {
                    Console.WriteLine(item);
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             *1- Det är inte smart att använda sig på stack i det här fallet då stack fungerar inte som en kö i det riktiga världen.
             *alltså, personen som kommer först till kön skulle hanteras sist och det är inte rättvisst.
            */

            Stack<string> theStack = new();
            bool exit = false;
            string input = " ";
            string value = "";
            char nav = ' ';

            do
            {
                Console.WriteLine("ADD or REMOVE persons from the stack."
                   + "\nType \"+NAME\"  to add a new name to the stack."
                   + "\nType \"-\" to remove the first person from the stack."
                   + "\nType \"r\" if you want to reverse the order of the letters in the name you type."
                   + "\nType \"b\" to go back to the previous menu.");


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
                        theStack.Push(value);
                        ShowStack(theStack);
                        break;
                    case '-':
                        if (theStack.Count > 0)
                        {
                            theStack.Pop();
                            ShowStack(theStack);
                        }
                        else
                        {
                            Console.WriteLine("The Stack is empty.");
                        }
                        break;
                    case 'b':
                        exit = true;
                        break;
                    case 'r':
                        ReverseName();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter either +NAME, - or b!");
                        break;
                }
            } while (!exit);

            static void ShowStack(Stack<string> theStack)
            {
                foreach (string item in theStack)
                {
                    Console.WriteLine(item);
                }
            }

            static void ReverseName()
            {
                bool validated = false;
                string input = "";
                Stack <char> nameStack= new();

                do
                {
                    Console.Write("Type a name to reverse: ");

                    try
                    {
                        input = Console.ReadLine();
                        if (String.IsNullOrEmpty(input))
                        {
                            throw new IndexOutOfRangeException();
                        }
                        else
                        {
                            validated = true;
                            foreach(char item in input)
                            {
                                nameStack.Push(item);
                            }
                            
                        }

                    }
                    catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter some input!");
                    }
                } while (!validated);

                int internalCount = nameStack.Count;
                for (int i=0; i< internalCount; i++)
                {
                    Console.Write(nameStack.Pop());

                }
                Console.Write('\n');
                

            }
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

