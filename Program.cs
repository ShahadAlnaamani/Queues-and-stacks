namespace Queues_and_stacks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Q U E U E S   A N D   S T A C K S");
            Postfix();
            Reverse();
            CheckBrackets();
            MaxFinder();
        }

        //Calculates postfix 
        static public void Postfix()
        {
            Console.WriteLine("POSTFIX CALCULATIONS");
            Stack<int> PostFixStack = new Stack<int>();
            List<string> PInput = new List<string>(); //Added list so later can add functions for user input 

            PInput.Add("5"); //Adding numbers manually for now 
            PInput.Add("1");
            PInput.Add("2");
            PInput.Add("+");
            PInput.Add("4");
            PInput.Add("*");
            PInput.Add("+");
            PInput.Add("3");
            PInput.Add("-");
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
            Console.WriteLine("\n\n\nSTRING REVERSING");
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

            if (OpenBracketCounter == CloseBracketCounter)
            {
                Console.WriteLine("Balanced");

            }
            else
            {
                Console.WriteLine("Not Balanced");
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

        }
    }
}
