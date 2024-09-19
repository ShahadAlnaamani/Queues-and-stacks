using System.Collections.Immutable;
using System.Globalization;

namespace Queues_and_stacks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Q U E U E S   A N D   S T A C K S");
            //Postfix();
            //Reverse();
            //CheckBrackets();
            //MaxFinder();
            //Order();
           // ReversingQ();
            IsPalindrome();
        }

        //Calculates postfix 
        static public void Postfix()
        {
            Console.WriteLine("POSTFIX CALCULATIONS");
            Stack<int> PostFixStack = new Stack<int>();
            List<string> PInput = new List<string>(); //Added list so later can add functions for user input 

            Console.Write("Enter: ");
            string Input = Console.ReadLine();
            
            foreach (char A in Input)
            {
                if (A == ' ') { }

                else
                {
                    PInput.Add(A.ToString());
                }
            }


            for (int i = 0; i< PInput.Count(); i++) 
            {
                try //checking if number will push to stack
                {
                    int value  = int.Parse(PInput[i]);
                    PostFixStack.Push(value);
                }
                catch // if operator will pop and calculate 
                {
                    string Operator = PInput[i];
                    int Number1 = PostFixStack.Pop();
                    int Number2 = PostFixStack.Pop();
                    int Total = 0;

                    switch (Operator) 
                    {
                        case "+":
                            Total = Number1 + Number2;
                            break;

                        case "-":
                            if (Number1 > Number2)
                            {
                                Total = Number1 - Number2;
                            }
                            else 
                            {
                                Total = Number2 - Number1;
                            }
                            break;

                        case "*":
                            Total = Number1 * Number2;
                            break;

                        case "/":
                            if (Number1 > Number2)
                            {
                                Total = Number1 / Number2;
                            }
                            else
                            {
                                Total = Number2 / Number1;
                            }
                            break;

                    }
                    PostFixStack.Push(Total);

                }

            }
            foreach (var number in PostFixStack)
            { Console.WriteLine(number); }
        }


        //Reverses strings
        static public void Reverse()
        {
            Stack<string> ReverseStack = new Stack<string>();
            Console.WriteLine("\n\n\nS T R I N G   R E V E R S I N G");
            Console.Write("\nEnter string: ");
            string Input = Console.ReadLine();

            foreach (char letter in Input)
            {
                ReverseStack.Push(letter.ToString());
            }

            Console.Write("\nReversed: ");

            foreach (string L in ReverseStack)
            {
                Console.Write(L);
            }
        }


        //Checks if brackets are balanced 
        static public void CheckBrackets()
        {
            Console.WriteLine("\n\n\n B R A C K E T   C H E C K E R ");
            Console.Write("\nEnter string: ");
            string UserInput = Console.ReadLine();

            Stack<string> Brackets = new Stack<string>();
            int OpenBracketCounter = 0;
            int CloseBracketCounter = 0;

            foreach (char i in UserInput)//Adding values individually to stack 
            {
                Brackets.Push(i.ToString());
            }

            while (Brackets.Count() > 0)
            {
                string part = Brackets.Pop();

                if (part == "(")
                {
                    OpenBracketCounter++;
                }

                else if (part == ")")
                {
                    CloseBracketCounter++;
                }
            }
            if (OpenBracketCounter > 0 && CloseBracketCounter > 0) //Checking that there are brackets 
            {
                if (OpenBracketCounter == CloseBracketCounter)
                {
                    Console.WriteLine("Balanced");

                }
                else
                {
                    Console.WriteLine("Not Balanced");
                }
            }
            else 
            {
                Console.WriteLine("String did not have any brackets");
            }

        }


        //Find maximum element of stack 
        static public void MaxFinder()
        {
            Stack<string> Elements = new Stack<string>();

            Console.WriteLine("\n\n\nM A X   E L E M E N T   F I N D E R");
            Console.Write("Enter elements: ");
            string ElementString = Console.ReadLine();
            int HighestNumber = 0;

            //Finding without using Max();
            foreach (char i in ElementString)//Adding values individually to stack 
            {
                try
                {//Checking if it is a number 
                    int number = int.Parse(i.ToString());
                    
                    if (number > HighestNumber) //Keeping track of highest number 
                    {
                        HighestNumber = number;
                    }

                    Elements.Push(i.ToString());
                }
                catch
                {
                    Elements.Push(i.ToString()); //Adding anything that is not an int
                }
            }

            if (HighestNumber != 0)
            {
                Console.WriteLine("The highest element is: " + HighestNumber);
            }
            else 
            { 
                Console.WriteLine("There were no numbers in the given input :)");
            }


            //Using Max();
            int Max = 0; 
            while (Elements.Count() > 0)
            {
                string part = Elements.Pop();

                try
                {
                    int Part = int.Parse(part);
                    if (Part > Max)
                    {
                        Max = Part;
                    }
                }
                catch { }; //ignores any non int values 
            }
            Console.WriteLine("This maximum was found using Max(); -> " + Max);
        }


        //Reverse string of int using stacks and queues
        public static void ReversingQ()
        {
            Console.WriteLine("\n\n\nR E V E R S I N G   U S I N G   Q U E U E S");
            Console.Write("Enter string: ");
            string ToBeReversed = Console.ReadLine();
            Queue<int> Q1 = new Queue<int>();
            Queue<int> Q2 = new Queue<int>();

            foreach (char A in ToBeReversed)
            {
                try
                {
                    Q1.Enqueue(int.Parse(A.ToString()));
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

            //Reversing the order 
            while (Q1.Count > 0)
            {
                Q2.Enqueue(Q1.Dequeue());
            }

            Console.Write("\nReversed: ");
            foreach (int i in Q2)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }


        //Palindrome checker using queues 
        public static void IsPalindrome()
        {
            Console.WriteLine("\n\n\nP A L I N D R O M E   C H E C K E R");
            Console.Write("Enter: ");
            string Input = Console.ReadLine();

            bool Palindrome = true;
            string X;
            string Y;
            Queue <string> Q1 = new Queue<string>(); //String going forward
            Stack<string> S1 = new Stack<string>(); //String going backward


            //Adding variables to first queue 
            foreach(char A in Input)
            {
                Q1.Enqueue(A.ToString());
            }

            //Adding everything in reverse order 
            foreach (char B in Input)
            {
                S1.Push(B.ToString());
            }

            while (Q1.Count != 0)
            {
                X = Q1.Dequeue();   
                Y = S1.Pop();

                if (X != Y)
                { 
                    Palindrome = false;
                }
            }

            Console.WriteLine("Is palindrome: " + Palindrome);
        }



        ////BONUS - Sort into ascending order only using stacks
        //static public void Order()
        //{
        //    Console.WriteLine("\n\n\nO R D E R   U S I N G   S T A C K S");
        //    Console.Write("Enter: ");
        //    string Sequence = Console.ReadLine();

        //    Stack <int> Initial = new Stack<int>();  
        //    Stack<int> Ordered = new Stack<int> ();
        //    bool Sorted = false;

        //    foreach (var part in Sequence) 
        //    {
        //        Initial.Push(part);
        //    }

        //    int Value1;
        //    int Value2;
        //    int Counter;
        //    int Total = Initial.Count();
        //    Value1 = Initial.Pop();

        //    Value1 = int.Parse(Value1);

        //    do
        //    {
        //        Sorted = false;
        //        Counter = Initial.Count;
        //        while (Initial.Count() > 0)
        //        {
        //            Value2 = Initial.Pop();
        //            Value2 = int.Parse(Value2);

        //            if (Value1 < Value2)
        //            {
        //                Ordered.Push(Value1); 
        //                Ordered.Push(Value2);
        //                Value1 = Value2;
        //            }

        //            else 
        //            {
        //                Ordered.Push(Value2); 
        //                Ordered.Push(Value1);
        //                Value1 = Value2;
        //                Counter--;
        //            }

        //        }

        //        if (Counter == Total)
        //        {
        //            Sorted = true;
        //        }

        //    }while (Sorted != true);

        //    foreach (var part in Ordered)
        //    {
        //        Console.WriteLine(part);
        //    }
        //}



    }
}
