namespace Queues_and_stacks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Q U E U E S   A N D   S T A C K S");
            Postfix();
        }

        static public void Postfix()
        {
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
    }
}
